using System.Collections.Generic;

namespace FruitApplication.DataAccess.Entities
{


    public class FruitType
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Fruit> Fruits { get; set; }

    }


}