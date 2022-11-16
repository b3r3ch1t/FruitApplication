using System.ComponentModel.DataAnnotations;

namespace FruitApplication.BusinessLogic.Models
{
    public class FruitDTO
    {
        public long Id { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public FruitTypeDTO Type { get; set; }
    }
}