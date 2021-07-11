import http from '../common/http-service'
import { WEBPREFIX } from '../common/api-config'

export default {
    AddUser(param: any, success: Function, failed?: Function): any {
        http.post('/api-common/Api/User/AddUser', param, success, failed)
      },
    Logout(param: any, success: Function, failed?: Function): any {
        http.get("/api-common/Api/User/Logout", param, success, failed)
      },
    Login(param: any, success: Function, failed?: Function): any {
        http.get('/api-common/Api/User/Login', param, success, failed)
      },
}