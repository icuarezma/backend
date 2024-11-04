using backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{ 
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    //builder.Services.AddCors(o => o.AddPolicy("policy", builder =>
    //{
    //    builder.AllowAnyOrigin()
    //           .AllowAnyMethod()
    //           .AllowAnyHeader();
    //}));
}

builder.Services.AddDbContext<IsucorpdbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnect")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontAngular", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors("FrontAngular");
    //app.UseCors("policy");
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
