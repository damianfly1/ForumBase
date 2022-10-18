using Application.Mappings;
using Application.Services;
using AutoMapper;
using Domain.Repositories;
using Persistance;
using Persistance.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ForumHubDBContext>();


//automapper
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});
IMapper autoMapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(autoMapper);

//services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IForumService, ForumService>();
builder.Services.AddScoped<ISubForumService, SubForumService>();
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<IPostService, PostService>();


//repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IForumRepository, ForumRepository>();
builder.Services.AddScoped<ISubForumRepository, SubForumRepository>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();


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
