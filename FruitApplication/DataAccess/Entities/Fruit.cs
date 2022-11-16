namespace FruitApplication.DataAccess.Entities
{

    public class Fruit
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public long TypeId { get; set; }
        public string Description { get; set; }
        public FruitType Type { get; set; }

    }

}