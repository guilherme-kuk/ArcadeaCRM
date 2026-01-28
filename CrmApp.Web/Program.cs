using CrmApp.Application.Interfaces;
using CrmApp.Application.Services;
using CrmApp.Domain.Interfaces;
using CrmApp.Infrastructure.Data;
using CrmApp.Infrastructure.Repositories;
using CrmApp.Web.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CRM API",
        Version = "v1",
        Description = "Api CRM Arcadea",
        Contact = new OpenApiContact
        {
            Name = "Guilherme Kuk",
            Email = "guilhermekuk@gmail.com",
            Url = new Uri("https://github.com/guilherme-kuk")
        },
    });
});
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<CrmDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.UseCors("AllowAngular");

app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
