using SH.Framework.Application;
using SH.Framework.Persistence.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddPersistenceSqlServerConfiguration(builder.Configuration);

var app = builder.Build();


app.UseHttpsRedirection();
app.UseApplicationLayer();
app.UsePersistenceSqlServerConfiguration();

app.Run();

