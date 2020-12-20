# @systemlight/SharpGun

CSharp页面模板，包含各种中间件配置注释，需要按需使用

## 技术栈

#### 核心环境

- [ ] dotnet core 5

#### 依赖包

- [ ] Microsoft.AspNetCore.SpaServices.Extensions

## 目录结构

|  文件名   | 作用  |
|  :----  | :----  |
| Program.cs  | 核心程序入口文件 |
| Startup.cs  | 中间件注入，app启动配置文件 |

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
