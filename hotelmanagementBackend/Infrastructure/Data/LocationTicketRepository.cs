using Dapper;
using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Infrastructure.Data
{
    public class LocationTicketRepository : ILocationTicketRepository
    {
        private readonly DapperContext _context;

        public LocationTicketRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddLocationTicketAsync(LocationTicket ticket)
        {
            var sql = @"INSERT INTO LocationTicket (location_name, description, adult_price, child_price, agency_id)
                    VALUES (@LocationName, @Description, @AdultPrice, @ChildPrice, @AgencyId)
                    RETURNING location_ticket_id";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, ticket);
        }

        public async Task<IEnumerable<LocationTicket>> GetAllTicketsAsync()
        {
            var sql = "SELECT * FROM LocationTicket";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<LocationTicket>(sql);
        }

        public async Task<LocationTicket> GetTicketByIdAsync(int id)
        {
            var sql = "SELECT * FROM LocationTicket WHERE location_ticket_id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<LocationTicket>(sql, new { Id = id });
        }

        public async Task<bool> UpdateLocationTicketAsync(LocationTicket ticket)
        {
            var sql = @"UPDATE LocationTicket
                    SET location_name = @LocationName, description = @Description,
                        adult_price = @AdultPrice, child_price = @ChildPrice
                    WHERE location_ticket_id = @LocationTicketId";

            using var connection = _context.CreateConnection();
            var rows = await connection.ExecuteAsync(sql, ticket);
            return rows > 0;
        }

        public async Task<bool> DeleteLocationTicketAsync(int id)
        {
            var sql = "DELETE FROM LocationTicket WHERE location_ticket_id = @Id";
            using var connection = _context.CreateConnection();
            var rows = await connection.ExecuteAsync(sql, new { Id = id });
            return rows > 0;
        }
    }
}