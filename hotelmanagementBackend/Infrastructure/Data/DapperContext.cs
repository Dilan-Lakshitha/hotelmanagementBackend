using System.Data;
using Npgsql;

namespace hotelmanagementBackend.Infrastructure.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection() =>
            new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}