using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

/*
    执行内容：
       1. 加载主机和应用程序配置信息
       2. 配置日志记录
       3. 设置web服务器
       4. 设置dotnet core的托管形式

    可配置方法：
       1. ConfigureWebHostDefaults
       2. ConfigureHostConfiguration
       3. ConfigureAppConfiguration
       4. ConfigureServices

    额外配置：
       1. ConfigureLogging

    第三方拓展：
       1. UseServiceProviderFactory
*/
Host
    .CreateDefaultBuilder(args)
    /*
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            // 应用程序读取的环境变量增加前缀约束
            config.AddEnvironmentVariables(prefix: "MyCustomPrefix_");
        })
    */
    .ConfigureWebHostDefaults(webBuilder =>
    {
        // 指定监听地址和端口号
        // webBuilder.UseUrls("http://0.0.0.0:8001");

        // 将所有配置项通过该泛型类Startup映射
        webBuilder.UseStartup<SharpGun.Startup>();
    })
    // 使用Autofac第三方依赖注入容器
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .Build().Run();
