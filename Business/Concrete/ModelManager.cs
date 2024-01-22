using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Model;
using Business.Responses.Model;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ModelManager : IModelService
{
    private readonly IModelDal _ModelDal;
    private readonly ModelBusinessRules _ModelBusinessRules;
    private readonly IMapper _mapper;

    public ModelManager(IModelDal ModelDal, ModelBusinessRules ModelBusinessRules, IMapper mapper)
    {
        _ModelDal = ModelDal;
        _ModelBusinessRules = ModelBusinessRules;
        _mapper = mapper;
    }

    public AddModelResponse Add(AddModelRequest request)
    {
        
        _ModelBusinessRules.CheckIfModelNameNotExists(request.Name);
       
        Model ModelToAdd = _mapper.Map<Model>(request);

        _ModelDal.Add(ModelToAdd);

        AddModelResponse response = _mapper.Map<AddModelResponse>(ModelToAdd);
        return response;
    }

    public GetModelListResponse GetList(GetModelListRequest request)
    {
      
        IList<Model> ModelList = _ModelDal.GetList();
    
        GetModelListResponse response = _mapper.Map<GetModelListResponse>(ModelList);
        return response;
    }
}
