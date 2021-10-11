using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // добовляем поддержку контроллеров и представлений (mvc) 
            services.AddControllersWithViews()
                //выставляем совместимость с asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {//порядок подклбчения middleware очень важно
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // вывод подробной инфы при ошибках ,если в разработке
            }
            app.UseRouting();
            //подчключаем поддержку статичных файлов в приложении(css,js  ит.д.)
            app.UseStaticFiles();
            //регистрируем нужные маршруты (ендпоинты)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
