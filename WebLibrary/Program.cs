

using Microsoft.OpenApi.Models;
using WebLibrary.API.Repositories;
using WebLibrary.API.Services;
using WebLibrary.Entities.Models;
using Microsoft.Extensions.Options;
using WebLibrary.Entities.Repositories;
using WebLibrary.Entities.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebLibrary API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
