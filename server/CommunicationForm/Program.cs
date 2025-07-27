using CommunicationForm.Application.Services;
using CommunicationForm.DataAccess;
using CommunicationForm.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Form
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CommunicationFormDbContext>(
                options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(CommunicationFormDbContext)));
                });

            // cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });


            // DI
            //builder.Services.AddScoped<IContactsService, ContactsService>();
            //builder.Services.AddScoped<IContactsRepository, ThemesRepository>();

            builder.Services.AddScoped<IMessagesService, MessagesService>();
            builder.Services.AddScoped<IMessagesRepository, MessagesRepository>();

            builder.Services.AddScoped<IThemesService, ThemesService>();
            builder.Services.AddScoped<IThemesRepository, ThemesRepository>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
