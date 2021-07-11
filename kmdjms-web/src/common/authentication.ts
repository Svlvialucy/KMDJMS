import { Util } from "./util"
import { BASEURI } from "./api-config"
import userApi from "../api/user.api"
const isLogin: any = () => {
  return getCurrentUser() === null ? false : true;
};

const DynamsoftTokenCookieName = "KMDJToken";

const getCurrentUser: any = () => {
  let DynamsoftToken =  Util.getCookie(DynamsoftTokenCookieName);
  if (DynamsoftToken) {
    return {
      email: Util.getCookie("KMDJPhone"),
      role: Util.getCookie("KMDJRole"),
      token: DynamsoftToken,
      userId: Util.getCookie("KMDJUser"),
      username: Util.getCookie("KMDJUserName")
    }
  }
  return null;
};

const isSales: any = () => {
  let role = Util.getCookie("KMDJRole")
  if (role == 1 || role == 4) {
    return true
  }
  return false
}

const logOut: any = () => {
  userApi.Logout({
    token: Util.getCookie(DynamsoftTokenCookieName)
  }, (res: any) => {
    if (res.code == 0) {
      Util.delCookie("KMDJPhone")
      Util.delCookie("KMDJRole")
      Util.delCookie("KMDJToken")
      Util.delCookie("KMDJUser")
      Util.delCookie("KMDJUserName")
      window.location.href = BASEURI + '/Login/Login'
    }
  })
}

export default {
  isLogin,
  getCurrentUser,
  isSales,
  logOut
};
