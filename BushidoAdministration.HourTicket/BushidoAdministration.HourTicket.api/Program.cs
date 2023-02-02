using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Repositories;
using BushidoAdministration.HourTicket.api.Services;
using Microsoft.AspNetCore.StaticFiles;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add Log configuration
#region LOG
Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Debug()
	.WriteTo.Console()
	.WriteTo.File("logs/bushido_hourticket.txt", rollingInterval: RollingInterval.Day)
	.CreateLogger();

//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

builder.Host.UseSerilog();
#endregion

// Add services to the container.
#region SERVICES

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

// Add services to the container.
#region SERVICES
builder.Services
	.AddControllers(options =>
	{
		options.ReturnHttpNotAcceptable = true;
	})
	.AddNewtonsoftJson()
	.AddXmlDataContractSerializerFormatters();

builder.Services.AddSingleton<IContext, DbContext>();

//builder.Services.AddScoped<IActivityService, ActivityService>();
//builder.Services.AddScoped<IAttendenceService, AttendenceService>();
//builder.Services.AddScoped<IExtraAttendencyService, ExtraAttendencyService>();
//builder.Services.AddScoped<IExtraScheduleService, ExtraScheduleService>();
//builder.Services.AddScoped<IPaymentService, PaymentService>();
//builder.Services.AddScoped<IRegularScheduleService, RegularScheduleService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IAttendenceRepository, AttendenceRepository>();
builder.Services.AddScoped<IExtraAttendencyRepository, ExtraAttendencyRepository>();
builder.Services.AddScoped<IExtraScheduleRepository, ExtraScheduleRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IRegularScheduleRepository, RegularScheduleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region APP
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
#endregion