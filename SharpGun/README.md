# @systemlight/SharpGun

CSharp页面模板，包含各种中间件配置注释，需要按需使用

## 技术栈

#### 核心环境

- [x] dotnet core 5

#### 依赖包

- [ ] Microsoft.AspNetCore.SpaServices.Extensions
- [x] Swashbuckle.AspNetCore

## 注释规范

1. 代码块注释

```c#
#region 代码块说明

/*
    代码块内容
*/

#endregion
```

2. 功能解释注释

```c#
/*
    解释说明内容：
 */
```

3. 单行逻辑注释

```c#
// 功能说明
app.UseRouting();
```

## 目录结构

|  文件名   | 作用  |
|  :----  | :----  |
| Controllers  | 网络请求捕获控制 |
| Converts  | 转换映射处理 |
| Exceptions  | 异常处理 |
| Extensions  | 拓展原有方法，中间件等 |
| Filters  | MVC过滤拦截类 |
| Models  | 数据或业务模型 |
| Pages  | 独立Razor页面 |
| Services  | 服务类存放处 |
| Utils  | 实用工具类 |
| ViewModels  | 视图模型映射类 |
| Views  | MVC视图访问文件夹 |
| wwwroot  | 默认静态文件访问路径 |
| Program.cs  | 核心程序入口文件 |
| SharpGun.xml  | 配置文档生成后产生的说明文件 |
| Startup.cs  | 中间件注入，app启动配置文件 |
