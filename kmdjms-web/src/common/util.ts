export class Util {
    /**
     *
     * 数组去重
     * @static
     * @template T
     * @param {Array<T>} array 输入数组
     * @param {(node1: T, Node2: T) => number} [compare]
     * @returns {Array<T>}
     * @memberof Util
     */
    static distinctArray<T>(
      array: Array<T>,
      compare?: (node1: T, Node2: T) => number
    ): Array<T> {
      if (!array || array.length <= 1) {
        return array;
      }
      let tempArray = array.sort(compare);
      let resultArray = [array[0]];
      for (let i = 0; i < array.length; i++) {
        if (compare) {
          if (compare(array[i], resultArray[resultArray.length - 1]) !== 0) {
            resultArray.push(array[i]);
          }
        } else {
          if (array[i] !== resultArray[resultArray.length - 1]) {
            resultArray.push(array[i]);
          }
        }
      }
  
      return resultArray;
    }
  
    /**
     *  比较两个数组是否完全相同
     *
     * @static
     * @template T
     * @param {Array<T>} array1
     * @param {Array<T>} array2
     * @param {(t1: T, t2: T) => boolean} [compare] 可选的比较方法, 如果不提供,则采用默认 === 来比较
     * @returns 如果数组元素相同,返回true
     * @memberof Util
     */
    static compareArray<T>(
      array1: Array<T>,
      array2: Array<T>,
      compare?: (t1: T, t2: T) => boolean
    ) {
      if (!array1 || !array2) {
        return false;
      }
      if (array1.length !== array2.length) {
        return false;
      }
  
      for (let i = 0; i < array1.length; i++) {
        if (compare) {
          if (!compare(array1[i], array2[i])) {
            return false;
          } else {
            if (array1[i] !== array2[i]) {
              return false;
            }
          }
        }
      }
  
      return true;
    }
  
    /**
     *
     * 交换数组中元素的位置
     * @static
     * @template T
     * @param {Array<T>} array
     * @param {number} first
     * @param {number} second
     * @memberof Util
     */
    static swapArrayElement<T>(array: Array<T>, first: number, second: number) {
      let temp: T = array[first];
      array[first] = array[second];
      array[second] = temp;
    }
  
    /**
     * 检查数组是否包含某项元素
     *
     * @static
     * @template T
     * @param {Array<T>} array
     * @param {T} element
     * @param {(element1: T, element2: T) => boolean} [comparer] 比较器
     * @returns {boolean}
     * @memberof Util
     */
    static contains<T>(
      array: Array<T>,
      element: T,
      comparer?: (element1: T, element2: T) => boolean
    ): boolean {
      for (let i in array) {
        if (comparer && comparer(array[i], element)) {
          return true;
        } else {
          if (array[i] === element) {
            return true;
          }
        }
      }
      return false;
    }
  
    /**
     * 查找元素的索引
     *
     * @static
     * @template T
     * @param {Array<T>} array
     * @param {T} element
     * @param {(element1: T, element2: T) => boolean} [comparer] 比较器
     * @returns {boolean}
     * @memberof Util
     */
    static findIndex<T>(
      array: Array<T>,
      element: T,
      comparer?: (element1: T, element2: T) => boolean
    ): string {
      for (let i in array) {
        if (comparer && comparer(array[i], element)) {
          return i;
        } else {
          if (array[i] === element) {
            return i;
          }
        }
      }
      return "-1";
    }
  
    /**
     * 判定一个数组是否包含某项元素
     *
     * @static
     * @template T
     * @param {Array<T>} array
     * @param {T} element
     * @param {(e1, e2) => boolean} [compare]
     * @returns {boolean}
     * @memberof Util
     */
    static ArrayInclude<T>(
      array: Array<T>,
      element: T,
      compare?: (e1: any, e2: any) => boolean
    ): boolean {
      for (let i = 0; i < array.length; i++) {
        if (compare) {
          if (compare(array[i], element)) {
            return true;
          }
        } else {
          if (array[i] === element) {
            return true;
          }
        }
      }
      return false;
    }
  
    /**
     * 复制一个数组的全部元素
     *
     * @static
     * @template T
     * @param {Array<T>} source
     * @returns {Array<T>}
     * @memberof Util
     */
    static cloneArray<T>(source: Array<T>): Array<T> {
      let output: Array<T> = [];
      for (let i = 0; i < source.length; i++) {
        output[i] = source[i];
      }
      return output;
    }
  
    /**
     *  更具指定的范围生成数组
     *
     * @static
     * @param {number} start 开始 (包换在内)
     * @param {number} end 结束 (包含在内)
     * @returns {Array<number>}
     * @memberof Util
     * @example RangeOf(1,3) return [1,2,3]
     */
    static RangeOf(start: number, end: number): Array<number> {
      let array = new Array<number>();
      for (let i = start; i <= end; i++) {
        array.push(i);
      }
      return array;
    }
    /**
     *在数组中删除指定 元素
     *
     * @static
     * @template T
     * @param {Array<T>} array
     * @param {T} element
     * @param {(element1: T, element2: T) => boolean} [comparer]
     * @memberof Util
     */
    static removeElement<T>(
      array: Array<T>,
      element: T,
      comparer?: (element1: T, element2: T) => boolean
    ): void {
      for (let i = array.length - 1; i >= 0; i--) {
        if (comparer && comparer(array[i], element)) {
          array.splice(i, 1);
        } else if (array[i] === element) {
          array.splice(i, 1);
        }
      }
    }
  
    // 判断字符是否为空
    static isNullOrEmpty(str: string) {
      if (!str || str.replace(/\s+/g, "").length === 0) {
        return true;
      } else {
        return false;
      }
    }
  
    static setCookie(name: string, value: string, time?: number): void {
      if (time) {
        let minute = time || 1;
        let exp = new Date();
        exp.setTime(exp.getTime() + minute * 60 * 1000);
        document.cookie =
          name + "=" + escape(value) + ";path=/;expires=" + exp.toUTCString();
      } else {
        let minute = 24 * 60 - 1;
        let exp = new Date();
        exp.setTime(exp.getTime() + minute * 60 * 1000);
        document.cookie = name + "=" + escape(value) + ";path=/;expires=" + exp.toUTCString();
      }
    }
  
    // 读取cookie
    static getCookie(name: any): any {
      let arr,
        reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
      if ((arr = document.cookie.match(reg))) {
        return unescape(arr[2]);
      }
      return null;
    }
  
    // 删除cookie
    static delCookie(name: any) {
      let exp = new Date();
      exp.setTime(exp.getTime() - 1000);
      let cval = this.getCookie(name);
      if (cval != null) {
        document.cookie = name + "=;path=/;expires=" + exp.toLocaleDateString();
      }
    }
    static toTree(data: any) {
      // 删除 所有 children,以防止多次调用
      data.forEach((item: any) => {
        delete item.children;
      });
      // 将数据存储为 以 id 为 KEY 的 map 索引数据列
      let map = {};
      data.forEach((item: any) => {
        (map as any)[item.id] = item;
      });
      let val: Array<any> = [];
      data.forEach((item: any) => {
        // 以当前遍历项，的pid,去map对象中找到索引的id
        let parent = (map as any)[item.parentId];
        // 好绕啊，如果找到索引，那么说明此项不在顶级当中,那么需要把此项添加到，他对应的父级中
        if (parent) {
          (parent.children || (parent.children = [])).push(item);
        } else {
          //如果没有在map中找到对应的索引ID,那么直接把 当前的item添加到 val结果集中，作为顶级
          val.push(item);
        }
      });
      return val;
    }
  
    /**
     * 验证ip地址
     * @param ip
     */
    static validateIPAdd(ip: any) {
      let re = /^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$/;
      return re.test(ip);
    }
    static printLog(msg: any) {
      let blowersVersion = this.IEVersion();
      if (
        blowersVersion == -1 ||
        blowersVersion == "edge" ||
        blowersVersion > 9
      ) {
        // console.log(msg)
      }
    }
  
  /**
   * 身份证号简单校验
   * @param idcard 
   */
    static validateIDCard(idcard:any){
      //let re = /^\d{6}(18|19|20)?\d{2}(0[1-9]|1[012])(0[1-9]|[12]\d|3[01])\d{3}(\d|[xX])$/;
      let re = /^\d{17}(\d|[xX])$/;
      return re.test(idcard);
    }
  
    static IEVersion() {
      let userAgent = navigator.userAgent; //取得浏览器的userAgent字符串
      let isIE =
        userAgent.indexOf("compatible") > -1 && userAgent.indexOf("MSIE") > -1; //判断是否IE<11浏览器
      let isEdge = userAgent.indexOf("Edge") > -1 && !isIE; //判断是否IE的Edge浏览器
      let isIE11 =
        userAgent.indexOf("Trident") > -1 && userAgent.indexOf("rv:11.0") > -1;
      if (isIE) {
        let reIE = new RegExp("MSIE (\\d+\\.\\d+);");
        reIE.test(userAgent);
        let fIEVersion = parseFloat(RegExp["$1"]);
        if (fIEVersion == 7) {
          return 7;
        } else if (fIEVersion == 8) {
          return 8;
        } else if (fIEVersion == 9) {
          return 9;
        } else if (fIEVersion == 10) {
          return 10;
        } else {
          return 6; //IE版本<=7
        }
      } else if (isEdge) {
        return "edge"; //edge
      } else if (isIE11) {
        return 11; //IE11
      } else {
        return -1; //不是ie浏览器
      }
    }
  
    static formatDate(time: any) {
      var date = new Date(time);
  
      var year = date.getFullYear(),
        month = date.getMonth() + 1, //月份是从0开始的
        day = date.getDate();
      var newTime =
        year +
        "-" +
        (month < 10 ? "0" + month : month) +
        "-" +
        (day < 10 ? "0" + day : day);
  
      return newTime;
    }
  
    static getStringLength(value: string): number {
      return new String(value).length;
    }
  
    /**日期格式化成字符串，格式为'yyyy-MM-dd HH:mm:ss' */
    static formatDateTime(time: any): string {
      // 格式化日期，获取今天的日期
      const Dates = new Date(time);
      const year: number = Dates.getFullYear();
      if (!year) {
        return time;
      }
      const month: any = (Dates.getMonth() + 1) < 10 ? '0' + (Dates.getMonth() + 1) : (Dates.getMonth() + 1);
      const day: any = Dates.getDate() < 10 ? '0' + Dates.getDate() : Dates.getDate();
      const hour: any = Dates.getHours() < 10 ? '0' + Dates.getHours() : Dates.getHours();
      const minuter: any = Dates.getMinutes() < 10 ? '0' + Dates.getMinutes() : Dates.getMinutes();
      const second: any = Dates.getSeconds() < 10 ? '0' + Dates.getSeconds() : Dates.getSeconds();
      return year + '-' + month + '-' + day + ' ' + hour + ':' + minuter + ':' + second;
    }
    static IsNullOrUndefined(value: any): boolean {
      if (value == undefined || value.length == 0) {
        return true;
      }
      return false;
    }
  
    static drawImage(ImgD: any, iwidth: number) {
      //参数(图片,允许的宽度,允许的高度)
      let timerout = setTimeout(() => {
        let image = new Image();
        image.src = ImgD.src;
        if (image.width > 0 && image.height > 0) {
          if (image.width > iwidth) {
            ImgD.width = iwidth;
            ImgD.height = (image.height * iwidth) / image.width;
          } else {
            ImgD.width = image.width;
            ImgD.height = image.height;
          }
          ImgD.alt = image.width + "×" + image.height;
  
        }
        clearTimeout(timerout);
      }, 200);
    }
  
    static compareDate(beginDate: string, endDate: string) {
      var d1 = new Date(beginDate.replace(/\-/g, "\/"));
      var d2 = new Date(endDate.replace(/\-/g, "\/"));
      if (beginDate != "" && endDate != "" && d1 >= d2) {
        return false;
      }
      return true;
    }
  
    // 邮箱地址校验
    static validateEmail(email: any) {
      let re = /^(([^<>()\[\]\\.,;:\s@\x22]+(\.[^<>()\[\]\\.,;:\s@\x22]+)*)|(\x22.+\x22))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return re.test(email);
    }
  
    // 判断信用卡属于哪个公司
    static DetectCardType(_cardNumber: any)
    {
        _cardNumber = _cardNumber.replace(/[\s]/g, "");
        _cardNumber = _cardNumber.replace(/[-]/g, "");
        // default unknown
        var iCardType = 0;   
       
        // Visa
        if (/^4/.test(_cardNumber))
        {
            iCardType = 3;
        }
        // MasterCard
        else if (/^5[1-5]/.test(_cardNumber))
        {
            iCardType = 4;
        }   
        // American Express
        else if (/^3[47]/.test(_cardNumber))
        {
            iCardType = 5;
        }
        return iCardType;
    }
  
    // 信用卡卡号校验
    static ValidateCardNumber(_cardNumber: any)
    {	 
      _cardNumber = _cardNumber.replace(/[\s]/g, "");
      _cardNumber = _cardNumber.replace(/[-]/g, "");
      if (_cardNumber == "")
      {
          return ("Card number cannot be empty.");
      }	
      else 
      {
        let iCardType = this.DetectCardType(_cardNumber);
        if(iCardType == 0)
        {
          return ("Sorry, we accept only VISA, MasterCard and AmericanExpress Card.");
        }
        else
        {
          if (this.CheckLength(_cardNumber, iCardType) == true && this.CheckDigit(_cardNumber) == true)
          {
            return null;
          }
          else
          {
            // var strCardType = "VISA";
            // if (iCardType == 3)
            // {
            //   strCardType = "VISA";
            // }
            // else if (iCardType == 4)
            // {
            //   strCardType = "MasterCard";
            // }
            // else if (iCardType == 5)
            // {
            //   strCardType = "American Express";
            // }
            return ("Invalid card number." ); //+ strCardType
          }
        }
      }
    }
  
    static CheckLength(strCardNum: any, iCardType: any)
    {
      var isValid = false;
      switch (iCardType)
      {
        case 5:     // 15
          if (strCardNum.length == 15)
          {
              isValid = true;
          }
          break;
        case 4:     // 16
          if (strCardNum.length == 16)
          {
              isValid = true;
          }
          break;
        case 3:     // 13 or 16
          if (strCardNum.length == 13 || strCardNum.length == 16)
          {
              isValid = true;
          }
          break;
        default:
          isValid = false;
          break;
      }
      return isValid;
    }
  
  
  
    static CheckDigit(cardNum: any)
    {
      let count: number; /* a counter */
      let weight = 0; /* weight to apply to digit being checked */
      let sum: any; /* sum of weights */
      let digit = 0; /* digit being checked */
      let mod;
      weight = 2;
      sum = 0;
      for (count = cardNum.length - 2; count >= 0; count--)
      {
        digit = weight * Number(cardNum[count]);
        /* add both the tens digit and the ones digit to the sum */
        sum = sum + parseInt(String(digit / 10)) + (digit % 10);
        if (weight == 2)
          weight = 1;
        else
          weight = 2;
      }
      /* subtract the ones digit of the sum from 10 and return the ones digit of that result */
      mod = 10 - (sum % 10);
      mod = mod % 10;
      return (mod == Number(cardNum[cardNum.length - 1]));
    }
  
    static formatNumber (value: any) {
      value += ''
      const list = value.split('.')
      const prefix = list[0].charAt(0) === '-' ? '-' : ''
      let num = prefix ? list[0].slice(1) : list[0]
      let result = ''
      while (num.length > 3) {
        result = `,${num.slice(-3)}${result}`
        num = num.slice(0, num.length - 3)
      }
      if (num) {
        result = num + result
      }
      return `${prefix}${result}${list[1] ? `.${list[1]}` : ''}`
    }
  
    static scrollAnimation(currentY: any, targetY: any) {
      // 获取当前位置方法
      // const currentY = document.documentElement.scrollTop || document.body.scrollTop
    
      // 计算需要移动的距离
      let needScrollTop = targetY - currentY
      let _currentY = currentY
      setTimeout(() => {
        // 一次调用滑动帧数，每次调用会不一样
        const dist = Math.ceil(needScrollTop / 10)
        _currentY += dist
        window.scrollTo(_currentY, currentY)
        // 如果移动幅度小于十个像素，直接移动，否则递归调用，实现动画效果
        if (needScrollTop > 10 || needScrollTop < -10) {
          this.scrollAnimation(_currentY, targetY)
        } else {
          window.scrollTo(_currentY, targetY)
        }
      }, 1)
    }
  
  }
  