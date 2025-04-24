using System.Data;
using Dapper;
using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using Npgsql;

namespace hotelmanagementBackend.Infrastructure.Data;

public class HotelRepository : IHotelRepository
{
    private readonly DapperContext _context;

    public HotelRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Hotel> AddHotelWithRates(Hotel hotel)
    {
        var queryHotel = @"INSERT INTO hotel (agency_id, hotel_name, hotel_address, hotel_email, hotel_contactno)
                       VALUES (@agency_id, @hotel_name, @hotel_address, @hotel_email, @hotel_contactno)
                       RETURNING hotel_id";

        var queryRate = @"INSERT INTO hotel_rate (hotel_id, rate_type, rate, start_date, end_date)
                      VALUES (@hotel_id, @rate_type, @rate, @start_date, @end_date)";

        using var connection = (NpgsqlConnection)_context.CreateConnection();
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        using var transaction = connection.BeginTransaction();

        try
        {
            var hotelId = await connection.ExecuteScalarAsync<int>(queryHotel, hotel, transaction);
            hotel.hotel_id = hotelId;

            foreach (var rate in hotel.HotelRates)
            {
                rate.hotel_id = hotelId;
                await connection.ExecuteAsync(queryRate, rate, transaction);
            }

            transaction.Commit();
            return hotel;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    
    public async Task<Hotel> UpdateHotelWithRatesAsync(Hotel hotel)
    {
        var updateHotel = @"UPDATE hotel SET 
                        agency_id = @agency_id,
                        hotel_name = @hotel_name,
                        hotel_address = @hotel_address,
                        hotel_email = @hotel_email,
                        hotel_contactno = @hotel_Contactno
                    WHERE hotel_id = @hotel_id";


        var deleteOldRates = @"DELETE FROM hotel_rate WHERE hotel_id = @hotel_id";

        var insertRates = @"INSERT INTO hotel_rate (hotel_id, rate_type, rate, start_date, end_date)
                            VALUES (@hotel_id, @rate_type, @rate, @start_date, @end_date)";

        using var connection = (NpgsqlConnection)_context.CreateConnection();
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        using var transaction = connection.BeginTransaction();


            await connection.ExecuteAsync(updateHotel, hotel, transaction);
                await connection.ExecuteAsync(deleteOldRates, new { HotelId = hotel.hotel_id }, transaction);

            foreach (var rate in hotel.HotelRates)
            {
                rate.hotel_id = hotel.hotel_id;
                await connection.ExecuteAsync(insertRates, rate, transaction);
            }

            transaction.Commit();
            return hotel;
        
    }

    public async Task<int> DeleteHotelAsync(int hotelId)
    {
        var deleteRates = @"DELETE FROM hotel_rate WHERE hotel_id = @HotelId";
        var deleteHotel = @"DELETE FROM hotel WHERE hotel_id = @HotelId";

        using var connection = (NpgsqlConnection)_context.CreateConnection();
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        using var transaction = connection.BeginTransaction();

        try
        {
            await connection.ExecuteAsync(deleteRates, new { HotelId = hotelId }, transaction);
            await connection.ExecuteAsync(deleteHotel, new { HotelId = hotelId }, transaction);

            transaction.Commit();

            return hotelId;
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

        using var connection = (NpgsqlConnection)_context.CreateConnection();
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }


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

        using var connection = (NpgsqlConnection)_context.CreateConnection();
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        var hotels = (await connection.QueryAsync<Hotel>(hotelQuery)).ToList();
        var rates = await connection.QueryAsync<HotelRate>(rateQuery);

        foreach (var hotel in hotels)
        {
            hotel.HotelRates = rates.Where(r => r.hotel_id == hotel.hotel_id).ToList();
        }

        return hotels;
    }

}