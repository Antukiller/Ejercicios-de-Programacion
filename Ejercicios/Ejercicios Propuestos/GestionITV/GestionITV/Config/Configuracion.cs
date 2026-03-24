using System.Globalization;
using System.Runtime.InteropServices;

namespace GestionITV.Config;

public static class Configuracion {
    private static readonly IConfiguracion Config;

    static Configuracion() {
        Config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }

    public static CultureInfo Locale => CultureInfo.GetCultureInfo("es-Es");

    public static string StorageType => Config.GetValue<string>("Storage:Type") ?? "json";

    public static string RepositoryType {
        get {
            var type = Config.GetValue<string>("Repository:Type") ?? "memory";

            return type.ToLower() switch {
                "memory" => "memory",
                "binary" => "binary",
                "json" => "json",
                _ => "memory"
            };
            return Path.Combine(DataFolder, $"academia.{extension}");
        }
    }

    public static string BackupFormat {
        get {
            var format = Config.GetValue<string>("Backup:Format") ?? "json";
            return format.ToLower() switch {
                "json" => "json",
                "xml" => "xml",
                "csv" => "csv",
                "bin" => "bin"
                _ => "json"
            };
        }
    }
}