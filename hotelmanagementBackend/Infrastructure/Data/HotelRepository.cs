using Dapper;
using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Infrastructure.Data;

public class HotelRepository : IHotelRepository
{
    private readonly DapperContext _context;

    public HotelRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task AddHotelWithRatesAsync(Hotel hotel)
    {
        var queryHotel = @"INSERT INTO hotel (agency_id, hotel_name, hotel_address, hotel_email, hotel_contactno)
                           VALUES (@AgencyId, @HotelName, @HotelAddress, @HotelEmail, @HotelContactNo)
                           RETURNING hotel_id";

        var queryRate = @"INSERT INTO hotel_rate (hotel_id, rate_type, rate_price, start_date, end_date)
                          VALUES (@HotelId, @RateType, @RatePrice, @StartDate, @EndDate)";

        using var connection = _context.CreateConnection();
        using var transaction = connection.BeginTransaction();

        try
        {
            var hotelId = await connection.ExecuteScalarAsync<int>(queryHotel, hotel, transaction);

            foreach (var rate in hotel.HotelRates)
            {
                rate.HotelId = hotelId;
                await connection.ExecuteAsync(queryRate, rate, transaction);
            }

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
    
    public async Task UpdateHotelWithRatesAsync(Hotel hotel)
    {
        var updateHotel = @"UPDATE hotel SET 
                                agency_id = @AgencyId,
                                hotel_name = @HotelName,
                                hotel_address = @HotelAddress,
                                hotel_email = @HotelEmail,
                                hotel_contactno = @HotelContactNo
                            WHERE hotel_id = @HotelId";

        var deleteOldRates = @"DELETE FROM hotel_rate WHERE hotel_id = @HotelId";

        var insertRates = @"INSERT INTO hotel_rate (hotel_id, rate_type, rate_price, start_date, end_date)
                            VALUES (@HotelId, @RateType, @RatePrice, @StartDate, @EndDate)";

        using var connection = _context.CreateConnection();
        using var transaction = connection.BeginTransaction();

        try
        {
            await connection.ExecuteAsync(updateHotel, hotel, transaction);
            await connection.ExecuteAsync(deleteOldRates, new { hotel.HotelId }, transaction);

            foreach (var rate in hotel.HotelRates)
            {
                rate.HotelId = hotel.HotelId;
                await connection.ExecuteAsync(insertRates, rate, transaction);
            }

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task DeleteHotelAsync(int hotelId)
    {
        var deleteRates = @"DELETE FROM hotel_rate WHERE hotel_id = @HotelId";
        var deleteHotel = @"DELETE FROM hotel WHERE hotel_id = @HotelId";

        using var connection = _context.CreateConnection();
        using var transaction = connection.BeginTransaction();

        try
        {
            await connection.ExecuteAsync(deleteRates, new { HotelId = hotelId }, transaction);
            await connection.ExecuteAsync(deleteHotel, new { HotelId = hotelId }, transaction);

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<Hotel> GetHotelByIdAsync(int hotelId)
    {
        var hotelQuery = @"SELECT * FROM hotel WHERE hotel_id = @HotelId";
        var rateQuery = @"SELECT * FROM hotel_rate WHERE hotel_id = @HotelId";

        using var connection = _context.CreateConnection();

        var hotel = await connection.QuerySingleOrDefaultAsync<Hotel>(hotelQuery, new { HotelId = hotelId });

        if (hotel != null)
        {
            var rates = await connection.QueryAsync<HotelRate>(rateQuery, new { HotelId = hotelId });
            hotel.HotelRates = rates.ToList();
        }

        return hotel;
    }

    public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
    {
        var hotelQuery = @"SELECT * FROM hotel";
        var rateQuery = @"SELECT * FROM hotel_rate";

        using var connection = _context.CreateConnection();

        var hotels = (await connection.QueryAsync<Hotel>(hotelQuery)).ToList();
        var rates = await connection.QueryAsync<HotelRate>(rateQuery);

        foreach (var hotel in hotels)
        {
            hotel.HotelRates = rates.Where(r => r.HotelId == hotel.HotelId).ToList();
        }

        return hotels;
    }

}