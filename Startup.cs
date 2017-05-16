using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using dotnetTest.Repository;

namespace dotnetTest
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            //app.Run(async (context) => {
            //    await context.Response.WriteAsync("Hello world!!!\n");
            //});
            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMonsterRepository, MonsterRepository>();
            services.AddMvc();
        }
    }
}