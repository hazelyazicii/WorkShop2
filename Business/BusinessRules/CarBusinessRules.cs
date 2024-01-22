using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class CarBusinessRules
{
    private readonly ICarDal _CarDal;

    public CarBusinessRules(ICarDal CarDal)
    {
        _CarDal = CarDal;
    }

    public void CheckIfCarNameNotExists(string CarName)
    {
        bool isExists = _CarDal.GetList().Any(b => b.Name == CarName);
        if (isExists)
        {
            throw new BusinessException("Car already exists.");
        }
    }
}
