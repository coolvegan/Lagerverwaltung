using System;
using System.Text.Json.Serialization;
using Marmelade.ApiKeyMiddleware;
using Marmelade.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DatenbankContext>(options =>
{
    options.UseSqlServer(conn);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Key Auth", Version = "v1" });
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "ApiKey muss im Header vorhanden sein.",
        Type = SecuritySchemeType.ApiKey,
        Name = "ApiKey",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });
    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
                { key, new List<string>() }
    };
    c.AddSecurityRequirement(requirement);
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ApiKeyMiddleware>();


app.MapGet("/Lagerort", async (DatenbankContext context, bool? zeigeLagerortInhalte) =>
{
    List<Lagerort> x;
    if (zeigeLagerortInhalte.HasValue && zeigeLagerortInhalte.Value == true)
    {
        x = await context.Lagerorte.Include(x => x!.Lagergegenstand).ToListAsync();
    } else
    {
        x = await context.Lagerorte.ToListAsync();
    }

    if (x == null) return Results.NotFound();
    List<LagerortDto> dtoList = new List<LagerortDto>();
    foreach(var item in x)
    {
        LagerortDto dto = new LagerortDto();
        dto = item;
        dtoList.Add(dto);
    }
    return Results.Ok(dtoList);
}).WithTags("Lagerort");

app.MapPost("/Lagerort", async (DatenbankContext context, LagerortCreateDto lagerortDto) =>
{
    var x = new Lagerort();
    x.Beschreibung = lagerortDto.Beschreibung;
    x.Name = lagerortDto.Name;
    await context.AddAsync(x);
    await context.SaveChangesAsync();
    return Results.Ok();
}).WithTags("Lagerort");

app.MapPut("/Lagerort/{id}", async (DatenbankContext context, LagerortCreateDto lagerortDto, int id) =>
{
    var x = await context.Lagerorte.FindAsync(id);
    x.Beschreibung = lagerortDto.Beschreibung;
    x.Name = lagerortDto.Name;
    context.Update(x);
    await context.SaveChangesAsync();
    return Results.Ok();
}).WithTags("Lagerort");

app.MapDelete("/Lagerort/{id}", async (int id, DatenbankContext context) =>
{
    var x = await context.Lagerorte.FindAsync(id);
    if (x == null) { return Results.StatusCode(StatusCodes.Status404NotFound); }
    context.Remove(x);
    await context.SaveChangesAsync();
    return Results.Ok();
}).WithTags("Lagerort");


app.MapGet("/Lagergegenstand", async (DatenbankContext context) =>
{
    var x = await context.Lagergegenstand.Include(x => x!.Lagerort).ToListAsync();
    if (x == null) return Results.NotFound();
    List<LagergegenstandDto> dtoList = new List<LagergegenstandDto>();
    foreach (var item in x)
    {
        LagergegenstandDto dto = new LagergegenstandDto();
        dto = item;
        dtoList.Add(dto);
    }
    return Results.Ok(dtoList);
}).WithTags("Lagergegenstand");

app.MapPost("/Lagergegenstand", async (DatenbankContext context, LagergegenstandCreateDto lagergegenstandDto) =>
{
    var x = new Lagergegenstand();
    x.LagerortId = lagergegenstandDto.LagerortId;
    x.Beschreibung = lagergegenstandDto.Beschreibung;
    x.Lagerzeitpunkt = lagergegenstandDto.Lagerzeitpunkt;
    x.Menge = lagergegenstandDto.Menge;
    x.Mengenbezeichner = lagergegenstandDto.Mengenbezeichner;
    x.Name = lagergegenstandDto.Name;
    await context.AddAsync(x);
    await context.SaveChangesAsync();
    return Results.Ok();
}).WithTags("Lagergegenstand");

app.MapPut("/Lagergegenstand/{id}", async (int id, DatenbankContext context, LagergegenstandCreateDto lagergegenstandDto) =>
{
    var x = await context.Lagergegenstand.FindAsync(id);
    if (x == null) { return Results.StatusCode(StatusCodes.Status404NotFound); }
    x.LagerortId = lagergegenstandDto.LagerortId;
    x.Beschreibung = lagergegenstandDto.Beschreibung;
    x.Lagerzeitpunkt = lagergegenstandDto.Lagerzeitpunkt;
    x.Menge = lagergegenstandDto.Menge;
    x.Mengenbezeichner = lagergegenstandDto.Mengenbezeichner;
    x.Name = lagergegenstandDto.Name;
    context.Update(x);
    await context.SaveChangesAsync();
    return Results.Ok();
}).WithTags("Lagergegenstand");

app.MapDelete("/Lagergegenstand/{id}", async (int id, DatenbankContext context) =>
{
    var x = await context.Lagergegenstand.FindAsync(id);
    if (x == null) { return Results.StatusCode(StatusCodes.Status404NotFound); }
    context.Remove(x);
    await context.SaveChangesAsync();
    return Results.Ok();
}).WithTags("Lagergegenstand");

app.Run();
