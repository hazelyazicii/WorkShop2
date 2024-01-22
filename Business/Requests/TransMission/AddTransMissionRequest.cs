namespace Business.Requests.TransMission;

public class AddTransMissionRequest
{ 
    public string Name { get; set; }

    public AddTransMissionRequest(string name)
    {
        Name = name;
    }
}
