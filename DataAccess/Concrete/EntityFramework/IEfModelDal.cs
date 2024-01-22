using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public interface IEfModelDal
    {
        void Add(Model entity);
        void Delete(Model entity);
        Model? GetById(int id);
        IList<Model> GetList();
        void Update(Model entity);
    }
}