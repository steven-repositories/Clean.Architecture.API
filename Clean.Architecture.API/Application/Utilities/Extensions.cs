using Clean.Architecture.API.Application.Services;

namespace Clean.Architecture.API.Application.Utilities {
    public static class Extensions {
        public static bool IsNullOrEmpty(this object value) {
            return string.IsNullOrEmpty(value.ToString());
        }

        public static string FormatWith(this string pattern, params object[] values) {
            return string.Format(pattern, values);
        }

        public static async Task<string> ReadFileContent(this IFormFile file) {
            var stream = file.OpenReadStream();
            stream.Seek(0, SeekOrigin.Begin);

            var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        public static void ExecuteMigrations(this IHost host) {
            new MigrationService()
                .ExecuteMigrations(host);
        }
    }
}
