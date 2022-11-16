using System.Collections.Generic;
using System.Threading.Tasks;
using FruitApplication.DataAccess.Entities;

namespace FruitApplication.DataAccess.Interfaces
{
    public interface IFruitRepository
    {
        List<Fruit> FindAll();
        Fruit FindById(long id);
        Fruit Save(Fruit fruit);
        Fruit Update(long id, Fruit fruit);
        void Delete(long id);
    }
}