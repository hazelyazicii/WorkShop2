namespace DataAccess.Concrete.InMemory
{
    public interface IInMemoryCarDal
    {
        bool Equals(object? obj);
        int GetHashCode();
    }
}