using System.Collections.Generic;
using System.Threading.Tasks;
using FruitApplication.BusinessLogic.Models;

namespace FruitApplication.BusinessLogic.Interfaces
{


    public interface IBLFruit
    {

        IEnumerable<FruitDTO> FindAll();
        FruitDTO FindById(long id);
        FruitDTO Save(FruitDTO fruitDTO);
        FruitDTO Update(long id, FruitDTO fruitDTO);
        void Delete(long id);
    }

}