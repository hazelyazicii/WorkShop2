using Business;
using Business.Abstract;
using Business.Concrete;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelsController : ControllerBase
{
    private readonly IFuelService _FuelService;

    public FuelsController(IFuelService FuelService)
    {
        
        _FuelService = FuelService;
        
    }
    public GetFuelListResponse GetList([FromQuery] GetFuelListRequest request)
    {
        GetFuelListResponse response = _FuelService.GetList(request);
        return response; 
    }
    public ActionResult<AddFuelResponse> Add(AddFuelRequest request)
    {
        try
        {
            AddFuelResponse response = _FuelService.Add(request);

            
            return CreatedAtAction(nameof(GetList), response);
        }
        catch (Core.CrossCuttingConcerns.Exceptions.BusinessException exception)
        {
            return BadRequest(
                new Core.CrossCuttingConcerns.Exceptions.BusinessProblemDetails()
                {
                    Title = "Business Exception",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = exception.Message,
                    Instance = HttpContext.Request.Path
                }
            );
            
        }
    }
}
