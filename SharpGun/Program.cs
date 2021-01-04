using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SharpGun
{
    public static class Program
    {
        private static IHostBuilder CreateHostBuilder(string[] args) {
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
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // 指定监听地址和端口号
                    // webBuilder.UseUrls("http://0.0.0.0:8001");

                    // 将所有配置项通过该泛型类Startup映射
                    webBuilder.UseStartup<Startup>();
                });
        }

        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }
    }
}
