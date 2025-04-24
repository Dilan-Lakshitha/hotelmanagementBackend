namespace hotelmanagementBackend.Models.DTOs;

public class LocationTicketDto
{
    public int LocationTicketId { get; set; }
    public string LocationName { get; set; }
    public string Description { get; set; }
    public decimal AdultPrice { get; set; }
    public decimal ChildPrice { get; set; }
    public int AgencyId { get; set; }
}