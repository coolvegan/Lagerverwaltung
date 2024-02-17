
using System.Text.Json.Serialization;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using Marmelade.Api.Services;
using Marmelade.ApiKeyMiddleware;
using Marmelade.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using String = System.String;

var builder = WebApplication.CreateBuilder(args);
var corsAllowServer = builder.Configuration.GetValue<String>("CorsAllowServer");
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DatenbankContext>(options =>
{
    options.UseSqlServer(conn);
});



builder.Services.AddEndpointsApiExplorer();

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

    c.AddSecurityDefinition("Login", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        Name = "Security",
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

    var key2 = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Login"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
                { key, new List<string>() },
                { key2, new List<string>() }
    };
    c.AddSecurityRequirement(requirement);
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddSingleton<ILoginService>(provider => new LoginService());
builder.Services.AddScoped<IExcelGenerator>(provider => new ExcelGenerator());

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder => {
    builder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin();
}));
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

var app = builder.Build();
app.UseCors(x => x
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .WithOrigins(corsAllowServer).AllowAnyHeader());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSession();

app.UseMiddleware<LoginMiddleWare>();
app.UseMiddleware<ApiKeyMiddleware>();
app.UsePathBase(new PathString("/api"));
app.UseRouting();

//app.Urls.Add("http://0.0.0.0:5218");
app.MapGet("/Lagerort", async (HttpContext ctx, DatenbankContext context, bool? zeigeLagerortInhalte) =>
{
    List<Lagerort> x;
    var username = ctx.Session.GetString("Username");
    if (zeigeLagerortInhalte.HasValue && zeigeLagerortInhalte.Value == true)
    {
        x = await context.Lagerorte.Include(x => x!.Lagergegenstand).Where(b => b.Benutzer!.Name == username).ToListAsync();
    } else
    {
        x = await context.Lagerorte.Where(b => b.Benutzer!.Name == username).ToListAsync();
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

app.MapPost("/Lagerort", async (HttpContext ctx, DatenbankContext context, LagerortCreateDto lagerortDto) =>
{
    var username = ctx.Session.GetString("Username");
    var dbUser = await context.Benutzer.Where(b => b.Name == username).FirstAsync();
    if(dbUser == null)
    {
        return Results.Forbid();
    }
    var lagerort = new Lagerort();
    lagerort.Beschreibung = lagerortDto.Beschreibung;
    lagerort.Name = lagerortDto.Name;
    lagerort.BenutzerId = dbUser.Id;
    await context.AddAsync(lagerort);
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


app.MapGet("/Lagergegenstand", async (HttpContext ctx, DatenbankContext context, string? nameStartsWith, string? nameHasSubstring, string? lagerOrt) =>
{
    var username = ctx.Session.GetString("Username");
    List<Lagergegenstand> lgs = null;
    if (nameStartsWith?.Length >= 0)
    {
        lgs = await context.Lagergegenstand.Where(v => EF.Functions.Like(v.Name, $"{nameStartsWith}%")).Include(x => x!.Lagerort).Where(b => b.Benutzer!.Name == username).ToListAsync();
    } else if (nameHasSubstring?.Length >= 0)
    {
        if (nameHasSubstring.Contains(">"))
        {
            int idx = nameHasSubstring.IndexOf(">");
            var anString = nameHasSubstring.Substring(0, idx);
            var endString = nameHasSubstring.Substring(idx + 1);
            bool istZahl = int.TryParse(endString, out int result);
            if (istZahl)
            {
                lgs = await context.Lagergegenstand.Where(v => EF.Functions.Like(v.Name, $"%{anString}%")).Where(v => v.Menge > result).Include(x => x!.Lagerort).Where(b => b.Benutzer!.Name == username).ToListAsync();
            }

        } else if (nameHasSubstring.Contains("<"))
        {
            int idx = nameHasSubstring.IndexOf("<");
            var anString = nameHasSubstring.Substring(0, idx);
            var endString = nameHasSubstring.Substring(idx + 1);
            bool istZahl = int.TryParse(endString, out int result);
            if (istZahl)
            {
                lgs = await context.Lagergegenstand.Where(v => EF.Functions.Like(v.Name, $"%{anString}%")).Where(v => v.Menge < result).Include(x => x!.Lagerort).Where(b => b.Benutzer!.Name == username).ToListAsync();
            }
        }
        else
        {
            lgs = await context.Lagergegenstand.Where(v => EF.Functions.Like(v.Name, $"%{nameHasSubstring}%")).Where(v => v.Menge > 50).Include(x => x!.Lagerort).Where(b => b.Benutzer!.Name == username).ToListAsync();
        }
    } else if(lagerOrt?.Length >= 0){
        lgs = await context.Lagergegenstand.Where(v => EF.Functions.Like(v.Lagerort.Name, $"%{lagerOrt}%")).Include(x => x!.Lagerort).Where(b => b.Benutzer!.Name == username).ToListAsync();
    }
    else
    {
        lgs = await context.Lagergegenstand.Include(x => x!.Lagerort).Where(b => b.Benutzer!.Name == username).ToListAsync();
    }

    if (lgs == null) return Results.NotFound();

    List<LagergegenstandDto> dtoList = new List<LagergegenstandDto>();
    foreach (var item in lgs)
    {
        LagergegenstandDto dto = new LagergegenstandDto();
        dto = item;
        dtoList.Add(dto);
    }
    return Results.Ok(dtoList);
}).WithTags("Lagergegenstand");

app.MapPost("/Lagergegenstand", async (HttpContext ctx, DatenbankContext context, LagergegenstandCreateDto lagergegenstandDto) =>
{
    var username = ctx.Session.GetString("Username");
    var dbUser = await context.Benutzer.Where(b => b.Name == username).FirstAsync();
    if (dbUser == null)
    {
        return Results.Forbid();
    }
    var x = new Lagergegenstand();
    x.LagerortId = lagergegenstandDto.LagerortId;
    x.Beschreibung = lagergegenstandDto.Beschreibung;
    x.Lagerzeitpunkt = lagergegenstandDto.Lagerzeitpunkt;
    x.Menge = lagergegenstandDto.Menge;
    x.Mengenbezeichner = lagergegenstandDto.Mengenbezeichner;
    x.Name = lagergegenstandDto.Name;
    x.BenutzerId = dbUser.Id;
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


static string CreateTempfilePath()
{
    var filename = $"{Guid.NewGuid()}.tmp";
    var directoryPath = Path.Combine("temp", "uploads");
    if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

    return Path.Combine(directoryPath, filename);
}

app.MapPost("/Login", async (DatenbankContext context, User user, ILoginService cSRF) =>
{
    var userList = await context.Benutzer.Where(b => b.Name == user.Username).ToListAsync();
    if(userList.Count == 0)
    {
        return Results.Unauthorized();
    }
    if (userList.First().Password == Benutzer.GetPassword(user.Password))
    {
        return Results.Ok(cSRF.GenerateAndRegisterCsrfToken(user.Username));
    }
    return Results.Unauthorized();
});


app.MapGet("/Excel", async (HttpContext ctx, DatenbankContext context, IExcelGenerator excelGenerator) =>
{
    var username = ctx.Session.GetString("Username");
    List<Lagergegenstand> lg = await context.Lagergegenstand.Include(x => x.Lagerort).Where(b => b.Benutzer!.Name == username).OrderBy(y => y.Name).ToListAsync();
    XLWorkbook wb = excelGenerator.Create(lg);

    string result;
    using (MemoryStream memoryStream = new MemoryStream())
    {
        wb.SaveAs(memoryStream);
        result = Convert.ToBase64String(memoryStream.ToArray());
    }
    return Results.Ok<Excel>(new Excel { Base64 = result });
});

app.MapGet("/Tokenpruefung", async (DatenbankContext context, string token, ILoginService loginService) =>
{
    if (loginService.IsTokenValid(token))
    {
    Results.Ok(new TokenHealth { Result = true});
    }
    Results.NotFound(new TokenHealth { Result = false});
});

app.MapGet("/Alive", async () =>
{
    return Results.Ok();
});

app.MapGet("Excel/Import", async(HttpContext ctx, DatenbankContext context) =>
{
    var username = ctx.Session.GetString("Username");
    var dbUser = await context.Benutzer.Where(b => b.Name == username).FirstAsync();
    if (dbUser == null)
    {
        return Results.Forbid();
    }
    try
    {
        ExcelImport excelImport = new ExcelImport(context, dbUser.Id);
        excelImport.Start();
    }
    catch(Exception e)
    {
        return Results.Problem(e.ToString());
    }

    return Results.Ok();
});


app.Run();


public class User
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class Excel
{
    public required string Base64 { get; set; }
}

public class Token
{
    public required string Data { get; set; }
}

public class TokenHealth
{
    public bool Result { get; set; }
}
