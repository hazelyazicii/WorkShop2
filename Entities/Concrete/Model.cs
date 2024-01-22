using Core.Entities;

namespace Entities.Concrete;

public class Model : Entity<int>
{

    public int BrandId { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }

    public string ModelName { get; set; }
    public int ModelYear { get; set; }
    public int DailyPrice { get; set; }
    public string Name { get; set; }

    public Model()
    {

    }
    public Model(string modelName, int modelYear, int dailyPrice, int brandId, int fuelId, int transmissionId)
    {
        BrandId = brandId;
        FuelId = fuelId;
        TransmissionId = transmissionId;
        ModelName = modelName;
        ModelYear = modelYear;
        DailyPrice = dailyPrice;
    }


}