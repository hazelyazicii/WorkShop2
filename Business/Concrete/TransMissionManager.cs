using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.TransMission;
using Business.Responses.TransMission;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class TransMissionManager : ITransMissionService
{
    private readonly ITransMissionDal _TransMissionDal;
    private readonly TransMissionBusinessRules _TransMissionBusinessRules;
    private readonly IMapper _mapper;

    public TransMissionManager(ITransMissionDal TransMissionDal, TransMissionBusinessRules TransMissionBusinessRules, IMapper mapper)
    {
        _TransMissionDal = TransMissionDal; //new InMemoryTransMissionDal(); // Başka katmanların class'ları new'lenmez. Bu yüzden dependency injection kullanıyoruz.
        _TransMissionBusinessRules = TransMissionBusinessRules;
        _mapper = mapper;
    }

    public AddTransMissionResponse Add(AddTransMissionRequest request)
    {
        // İş Kuralları
        _TransMissionBusinessRules.CheckIfTransMissionNameNotExists(request.Name);
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction
        //TransMission TransMissionToAdd = new(request.Name)
        TransMission TransMissionToAdd = _mapper.Map<TransMission>(request); // Mapping

        _TransMissionDal.Add(TransMissionToAdd);

        AddTransMissionResponse response = _mapper.Map<AddTransMissionResponse>(TransMissionToAdd);
        return response;
    }

    public GetTransMissionListResponse GetList(GetTransMissionListRequest request)
    {
        // İş Kuralları
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        IList<TransMission> TransMissionList = _TransMissionDal.GetList();
    
        // TransMissionList.Items diye bir alan yok, bu yüzden mapping konfigurasyonu yapmamız gerekiyor.

        // TransMission -> TransMissionListItemDto
        // IList<TransMission> -> GetTransMissionListResponse

        GetTransMissionListResponse response = _mapper.Map<GetTransMissionListResponse>(TransMissionList); // Mapping
        return response;
    }
}
