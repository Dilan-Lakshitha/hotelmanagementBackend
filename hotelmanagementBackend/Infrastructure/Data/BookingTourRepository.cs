using System.Data;
using Dapper;
using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;
using Npgsql;

namespace hotelmanagementBackend.Infrastructure.Data;

public class BookingTourRepository : IBookingTourRepository
{
    private readonly DapperContext _context;

    public BookingTourRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> AddBookingAsync(BookingTour booking)
    {
        var sql = @"INSERT INTO Bookingtours ( traveler_id , driver_id , guide_id , total_amount , booking_date )
                VALUES (@traveler_id, @driver_id, @guide_id, @total_amount, @booking_date) RETURNING booking_id;";

        var updateDriverSql = @"UPDATE driver SET is_available = FALSE WHERE driver_id = @driver_id;";
        var updateGuideSql = @"UPDATE guide SET is_available = FALSE WHERE guide_id = @guide_id;";

        using var connection = (NpgsqlConnection)_context.CreateConnection();
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        using var transaction = connection.BeginTransaction();

        try
        {
            var bookingId = await connection.ExecuteScalarAsync<int>(sql, booking, transaction);
            await connection.ExecuteAsync(updateDriverSql, new { driver_id = booking.driver_id }, transaction);
            await connection.ExecuteAsync(updateGuideSql, new { guide_id = booking.guide_id }, transaction);

            transaction.Commit();
            return bookingId;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
    
    public async Task<IEnumerable<BookingTour>> GetAllBookingsAsync()
    {
        var sql = "SELECT * FROM Bookingtours;";

        using var connection = (NpgsqlConnection)_context.CreateConnection();
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        var bookings = await connection.QueryAsync<BookingTour>(sql);
        return bookings;
    }
}