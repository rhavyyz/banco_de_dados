using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using Repositories.Interfaces;
using Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseNpgsql( builder.Configuration.GetConnectionString("default"))
);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICategotyRepository, CategoryRepository>();
builder.Services.AddScoped<ICollaborationRepository, CollaborationRepository>();
builder.Services.AddScoped<ICollaborationPermissionRepository, CollaborationPermissionRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();
builder.Services.AddScoped<IUserPermissionRepository, IUserPermissionRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

// builder.Services.AddScoped<>

// Add services to the container.

builder.Services.AddControllers();

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
// Console.WriteLine(app.Configuration.GetConnectionString("rhavy"));
// app.Configuration.GetConnectionString("rhavy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
