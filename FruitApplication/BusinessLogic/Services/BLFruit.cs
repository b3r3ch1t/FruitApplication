
using FruitApplication.DataAccess.Interfaces;
using FruitApplication.BusinessLogic.Interfaces;
using FruitApplication.BusinessLogic.Models;
using FruitApplication.DataAccess.Entities;

namespace BusinessLogic.Services
{

    public class BLFruit : IBLFruit
    {

        private readonly IFruitRepository _fruitRepository;

        public BLFruit(IFruitRepository fruitRepository)
        {

            _fruitRepository = fruitRepository;

        }

        public IEnumerable<FruitDTO> FindAll()
        {

            var result = _fruitRepository.FindAll();
            var listFruitsDTO = new List<FruitDTO>();
            foreach (var f in result)
            {

                listFruitsDTO.Add(new FruitDTO
                {


                    Id = f.Id,
                    Name = f.Name,
                    Type = new FruitTypeDTO()
                    {
                        Description = f.Description,
                        Id = f.Id,
                        Name = f.Name
                    },
                    Description = f.Description
                });

            }

            return listFruitsDTO;


        }
        public FruitDTO FindById(long id)
        {

            var fruit = FindAll().FirstOrDefault();
            if (fruit == null) return new FruitDTO();
            var result = new FruitDTO
            {
                Id = fruit.Id,
                Name = fruit.Name,
                Type = fruit.Type,
                Description = fruit.Description
            };

            return result;

        }
        public FruitDTO Save(FruitDTO fruitDTO)
        {

            var fruit = new Fruit
            {
                Id = fruitDTO.Id,
                Name = fruitDTO.Name,
                Type = new FruitType
                {
                    Description = fruitDTO.Type.Description,
                    Id = fruitDTO.Type.Id,
                    Name = fruitDTO.Type.Name,
                },
                Description = fruitDTO.Description
            };


            _fruitRepository.Save(fruit);

            fruitDTO.Id = fruit.Id; 
            return fruitDTO;

        }
        public FruitDTO Update(long id, FruitDTO fruitDTO)
        {

            var fruit = new Fruit
            {
                Id = fruitDTO.Id,
                Name = fruitDTO.Name,
                Description = fruitDTO.Description
            };

            var fruitType = new FruitType()
            {
                Description = fruitDTO.Description,
                Id = fruitDTO.Type.Id,
                Name = fruitDTO.Type.Name
            };

            fruit.Type = fruitType;

            _fruitRepository.Update(id, fruit);
            

            return fruitDTO;

        }
        public void Delete(long id)
        {
            _fruitRepository.Delete(id);
        }

    }


}