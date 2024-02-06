
using System.Text.Json.Serialization;
using ClosedXML.Excel;
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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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


builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder => {
    builder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin();
}));

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
app.UseMiddleware<LoginMiddleWare>();

app.UseMiddleware<ApiKeyMiddleware>();
app.UsePathBase(new PathString("/api"));
app.UseRouting();

//app.Urls.Add("http://0.0.0.0:5218");

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
    var lagerort = new Lagerort();
    lagerort.Beschreibung = lagerortDto.Beschreibung;
    lagerort.Name = lagerortDto.Name;
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


app.MapGet("/Lagergegenstand", async (DatenbankContext context, string? nameStartsWith, string? nameHasSubstring, string? lagerOrt) =>
{
    List<Lagergegenstand> lgs = null;
    if (nameStartsWith?.Length >= 0)
    {
        lgs = await context.Lagergegenstand.Where(v => EF.Functions.Like(v.Name, $"{nameStartsWith}%")).Include(x => x!.Lagerort).ToListAsync();
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
                lgs = await context.Lagergegenstand.Where(v => EF.Functions.Like(v.Name, $"%{anString}%")).Where(v => v.Menge > result).Include(x => x!.Lagerort).ToListAsync();
            }

        } else if (nameHasSubstring.Contains("<"))
        {
            int idx = nameHasSubstring.IndexOf("<");
            var anString = nameHasSubstring.Substring(0, idx);
            var endString = nameHasSubstring.Substring(idx + 1);
            bool istZahl = int.TryParse(endString, out int result);
            if (istZahl)
            {
                lgs = await context.Lagergegenstand.Where(v => EF.Functions.Like(v.Name, $"%{anString}%")).Where(v => v.Menge < result).Include(x => x!.Lagerort).ToListAsync();
            }
        }

        else
        {
            lgs = await context.Lagergegenstand.Where(v => EF.Functions.Like(v.Name, $"%{nameHasSubstring}%")).Where(v => v.Menge > 50).Include(x => x!.Lagerort).ToListAsync();
        }
    } else if(lagerOrt?.Length >= 0){
        lgs = await context.Lagergegenstand.Where(v => EF.Functions.Like(v.Lagerort.Name, $"%{lagerOrt}%")).Include(x => x!.Lagerort).ToListAsync();
    }
    else
    {
        lgs = await context.Lagergegenstand.Include(x => x!.Lagerort).ToListAsync();
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

app.MapPost("/upload", async (IFormFile file) =>
{
    // Your logic for processing the file goes here
    string tempfile = CreateTempfilePath();
    using var stream = File.OpenWrite(tempfile);
    await file.CopyToAsync(stream);

    // Do more fancy stuff with the IFormFile
}).WithMetadata(new Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute());

static string CreateTempfilePath()
{
    var filename = $"{Guid.NewGuid()}.tmp";
    var directoryPath = Path.Combine("temp", "uploads");
    if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

    return Path.Combine(directoryPath, filename);
}

app.MapPost("/Login", async (DatenbankContext context, User user, ILoginService cSRF) =>
{
    if (user.Username == "paul" && user.Password == "11dänemark")
    {
        return Results.Ok(cSRF.GenerateAndRegisterCsrfToken());
    }

    return Results.Unauthorized();
});

app.MapGet("/word", async (DatenbankContext context) =>
{
    Dictionary<string, List<string>> keyValuePairs = new Dictionary<String, List<String>>();
    List<Lagergegenstand> lg = await context.Lagergegenstand.Include(x => x.Lagerort).OrderBy(y => y.Name).ToListAsync();

    foreach(var item in lg)
    {
        List<string> valueList;
        keyValuePairs.TryGetValue(item.Name.Trim(), out valueList);
        if(valueList == null)
        {
            valueList = new List<String>();
            keyValuePairs.Add(item.Name.Trim(), valueList);
        }
    
        var month = item.Lagerzeitpunkt.Month.ToString();
        var year = item.Lagerzeitpunkt.Year.ToString().Substring(2);

        if (month.Length == 1)
        {
            month = "0" + month;
        }
        var day = item.Lagerzeitpunkt.Day.ToString();
        if (day.Length == 1)
        {
            day = "0" + day;
        }
        valueList.Add(item.Menge + " " + item.Lagerort.Name + "\n" + month + "." + year);
    };

    var wb = new XLWorkbook();
    var ws = wb.Worksheets.Add("Blatt1");
    var row = 1;
    ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
    var columnA = ws.Column(1);
    columnA.Style.Font.Bold = true;
    columnA.Style.Font.FontSize = 12;
    columnA.Width = 30;
    foreach (var item in keyValuePairs)
    {
        var key = item.Key;
        var col = 1;
        ws.Cell(row, 1).SetValue(key);
        col++;
        for(int i = 0; i < item.Value.Count; i++)
        {
            if (i % 6 == 0 && i !=0)
            {
                row++;
                ws.Cell(row, 1).SetValue(key);
            }
            ws.Cell(row, (i%6)+2).SetValue(item.Value.ElementAt<string>(i));
        }
        row++;
    }
    string result;
    using (MemoryStream memoryStream = new MemoryStream())
    {
        wb.SaveAs(memoryStream);
        result = Convert.ToBase64String(memoryStream.ToArray());
    }
    return Results.Ok<Excel>(new Excel { Base64 = result});
});


app.Run();

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class Excel
{
    public string Base64 { get; set; }
}