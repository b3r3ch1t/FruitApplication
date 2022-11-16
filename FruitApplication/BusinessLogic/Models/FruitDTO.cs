using System.ComponentModel.DataAnnotations;

namespace FruitApplication.BusinessLogic.Models
{
    public class FruitDTO
    {
        public long Id { get; set; }


        [Required(ErrorMessage = "The name is required. ")]
        public string Name { get; set; }


        [Required(ErrorMessage = "The description is required. ")]
        [MaxLength(25,ErrorMessage = "The max size of Description is 25 characters")]
        public string Description { get; set; }


        [Required]
        public FruitTypeDTO Type { get; set; }
    }
}