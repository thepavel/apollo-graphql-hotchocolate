using Odyssey.MusicMatcher;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy( builder => {
        builder
               .WithOrigins("https://studio.apollographql.com")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

app.MapGet("/", redirect => {
    redirect.Response.Redirect("/graphql");
    return Task.CompletedTask;
});
app.MapGraphQL();

app.Run();
