<template>
  <a-layout-header id="sales" class="header">
    <div class="logo">Dynamsoft Sales</div>
    <div class="UserId" v-if="userId!=''">
      <a-dropdown>
        <a class="ant-dropdown-link" href="#"> {{userName}} <a-icon type="down" /> </a>
        <a-menu slot="overlay">
          <a-menu-item>
            <a href="/">Web</a>
          </a-menu-item>
          <a-menu-item>
            <a href="/customer">Customer</a>
          </a-menu-item>
          <a-menu-item @click="logOut">
            <span>Logout</span>
          </a-menu-item>
        </a-menu>
      </a-dropdown>
    </div>
    <div class="fr shoppingCartIconBox" @click.stop="openShoppingCart"><i class="fa fa-shopping-cart shoppingCartIcon"></i></div>
  </a-layout-header>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
// import { CUSTOMERPREFIX, SALESPREFIX } from '@/common/api-config'
import authentication from '../../../common/authentication'
import { Util } from "../../../common/util"
import { Getter, Mutation } from 'vuex-class'
@Component({
  name: "SalesHead"
})
export default class SalesHead extends Vue  {
  @Getter('orderManage/getVisibleShoppingCart') visibleShoppingCart: any;
  @Getter('orderManage/getShoppingCartList') ShoppingCartList: any;
  @Mutation('orderManage/setVisibleShoppingCart') setVisibleShoppingCart: any;
  @Mutation('orderManage/setShoppingCartList') setShoppingCartList: any;
  @Mutation('orderManage/setIsAddCart') setIsAddCart: any

  userId: any = Util.getCookie("KMDJUser")==null?'':Util.getCookie("KMDJUser")
  userName: any = Util.getCookie("KMDJUserName")
  logOut() {
    authentication.logOut()
  }

  openShoppingCart() {
    this.setIsAddCart(false)
    this.setVisibleShoppingCart(!this.visibleShoppingCart)
  }
}
</script>

<style scope="scoped">
#sales.header .logo{
    float: left;
    font-size: 24px;
    color: #ffffff;
}
#sales.header .UserId { 
  float: right;
  color: #ffffff;
}
#sales.header .UserId a,#sales.header .UserId a:visited {
  color: #ffffff;
}
#sales.header .shoppingCartIcon { color: #FFFFFF; font-size: 20px; margin: 0px 30px -2px 10px; cursor: pointer;}
</style>
