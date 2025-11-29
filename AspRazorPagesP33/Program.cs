using AspRazorPagesP33.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IPersonDataProvider, PersonDataProvider>();

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

app.Run();

/*
 * Зробіть список Persons
 * 
 * Нова сторінка Razor Pages
 * Виведіть їх на сторінку у вигляді таблиці
 * Колонки: Id, Name, Опис, Email, День народження, Навички
 * 
 * 
 * Винести в окремий клас дані та логіку отримання даних
 * Реалізуйте інтерфейс IPersonDataProvider
 * 
 * 
 */ 