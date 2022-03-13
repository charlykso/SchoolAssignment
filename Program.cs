using HomeWork.Models;
using HomeWork.Repo;
using HomeWork.Services;
using Microsoft.EntityFrameworkCore;
using SchoolAssignment.Repo;
using SchoolAssignment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
