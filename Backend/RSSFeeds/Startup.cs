namespace RSSFeeds{

public class Startup {  
    // Use this method to add services to the container.  
    public void ConfigureServices(IServiceCollection services) {  
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCors(options => {

            options.AddDefaultPolicy(builder => {

                builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();


            });


        });
    }  

    // Use this method to configure the HTTP request pipeline.  
    public void Configure(IApplicationBuilder app) {  
        
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors();
        app.UseAuthorization();
        //app.MapControllers();

    }  
} 

}