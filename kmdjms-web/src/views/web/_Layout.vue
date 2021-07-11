<template>
  <a-layout id="Web">
    <a-layout-header v-if="!PRERENDER&&!($route.meta.productId&&$route.meta.isLogin)"><WebHead></WebHead></a-layout-header>
    <a-layout-content>
      <keep-alive>
        <router-view v-if="$route.meta.keepAlive"/>
      </keep-alive>
      <router-view v-if="!$route.meta.keepAlive"/>
    </a-layout-content>
    <a-layout-footer v-if="!PRERENDER&&!($route.meta.productId&&$route.meta.isLogin)"><WebFooter></WebFooter></a-layout-footer>
    <cookieconsent v-if="showCookie"></cookieconsent>
  </a-layout>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { Util } from "../../common/util";
// import WebHead from '../../components/Web/Shares/Header.vue'
// import WebFooter from '../../components/Web/Shares/Footer.vue'
// import cookieconsent from '../../components/common/cookieconsent.vue'
import Axios from "axios"
import userApi from '../../api/user.api'

// @Component({
//     name: 'WebLayout',
//     components: { WebHead, WebFooter, cookieconsent }
// })

export default class WebLayout extends Vue {
  showCookie: boolean = false
  PRERENDER: any = null
  productId: any = null

//   created() {
//     this.PRERENDER = (window as any).__PRERENDER_INJECTED === 'prerender'
//     let route: any = this.$router
//     if (route.history.current.meta && route.history.current.meta.productId) {
//       this.productId = route.history.current.meta.productId
//     }
//     this.NeedCookieConsent()
//   }

//   NeedCookieConsent() {
//     let _this  = this
//     userApi.getUserLocation({}, (res: any) => {
//       if (res.code == 0) {
//         // if (res.data.country == 'Iran'|| res.data.country == "Libyan Arab Jamahiriya" || res.data.country=='Somalia' || res.data.country == 'Zimbabwe' || res.data.country == 'Crimea' ) {
//         //   window.location.href = 'https://www.dynamsoft.com/PageNotFound.aspx'
//         // }
//         if (res.data.continent == 'North America') {
//           let visit = Util.getCookie('cookie-alert') || Util.getCookie('DSCookieCompliancyAccepted')
//           if (!visit) { 
//             _this.showCookie = true
//           } else {
//             _this.showCookie = false
//           }
//         } else {
//           _this.showCookie = false
//         }
//       }
//     })
//   }
}
</script>

<style>
/* @import "../../assets/Web/css/site_basic.css";
@import "../../assets/Web/css/basic_style.css";
@import "../../assets/Web/css/header_bs.css";
#Web .ant-layout-content {
  min-height: calc(100vh - 130px)!important
} */
</style>

