using System.Threading.Tasks;
using System.Collections.Generic;

using System.Linq;
using FruitApplication.DataAccess.Entities;
using FruitApplication.DataAccess.Interfaces;
using DataAcess;

namespace FruitApplication.DataAccess.Repository
{
    public class FruitRepository : IFruitRepository
    {
        private readonly FruitContext _dbContext;
        public FruitRepository(FruitContext fruitContext)
        {
            _dbContext = fruitContext;

        }
        public List<Fruit> FindAll()
        {
            var result = _dbContext.Fruits.ToList();



            return result;

        }
        public Fruit FindById(long id)
        {
            var result = FindAll().FirstOrDefault(x => x.Id == id);

            return result;
        }

        public Fruit Save(Fruit fruit)
        {

            _dbContext.Fruits.Add(fruit);

            _dbContext.SaveChanges();
            return fruit;

        }

        public Fruit Update(long id, Fruit fruitNew)
        {
            var fruit = FindAll().First(x => x.Id == id);

             
            fruit.Description = fruitNew.Description;
            fruit.Id = id;
            fruit.Name = fruitNew.Name;
            fruit.Type = fruitNew.Type;

            _dbContext.Fruits.Update(fruit);

            _dbContext.SaveChanges();

           

            return fruit;
        }

        public void Delete(long id)
        {
            var fruit = FindById(id);
            
           _dbContext.Remove(fruit);
           _dbContext.SaveChanges();

        }
    }
}