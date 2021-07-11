const path = require('path')
module.exports = {
    /* // web
    outputDir: 'dist', //build输出目录
    assetsDir: 'webres/assets', //静态资源目录（js, css, img）
    publicPath: process.env.NODE_ENV === 'production' ? '/' : '/', */
    /* outputDir: 'dist/customer', //build输出目录
    assetsDir: 'assets', //静态资源目录（js, css, img）
    publicPath: process.env.NODE_ENV === 'production' ? '/customer/' : '/', */
    /* outputDir: 'dist/sales', //build输出目录
    assetsDir: 'assets', //静态资源目录（js, css, img）
    publicPath: process.env.NODE_ENV === 'production' ? '/sales/' : '/', */
    // assetsDir: 'assets', //静态资源目录（js, css, img）
    // outputDir: process.env.VUE_APP_PROJECT === 'customer' ? 'dist/customer' : 'dist/sales', //build输出目录
    // publicPath: process.env.VUE_APP_PROJECT === 'customer' ? '/customer/' : '/sales/',
    // lintOnSave: false, //是否开启eslint
    // productionSourceMap: false, //发布去掉sourceMap，泄露源代码
    devServer: {
        open: false, //是否自动弹出浏览器页面
        host: "localhost",
        port: '8081',
        https: false, //是否使用https协议
        hotOnly: true, //是否开启热更新
        proxy: {
            '/api-common': {
                target: 'https://localhost:44328/', //API服务器的地址
                changeOrigin: true,
                pathRewrite: {
                    '^/api-common': '/'
                }
            },
        },
    }
}