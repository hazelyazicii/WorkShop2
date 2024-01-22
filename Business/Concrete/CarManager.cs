using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Car;
using Business.Responses.Car;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private readonly ICarDal _CarDal;
    private readonly CarBusinessRules _CarBusinessRules;
    private readonly IMapper _mapper;

    public CarManager(ICarDal CarDal, CarBusinessRules CarBusinessRules, IMapper mapper)
    {
        _CarDal = CarDal; 
        _CarBusinessRules = CarBusinessRules;
        _mapper = mapper;
    }

    public AddCarResponse Add(AddCarRequest request)
    {
       
        _CarBusinessRules.CheckIfCarNameNotExists(request.Name);
        
        Car CarToAdd = _mapper.Map<Car>(request);

        _CarDal.Add(CarToAdd);

        AddCarResponse response = _mapper.Map<AddCarResponse>(CarToAdd);
        return response;
    }

    public GetCarListResponse GetList(GetCarListRequest request)
    {
        IList<Car> CarList = _CarDal.GetList();
  
        GetCarListResponse response = _mapper.Map<GetCarListResponse>(CarList);
        return response;
    }
}
