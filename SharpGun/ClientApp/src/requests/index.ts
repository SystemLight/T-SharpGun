import axios from "axios";

export const req = axios.create({
    baseURL: "/"
});

// 用户身份鉴权，通过axios响应拦截器，当一个返回权限错误[403]
// 取消所有请求，并跳转到/login地址，强制让用户登录
