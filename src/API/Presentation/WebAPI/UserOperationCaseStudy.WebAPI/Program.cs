using Autofac;
using Autofac.Extensions.DependencyInjection;
using UserOperationCaseStudy.Application;
using UserOperationCaseStudy.Common.Extensions;
using UserOperationCaseStudy.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(build =>
{
    build.RegisterModule(new ApplicationRegistrationModule());
    build.RegisterModule(new PersistenceRegistrationModule(builder.Configuration));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigurateCustomExceptionMiddleware();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
