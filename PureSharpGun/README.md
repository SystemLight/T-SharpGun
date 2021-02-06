# PureSharpGun

纯净版的SharpGun .Net5 Web开发模板

## 技术栈

#### 核心环境

- [x] .Net5 (Sdk=Microsoft.NET.Sdk.Web)

#### 依赖包

- [ ] Microsoft.AspNetCore.SpaServices.Extensions
- [ ] Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
- [ ] Microsoft.AspNetCore.Mvc.NewtonsoftJson
- [ ] Microsoft.AspNet.WebApi.Versioning
- [ ] Microsoft.AspNet.WebApi.Versioning.ApiExplorer
- [ ] Microsoft.Extensions.Logging.Log4Net.AspNetCore
- [ ] Autofac.Extensions.DependencyInjection
- [x] Swashbuckle.AspNetCore
- [ ] System.Data.SqlClient

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
| Extensions  | 拓展原有方法，中间件等 |
| Misc  | 转换器，过滤器，异常处理，规则配置类，实用工具等 |
| Models  | 数据或业务模型 |
| Pages  | 独立Razor页面 |
| Services  | 服务类存放处 |
| ViewModels  | 视图模型映射类 |
| Views  | MVC视图访问文件夹 |
| wwwroot  | 默认静态文件访问路径 |
| Program.cs  | 核心程序入口文件 |
| Startup.cs  | 中间件注入，app启动配置文件 |

## 应用部署

#### Kestrel

```
dotnet publish

cd bin/Debug/net5.0/publish && <AppName>.exe
或
cd bin/Debug/net5.0/publish && dotnent <AppName>.dll --urls="http://*:5000" --ip="127.0.0.1" --port=5000
```

#### IIS

```
dotnet publish -c Release
cd bin/Debug/net5.0/publish
```
