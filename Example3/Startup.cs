using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ООP_Laba4.Managers.Events;
using ООP_Laba4.Managers.Participants;
using ООP_Laba4.Managers.Sports;
using ООP_Laba4.Storage.Migrations;

namespace ООP_Laba4
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;
        public Startup(IWebHostEnvironment hostEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostEnvironment.ContentRootPath).AddJsonFile("EventsDbSetting.json").Build();
            // Интерфейс IWebHostEnvironment - Предоставляет информацию о среде веб-хостинга, в которой запущено приложение.
            // ContentRootPath: возвращает путь к корневой папке приложения
            // Интерфейс IConfigurationBuilder - представляет тип, используемый для построения конфигурации приложения.
            // Метод SetBasePath() - Задает FileProvider для поставщиков на основе файлов равным PhysicalFileProvider с базовым путем.
            // Метод AddJsonFile() - Добавляет источник конфигурации JSON в builder.
            // Метод Buid() - Создает IConfiguration с ключами и значениями на основе набора источников, зарегистрированных в Sources.
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SportEventsDataContext>(options => options.UseSqlServer(_configurationRoot.GetConnectionString("SportEventsDb")));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddTransient<IEventManager, EventManager>();
            services.AddTransient<ISportManager, SportManager>();
            services.AddTransient<IParticipantManager, ParticipantManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseRequestLocalization();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Event}/{action=Index}/{id?}/{SportId?}/{PaticipantId?}");
            });
        }
    }
}
