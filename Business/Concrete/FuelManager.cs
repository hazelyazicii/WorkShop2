using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class FuelManager : IFuelService
{
    private readonly IFuelDal _FuelDal;
    private readonly FuelBusinessRules _FuelBusinessRules;
    private readonly IMapper _mapper;

    public FuelManager(IFuelDal FuelDal, FuelBusinessRules FuelBusinessRules, IMapper mapper)
    {
        _FuelDal = FuelDal; //new InMemoryFuelDal(); // Başka katmanların class'ları new'lenmez. Bu yüzden dependency injection kullanıyoruz.
        _FuelBusinessRules = FuelBusinessRules;
        _mapper = mapper;
    }

    public AddFuelResponse Add(AddFuelRequest request)
    {
     
        _FuelBusinessRules.CheckIfFuelNameNotExists(request.Name);
        
        Fuel FuelToAdd = _mapper.Map<Fuel>(request); // Mapping

        _FuelDal.Add(FuelToAdd);

        AddFuelResponse response = _mapper.Map<AddFuelResponse>(FuelToAdd);
        return response;
    }

    public GetFuelListResponse GetList(GetFuelListRequest request)
    {
      
        IList<Fuel> FuelList = _FuelDal.GetList();
    
      GetFuelListResponse response = _mapper.Map<GetFuelListResponse>(FuelList); // Mapping
        return response;
    }

    public GetFuelListResponse GetList(GetCarListRequest request)
    {
        throw new NotImplementedException();
    }
}
