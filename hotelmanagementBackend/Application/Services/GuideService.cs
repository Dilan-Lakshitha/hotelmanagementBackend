using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Services;

public class GuideService: IGuideService
{
    private readonly IGuideRepository _guideRepository;

    public GuideService(IGuideRepository guideRepository)
    {
        _guideRepository = guideRepository;
    }

    public async Task<IEnumerable<Guide>> GetAllGuidesAsync()
    {
        return await _guideRepository.GetAllGuidesAsync();
    }

    public async Task<Guide> GetGuideByIdAsync(int id)
    {
        return await _guideRepository.GetGuideByIdAsync(id);
    }

    public async Task AddGuideAsync(Guide guide)
    {
        await _guideRepository.AddGuideAsync(guide);
    }

    public async Task UpdateGuideAsync(Guide guide)
    {
        await _guideRepository.UpdateGuideAsync(guide);
    }

    public async Task DeleteGuideAsync(int id)
    {
        await _guideRepository.DeleteGuideAsync(id);
    }
}