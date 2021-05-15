using Clientele.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Clientele.Core.Services
{
    public class SqlQueryProvider : ISqlQueryProvider
    {
        private readonly IConfiguration _configuration;

        public SqlQueryProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetQueryByName(string queryName)
        {
            string path = _configuration["queryEmbeddedFilesPath"];

            if (string.IsNullOrWhiteSpace(queryName))
            {
                throw new ArgumentNullException($"Parameter {nameof(queryName)} cannot be empty.");
            }

            string resourceName = $"{path}.{queryName}.sql";

            var exists = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceNames()
                .Any(r => r == resourceName);

            if (!exists)
            {
                throw new FileNotFoundException($"No resource file '{queryName}' found at '{path}'");
            }

            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }
    }
}