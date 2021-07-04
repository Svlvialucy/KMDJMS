import Vue from 'vue'
import Router from 'vue-router'
import Menu from '@/components/Menu'
import User from '@/components/User'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Menu',
      component: Menu
    },
    {
      path: '/User',
      name: 'User',
      component: User
    }
  ]
})
