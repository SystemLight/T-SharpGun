import {ComponentType} from "react";

// 路由类型文件定义
// 定义规范，type定义类型小写字母开头，结尾需要有Type进行命名
// 尽量使用接口进行类型定义，接口定义名称大写字母开头

export interface IRoutesBasic {
    key: string,
    title: string,
    path: string | Array<string>,
    exact?: boolean,
    component: ComponentType
}

export interface IParentRoutesBasic extends IRoutesBasic {
    subRoute?: Array<IRoutesBasic>
}

export type IRoutes = Array<IParentRoutesBasic>;

export interface IRouteViewProps {
    routes?: IRoutesBasic[]
}
