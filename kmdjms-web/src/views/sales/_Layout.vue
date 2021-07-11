<template>
  <a-layout id="KMDJ-Sales">
    <SalesHead></SalesHead>
    <a-layout>
      <SalesSideMenu></SalesSideMenu>
      <a-layout style="padding: 24px"  id="SalseContent">
        <a-layout-content
          :style="{ background: '#fff', padding: '24px', margin: 0 }"
        >
          <keep-alive>
            <router-view v-if="$route.meta.keepAlive"/>
          </keep-alive>
          <router-view v-if="!$route.meta.keepAlive"/>
        </a-layout-content>
      </a-layout>
    </a-layout>
    <ShoppingCart :FromWay="FromWay"></ShoppingCart>
  </a-layout>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
// import SalesHeader from '../../components/sales/shares/Header.vue'
</script>