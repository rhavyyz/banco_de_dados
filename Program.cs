using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using Repositories.Interfaces;
using Repositories;
using Controllers.Constrains;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseNpgsql( builder.Configuration.GetConnectionString("default"))
);

// builder.Services.Configure<RouteOptions>(options => options.ConstraintMap.Add("", typeof(IRouteConstraint)));

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICollaborationRepository, CollaborationRepository>();
builder.Services.AddScoped<ICollaborationPermissionRepository, CollaborationPermissionRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();
builder.Services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();


// builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<ICommentService, CommentService>();
// builder.Services.AddScoped<ICategoryService, CategoryService>();
// builder.Services.AddScoped<ICollaborationService, CollaborationService>();
// builder.Services.AddScoped<ICollaborationPermissionService, CollaborationPermissionService>();
// builder.Services.AddScoped<ILikeService, LikeService>();
// builder.Services.AddScoped<IUserPermissionService, UserPermissionService>();
// builder.Services.AddScoped<IPostService, PostService>();



// builder.Services.AddScoped<>

// Add services to the container.

builder.Services.AddControllers();


// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
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
// app.MapControllerRoute(
//     name: "user",
//     pattern: "",
//     constraints: typeof(AuthNotPermitedConstraintAttribute)
// );

// app.MapFallbackToController

app.Run();
