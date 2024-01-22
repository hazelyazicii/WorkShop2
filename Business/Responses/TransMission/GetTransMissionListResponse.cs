using Business.Dtos.TransMission;
namespace Business;

public class GetTransMissionListResponse
{
    public ICollection<TransMissionListItemDto> Items { get; set; }

    public GetTransMissionListResponse()
    {
        Items = Array.Empty<TransMissionListItemDto>();
    }

    public GetTransMissionListResponse(ICollection<TransMissionListItemDto> items)
    {
        Items = items;
    }
}

