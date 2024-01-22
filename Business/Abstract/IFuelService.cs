using Business.Requests.Fuel;
using Business.Responses.Fuel;

namespace Business.Abstract;

public interface IFuelService
{
    public AddFuelResponse Add(AddFuelRequest request);

    public GetFuelListResponse GetList(GetCarListRequest request);
    GetFuelListResponse GetList(GetFuelListRequest request);
}
