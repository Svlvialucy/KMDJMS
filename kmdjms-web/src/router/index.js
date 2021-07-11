import Vue from 'vue'
import Router from 'vue-router'
import Menu from '@/components/Menu'
import User from '@/components/User'
import HelloWord from '@/components/HelloWorld'
import WebLayout from '../views/Web/_Layout.vue'
Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      component: WebLayout,
      children: [
        {
          
          path: '',
          component: HomePage,
          meta: {
              title: 'Home',
              isLogin: false
          }
      }
        
      ]
    }
  ]
})


