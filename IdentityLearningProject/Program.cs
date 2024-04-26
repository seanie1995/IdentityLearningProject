
using IdentityLearningProject.Data;
using IdentityLearningProject.Handlers;
using IdentityLearningProject.Models;
using IdentityLearningProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

namespace IdentityLearningProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Database Connection

            string connectionString = builder.Configuration.GetConnectionString("ApplicationContext");

            

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

            // Code Below: Service needed to be able to add new users into database + optional requirements

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5; // <--- Example of optional requirement
            }).AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddScoped<IUserService, UserService>();
         
            builder.Services.AddControllers();
             
                     
            builder.Services.AddAuthorizationBuilder();

            

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
         
            app.UseHttpsRedirection();
          
            app.UseAuthorization();
           
            app.MapControllers();

            app.Run();
        }
    }
}

/* {
  "name": "Sean",
  "email": "sean@gmail.com",
  "password": "P@ssw0rd"
}
{
  "name": "Emilia",
  "email": "emi@gmail.com",
  "password": "w0rdP@ss"
}
*/

// ^ Premade Json to pass in Swagger.