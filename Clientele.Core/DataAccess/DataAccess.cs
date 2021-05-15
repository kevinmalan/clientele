using Clientele.Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Clientele.Core.DataAccess
{
    public abstract class DataAccess
    {
        protected readonly SqlConnection sqlConnection;

        public DataAccess(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration["sqlConnectionString"]);
        }
    }
}