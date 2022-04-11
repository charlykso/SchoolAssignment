using System.Reflection.PortableExecutable;
using HomeWork.Models;
using HomeWork.Repo;
using HomeWork.Services;
using Microsoft.EntityFrameworkCore;
using SchoolAssignment.Repo;
using SchoolAssignment.Services;
using Newtonsoft.Json.Serialization;
// using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//for Jwt
// builder.Services.AddAuthentication(opt => 
// {
//     opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
//     .AddCookie(cfg => cfg.SlidingExpiration = true)
//     .AddJwtBearer(options => 
//     {
//         try
//         {
//             options.SaveToke  = true;
//             options.RequireHttpsMetadata = false;
//             options.TokenValidationParameters = new TokenValidationParameters
//             {
//                 ValidateIssuer = true
//             }
//         }
//         catch (System.Exception)
//         {
            
//             throw;
//         }
//     })

//for EF Core
builder.Services.AddDbContext<AssignmentContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AssignmentAppCon"));
});

builder.Services.AddScoped<IStudent, StudentServices>();
builder.Services.AddScoped<ILecturer, LecturerServices>();
builder.Services.AddScoped<IAssignment, AssignmentServices>();
builder.Services.AddScoped<ISubmission, SubmissionServices>();

builder.Services.AddMvc();
builder.Services.AddControllers();
// Learn more about configu ring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//JSON serializer
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
