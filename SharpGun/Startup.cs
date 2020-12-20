using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharpGun.Services;

namespace SharpGun
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) {
            #region 配置Kestrel服务器

            /*
                services.Configure<KestrelServerOptions>(options =>
                {
                    options.Listen(IPAddress.Any, 2222);
                });
            */

            #endregion

            #region 配置控制台生命周期

            /*
                services.Configure<ConsoleLifetimeOptions>(options =>
                {
                    // 抑制控制台消息输出
                    options.SuppressStatusMessages = false;
                });
            */

            #endregion

            #region 服务配置之后再进行配置注入

            /*
                services.PostConfigure<KestrelServerOptions>(options =>
                {
                    options.Listen(IPAddress.Any, 2222);
                });
            */

            #endregion

            // 尝试注册单例服务，如果已经注册将不注册，永不销毁
            // services.TryAddSingleton<IElvesRepositoryService, ElvesRepositoryService>();

            // 注册单例服务，永不销毁
            // services.AddSingleton<IElvesRepositoryService, ElvesRepositoryService>();
            // services.AddSingleton<IElvesRepositoryService>(new ElvesRepositoryService());
            // services.AddSingleton<IElvesRepositoryService>(provider => new ElvesRepositoryService());
            // services.AddSingleton(typeof(IElvesRepositoryService), typeof(ElvesRepositoryService));

            // 注册作用域服务，作用域内实例不销毁
            // services.AddScoped<IElvesRepositoryService, ElvesRepositoryService>();

            // 注册瞬时服务，每次请求都实例新的对象
            services.AddTransient<IElvesRepositoryService, ElvesRepositoryService>();

            // 注册目录浏览服务
            // services.AddDirectoryBrowser();

            // 将Controller所需的service添加注册到IOC容器，搭配endpoint.MapControllers()方法
            // services.AddControllers();

            // 将Controller所需的service添加注册到IOC容器，并包含Views视图的服务
            // services.AddControllersWithViews();

            // 添加Razor引擎服务处理视图，代替AddMvc方法
            // services.AddRazorPages();

            // 将MVC所需的service添加注册到IOC容器，搭配endpoint.MapControllerRoute()方法
            services.AddMvc();

            #region 禁用Endpoint路由以支持UseMvc()中间件

            /*
                services.AddMvc(option =>
                {
                    option.EnableEndpointRouting = false;
                });
            */

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            // 在Application级别获取依赖注入的服务，返回服务实例
            // app.ApplicationServices.GetService<IElvesRepositoryService>();

            // 关闭应用程序，关闭后程序进程退出
            // app.ApplicationServices.GetService<IHostApplicationLifetime>()?.StopApplication();

            if (env.IsDevelopment()) {
                // 使用异常页面显示错误信息，便于开发调试
                app.UseDeveloperExceptionPage();
            }
            else {
                // 注册开发环境异常处理错误路由重定向
                app.UseExceptionHandler("/error");

                // 将 HTTP 严格传输安全协议 (HSTS) 标头发送到客户端
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }

            #region 注册访问请求处理函数，Run方法注册会短路中间件通道，之后的中间件不会执行

            /*
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello Run!");
                });
            */

            #endregion

            #region 注册中间件并执行接下来的中间件

            /*
                app.Use(async (context, next) =>
                {
                    Console.WriteLine("Hello use");
                    await next();
                });
            */

            #endregion

            #region 当访问指定路由时，执行中间件注册

            /*
                app.Map("/map", appBuilder =>
                    {
                        appBuilder.Run(async context =>
                        {
                            await context.Response.WriteAsync("Hello Run!");
                        });
                    }
                );
            */

            #endregion

            #region 当函数返回True时，执行中间件注册

            /*
                app.MapWhen(context =>
                    {
                        return context.Request.Path.Value.StartsWith("/mapwhen");
                    }, appBuilder =>
                    {
                        appBuilder.Run(async context =>
                        {
                            Console.WriteLine("am");
                            //
                            await context.Response.WriteAsync("I am mapWhen !");
                        });
                    }
                );
            */

            #endregion

            // 注册http访问重定向到https访问
            // app.UseHttpsRedirection();

            // 启用验证功能
            // app.UseAuthentication();

            // 启用跨域访问
            // app.UseCors();

            // 启用路由中间件
            app.UseRouting();

            // 使用静态文件默认页配置，默认访问index.html，在UseStaticFiles()中间件之前启用
            app.UseDefaultFiles();

            // 启用静态文件访问，静态文件目录默认规定为wwwroot目录下
            app.UseStaticFiles();

            // 【弃用】使用MVC中间件，使用endpoint中MapControllerRoute()方法代替
            // app.UseMvc();

            // 【弃用】使用MVC默认配置中间件，使用endpoint中MapDefaultControllerRoute()方法代替
            // app.UseMvcWithDefaultRoute();

            // 使用路由端点中间件配置路由处理
            app.UseEndpoints(endpoints =>
            {
                #region 注册访问指定路由时处理的委托函数

                /*
                    endpoints.Map("/test", async context =>
                    {
                        await context.Response.WriteAsync("Hello Test!");
                    });
                */

                #endregion

                #region 注册使用GET方法访问指定路由时处理的委托函数

                /*
                    endpoints.MapGet("/", async context =>
                    {
                        await context.Response.WriteAsync("Hello World!");
                    });
                */

                #endregion

                // 只映射添加[Route("")]装饰的Controller类
                // endpoints.MapControllers();

                // 只映射RazorPages视图
                // endpoints.MapRazorPages();

                #region 映射MVC控制器路由，该方法代替了UseMvc()中间件

                /*
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}{id?}"
                    );
                */

                #endregion

                // 【语法糖】等效于上述的default配置
                endpoints.MapDefaultControllerRoute();

                #region 映射MVC区域路由，控制器中通过[Area("名称")]装饰区分区域

                /*
                    endpoints.MapAreaControllerRoute(
                        name: "areas", "areas",
                        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                */

                #endregion
            });
        }
    }
}
