namespace Business.Requests.Model;

public class AddModelRequest
{
    public string Name { get; set; }

    public AddModelRequest(string name)
    {
        Name = name;
    }
}
