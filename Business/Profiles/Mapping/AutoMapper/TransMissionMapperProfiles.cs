using AutoMapper;
using Business.Dtos.TransMission;
using Business.Requests.TransMission;
using Business.Responses.TransMission;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class TransMissionMapperProfiles : Profile
{
    public TransMissionMapperProfiles()
    {
        CreateMap<AddTransMissionRequest, TransMission>();
        CreateMap<TransMission, AddTransMissionResponse>();

        CreateMap<TransMission, TransMissionListItemDto>();
        CreateMap<IList<TransMission>, GetTransMissionListResponse>()
            .ForMember(
                destinationMember: dest => dest.Items,
                memberOptions: opt => opt.MapFrom(mapExpression: src => src)
            );
    }
}
