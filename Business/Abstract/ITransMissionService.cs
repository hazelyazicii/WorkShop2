using Business.Requests.TransMission;
using Business.Responses.TransMission;

namespace Business.Abstract;

public interface ITransMissionService
{
    public AddTransMissionResponse Add(AddTransMissionRequest request);

    public GetTransMissionListResponse GetList(GetTransMissionListRequest request);
    
}
