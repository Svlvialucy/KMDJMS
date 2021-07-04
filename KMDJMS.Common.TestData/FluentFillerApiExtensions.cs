using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace KMDJMS.Common.TestData
{
    public static class FluentFillerApiExtensions
    {
        /// <summary>
        /// 根据 Validation 特性设置属性随机值的生成插件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <returns></returns>
        public static FluentFillerApi<T> SetupAnnotations<T>(this FluentFillerApi<T> api) where T : class
        {
            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                var attributes = propertyInfo.CustomAttributes?.ToList();
                if (attributes == null)
                    continue;
                foreach (var attribute in attributes)
                {
                    var parameter = Expression.Parameter(typeof(T), "t");
                    var propertyExpression = Expression.Property(parameter, propertyInfo);
                    var funcType = typeof(Func<,>).MakeGenericType(typeof(T), propertyInfo.PropertyType);
                    dynamic lambda = Expression.Lambda(funcType, propertyExpression, parameter);
                    var propertyApi = api.OnProperty(lambda);
                    var attributeType = attribute.AttributeType;
                    //if (attributeType == typeof(BagNumValidationAttribute))
                    //{
                    //    propertyApi.Use(new RandomBagNumPlugin());
                    //}
                    //else if (attributeType == typeof(BankNoValidationAttribute))
                    //{
                    //    propertyApi.Use(new RandomBankNoPlugin());
                    //}
                    //else if (attributeType == typeof(BankSerialNumberValidationAttribute))
                    //{
                    //    propertyApi.Use(new RandomBankSerialNumberPlugin());
                    //}
                    //else if (attributeType == typeof(BillCodeValidationAttribute))
                    //{
                    //    propertyApi.Use(new RandomBillCodePlugin());
                    //}
                    //else if (attributeType == typeof(CreateTimeValidationAttribute))
                    //{
                    //    propertyApi.Use(attribute.ConstructorArguments.Count > 0
                    //        ? new RandomCreateTimePlugin((int)attribute.ConstructorArguments[0].Value)
                    //        : new RandomCreateTimePlugin());
                    //}
                    //else if (attributeType == typeof(EmployeeCodeValidationAttribute))
                    //{
                    //    propertyApi.Use(new RandomEmployeeCodePlugin());
                    //}
                    //else if (attributeType == typeof(IdCardValidationAttribute))
                    //{
                    //    propertyApi.Use(new RandomIdCardPlugin());
                    //}
                    //else if (attributeType == typeof(KQMCodeValidationAttribute))
                    //{
                    //    propertyApi.Use(new RandomKQMCodePlugin());
                    //}
                    //else if (attributeType == typeof(PhoneNumberValidationAttribute))
                    //{
                    //    propertyApi.Use(new RandomPhoneNumberPlugin());
                    //}
                    //else if (attributeType == typeof(SiteCodeValidationAttribute))
                    //{
                    //    propertyApi.Use(new RandomSiteCodePlugin());
                    //}
                    //else if (attributeType == typeof(TelePhoneValidationAttribute))
                    //{
                    //    propertyApi.Use(new RandomTelePhonePlugin());
                    //}
                    //else 
                    if (attributeType == typeof(EmailAddressAttribute))
                    {
                        propertyApi.Use(new EmailAddresses());
                    }
                    //else if (attributeType == typeof(FileExtensionsAttribute))
                    //{
                    //    var extensions = attribute.NamedArguments.FirstOrDefault(na => na.MemberName == "Extensions")
                    //        .TypedValue.Value as string;
                    //    propertyApi.Use(new RandomFileExtensionPlugin(extensions));
                    //}
                    //else if (attributeType == typeof(PhoneAttribute))
                    //{
                    //    propertyApi.Use(new RandomPhoneNumberPlugin());
                    //}
                    else if (attributeType == typeof(MaxLengthAttribute) || attributeType == typeof(MinLengthAttribute))
                    {
                        var maxAttr = attributes.FirstOrDefault(a => a.AttributeType == typeof(MaxLengthAttribute));
                        var minAttr = attributes.FirstOrDefault(a => a.AttributeType == typeof(MinLengthAttribute));
                        var maxLength = maxAttr != null && maxAttr.ConstructorArguments.Count > 0
                            ? (int)maxAttr.ConstructorArguments[0].Value
                            : 25;
                        var minLength = minAttr != null && minAttr.ConstructorArguments.Count > 0
                            ? (int)minAttr.ConstructorArguments[0].Value
                            : 1;

                        // Array
                        if (propertyInfo.PropertyType.IsArray)
                        {
                            var generator = MakeArrayGenerator(minLength, maxLength, api.Result, propertyInfo.PropertyType);
                            (propertyApi.GetType() as Type)?
                                .GetMethod("Use", new[] { typeof(Func<>).MakeGenericType(propertyInfo.PropertyType) })
                                .Invoke(propertyApi, new object[] { generator });
                        }
                        // String
                        else if (propertyInfo.PropertyType == typeof(string))
                        {
                            propertyApi.Use(new MnemonicString(1, minLength, maxLength + 1));
                        }
                        // Other
                        else
                        {
                            continue;
                        }
                    }
                    else if (attributeType == typeof(RangeAttribute))
                    {
                        var arguments = attribute.ConstructorArguments;
                        if (arguments.Count == 2)
                        {
                            var rangeStart = arguments[0];
                            var rangeEnd = arguments[1];
                            if (rangeStart.ArgumentType == typeof(int) && rangeEnd.ArgumentType == typeof(int))
                            {
                                // support RangeAttribute
                                //TypeDescriptor.GetConverter(propertyInfo.PropertyType).ConvertFrom()
                            }
                            else if (rangeStart.ArgumentType == typeof(double) && rangeEnd.ArgumentType == typeof(double))
                            {

                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (arguments.Count == 3)
                        {

                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        // Attribute not supported.
                        continue;
                    }
                    // We do setup according to the first valid attribute on this property. Thus, if goes here without "continue", end processing this property.
                    break;
                }
            }
            return api;
        }

        private static Delegate MakeArrayGenerator(int minLength, int maxLength, FillerSetup setup, Type arrayType)
        {
            var elementType = arrayType.GetElementType();
            var listType = typeof(List<>).MakeGenericType(elementType);
            var randomLength = Expression.Parameter(typeof(int), "randomLength");
            var i = Expression.Parameter(typeof(int), "i");
            var list = Expression.Parameter(listType, "list");
            var breakLabel = Expression.Label("LoopBreak");
            var returnLabel = Expression.Label(arrayType);
            var expression =
                Expression.Lambda(typeof(Func<>).MakeGenericType(arrayType),
                    Expression.Block(
                        new[] { randomLength, i, list },
                        Expression.Assign(randomLength,
                            Expression.Call(
                                Expression.New(
                                    typeof(IntRange).GetConstructor(new[] { typeof(int), typeof(int) }),
                                    Expression.Constant(minLength), Expression.Constant(maxLength + 1)),
                                typeof(IntRange).GetMethod("GetValue"))
                        ),
                        Expression.Assign(
                            list,
                            Expression.New(listType
                                .GetConstructor(Type.EmptyTypes))),
                        Expression.Block(
                            Expression.Assign(i, Expression.Constant(0)),
                            Expression.Loop(
                                Expression.IfThenElse(Expression.LessThan(i, randomLength),
                                    Expression.Block(
                                        Expression.Call(list,
                                            listType.GetMethod("Add", new[] { elementType }),
                                            Expression.Convert(Expression.Call(typeof(Randomizer<>)
                                                    .MakeGenericType(elementType)
                                                    .GetMethod("Create", new[] { typeof(FillerSetup) }),
                                                Expression.Constant(setup)), elementType)),
                                        Expression.AddAssign(i, Expression.Constant(1))),
                                    Expression.Break(breakLabel)), breakLabel
                            )
                        ),
                        Expression.Return(returnLabel,
                            Expression.Call(list, listType.GetMethod("ToArray")), arrayType),
                        Expression.Label(returnLabel, Expression.Constant(null, returnLabel.Type))
                    ));
            return expression.Compile();
        }
    }
}
