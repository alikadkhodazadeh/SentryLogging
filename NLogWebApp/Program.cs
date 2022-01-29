using NLog.Web;

#region WebHost
var builder = WebApplication.CreateBuilder(args);

#region Logging
builder.WebHost.ConfigureLogging(conf =>
{
    conf.AddSentry(opts =>
    {
        opts.Dsn = "https://1f5fb4e527e84b96a8fe2cef217c19d6@o1129954.ingest.sentry.io/6173894";
        opts.Debug = true;
    });
    conf.ClearProviders();
});

builder.Host.UseNLog();
#endregion

#endregion

#region Services
var services = builder.Services;

services.AddControllersWithViews();
#endregion

#region Middlewares
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#endregion