using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class TransMissionBusinessRules
{
    private readonly ITransMissionDal _TransMissionDal;

    public TransMissionBusinessRules(ITransMissionDal TransMissionDal)
    {
        _TransMissionDal = TransMissionDal;
    }

    public void CheckIfTransMissionNameNotExists(string TransMissionName)
    {
        bool isExists = _TransMissionDal.GetList().Any(b => b.Name == TransMissionName);
        if (isExists)
        {
            throw new BusinessException("TransMission already exists.");
        }
    }
}
