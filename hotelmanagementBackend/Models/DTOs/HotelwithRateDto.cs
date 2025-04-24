namespace hotelmanagementBackend.Models.DTOs;

public class HotelwithRateDto
{
    public int AgencyId { get; set; }
    
    public int? HotelId { get; set; }
    public string HotelName { get; set; }
    public string HotelAddress { get; set; }
    public string HotelEmail { get; set; }
    public string HotelContactNo { get; set; }

    public List<HotelRateDto> HotelRates { get; set; }
}

public class HotelRateDto
{
    public string RateType { get; set; }
    public decimal RatePrice { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}