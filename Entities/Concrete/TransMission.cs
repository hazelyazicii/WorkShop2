using Core.Entities;

namespace Entities.Concrete;

public class TransMission : Entity<int>
{
    public string Name { get; set; }

    public TransMission()
    {
    }

    public TransMission(string name)
    {
        Name = name;
    }
}
