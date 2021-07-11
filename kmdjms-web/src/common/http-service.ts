import Axios from 'axios'
import qs from 'qs'
import { BASEURI } from './api-config'
import { Util } from './util'

let headers:any = {
    'Content-Type': 'application/json'
  }
export default {
    get(url: string, params: JSON, success: Function, errorFunction?: Function) {
        // headers.DynamsoftToken = Util.getCookie('DynamsoftToken') ? Util.getCookie('DynamsoftToken') : ''
        // headers.DynamsoftUser = Util.getCookie('DynamsoftUser') ? Util.getCookie('DynamsoftUser') : ''
        Axios.get(url, { params, paramsSerializer: params => {
          return qs.stringify(params, { indices: false })
        }, headers }).then((response) => {
          this.handResult(response, success, errorFunction)
        }).catch((error) => {
          this.handleCatchError(error, errorFunction)
        })
      },
    
      post(url: string, params: JSON, success: Function, errorFunction?: Function, responseType?: any) {
        // headers.DynamsoftToken = Util.getCookie('DynamsoftToken') ? Util.getCookie('DynamsoftToken') : ''
        // headers.DynamsoftUser = Util.getCookie('DynamsoftUser') ? Util.getCookie('DynamsoftUser') : ''
        if (responseType) {
          headers.responseType = responseType
        }
        var Headparam: any = {
          headers: headers
        }
        if (responseType) {
          Headparam.responseType = responseType
        }
        Axios.post(url, params, Headparam).then((response) => {
          this.handResult(response, success, errorFunction, responseType)
        }).catch((error) => {
          this.handleCatchError(error, errorFunction)
        })
      },
}