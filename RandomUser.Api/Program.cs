using RandomUser.Api;
using RandomUser.Api.Common.Api;
using RandomUser.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDataContext();
builder.AddCrossOrigin();
builder.AddHttpClients();
builder.AddDocumentation();
builder.AddServices();


var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(Configuration.CorsPolicyName);
app.MapEndpoints();

app.Run();