using EventPlanning.Control;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddDbContextPool<AppDBContext>(options =>
{
    //options.UseSqlServer("server=1C-SQL;database=EventPlanning;User ID=sa;Password=90Azedan; TrustServerCertificate=true",providerOptions => providerOptions.EnableRetryOnFailure(5))
    options.UseSqlite(@"Data Source=DataBase.db;");
});
builder.Services.AddScoped<IRepozitory, IRepozitorySQLite>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();