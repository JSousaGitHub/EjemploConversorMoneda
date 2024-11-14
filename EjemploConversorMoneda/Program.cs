// Desarrolla una aplicación web de conversión de divisa utilizando cualquier API gratuito de conversión.
// Se va a utilizar la api ExchangeRate-API
// La url base de la API es https://api.exchangerate-api.com/v4/latest/USD
// La API proporciona la tasa de cambio de USD a otras monedas.
// https://app.exchangerate-api.com/dashboard para obtener una clave de API gratuita.
// La clave de la API se debe incluir en la solicitud de la API en la cabecera de la solicitud.
// La clave API es: 4b98ce431c662ac85c443184
// La página web principal de la aplicación solicitará al usuario que introduzca un importe,
// la divisa de origen y la divisa de destino
// y deberá devolver el resultado de la conversión utilizando el cambio correspondiente
// a la fecha y hora del momento en el que se realiza la petición. 
// Almacenamiento y consulta de las últimas consultas (historial) 
// En la pantalla principal también se mostrarán las 10 últimas consultas realizadas y sus resultados. 
// El usuario puede ver la lista de monedas y seleccionar una de ellas para editar su contenido.





using EjermploConversorMoneda.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


//----------------------------------------------- 
//     SERVICOS – CONFIGURACIÓN
//-----------------------------------------------
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Agregamos el servico para la comunicación Http
builder.Services.AddHttpClient();

// Agregamos el servico para la conversión de moneda
builder.Services.AddScoped<CurrencyConverterService>();

// Agregamos el servicio para la comunicación con la base de datos
builder.Services.AddDbContext<CurrencyQueryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agrega servicios de Entity Framework Core a la aplicacion
builder.Services.AddDbContext<ApplicationDbContext>(options => {

        // Configura la cadena de conexion
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);



//----------------------------------------------- 
//     MIDDLEWARE – CONFIGURACIÓN
//-----------------------------------------------
var app = builder.Build();

using(var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CurrencyQueryDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();




//----------------------------------------------- 
//     APP - CONSTRUCCIÓN EJECUCIÓN
//-----------------------------------------------
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
