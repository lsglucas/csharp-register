using System.Collections.Generic;

namespace DIO.Series
{
    public interface IRepository<BaseType>
    {
        List<BaseType> List();
        BaseType GetById(int id);
        void Insert(BaseType entity);
        void Delete(int id);
        void Update(int id, BaseType entity);
        int NextId();
    }
}