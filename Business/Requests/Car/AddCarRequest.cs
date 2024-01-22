namespace Business.Requests.Car;

public class AddCarRequest
{ 
    public string Name { get; set; }

    public AddCarRequest(string name)
    {
        Name = name;
    }
}
