using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Interfaz.StartupOwin))]

namespace Interfaz
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // ...

            services.AddControllersWithViews();

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ...

            app.UseStaticFiles(); // Agrega este middleware para servir archivos estáticos como las imágenes subidas

            // ...
        }
    }
}
