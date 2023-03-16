using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) => {

    var words = @"
   █████  ███    ███  █████  ███████ ███████ ███████    ██  ██████      ██████   ██████   ██████ ██   ██ ███████     ██    ██  ██████  ██    ██
  ██   ██ ████  ████ ██   ██    ███  ██      ██         ██ ██    ██     ██   ██ ██    ██ ██      ██  ██  ██           ██  ██  ██    ██ ██    ██
  ███████ ██ ████ ██ ███████   ███   █████   █████      ██ ██    ██     ██████  ██    ██ ██      █████   ███████       ████   ██    ██ ██    ██
  ██   ██ ██  ██  ██ ██   ██  ███    ██      ██         ██ ██    ██     ██   ██ ██    ██ ██      ██  ██       ██        ██    ██    ██ ██    ██
  ██   ██ ██      ██ ██   ██ ███████ ███████ ███████ ██ ██  ██████      ██   ██  ██████   ██████ ██   ██ ███████        ██     ██████   ██████
  ";

    var path = "/app/words.txt";
    if (File.Exists(path)) {
        words = System.IO.File.ReadAllText(path);
    }

    var overridePath = "/app/words/words.override.txt";
    if (File.Exists(overridePath)) {
        words = System.IO.File.ReadAllText(overridePath);
    }

    context.Response.Headers["X-LAGOON"] = Environment.GetEnvironmentVariable("HOSTNAME");
    return words;
});

app.MapGet("/api", (HttpContext context) => {
  
    var words = @"amazee.io rocks you";

    var path = "/app/api.words.txt";
    if (File.Exists(path)) {
        words = System.IO.File.ReadAllText(path);
    }

    var overridePath = "/app/words/api.words.override.txt";
    if (File.Exists(overridePath)) {
        words = System.IO.File.ReadAllText(overridePath);
    }

    context.Response.Headers["X-LAGOON"] = Environment.GetEnvironmentVariable("HOSTNAME");

    var OWords = new WordyWords { words = words };

    string jsonString = JsonSerializer.Serialize(OWords);

    return jsonString;
});

app.Run();

class WordyWords
{
    public string? words { get; set; }
}
