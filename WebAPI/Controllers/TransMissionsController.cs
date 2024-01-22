using Business;
using Business.Abstract;
using Business.Concrete;
using Business.Requests.TransMission;
using Business.Responses.TransMission;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransMissionsController : ControllerBase
{
    private readonly ITransMissionService _TransMissionService;

    public TransMissionsController(ITransMissionService TransMissionService)
    {
       
        _TransMissionService = TransMissionService;
       
    }

    public GetTransMissionListResponse GetList([FromQuery] GetTransMissionListRequest request)
    {
        GetTransMissionListResponse response = _TransMissionService.GetList(request);
        return response; 
    }

    public ActionResult<AddTransMissionResponse> Add(AddTransMissionRequest request)
    {
        try
        {
            AddTransMissionResponse response = _TransMissionService.Add(request);

           
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
