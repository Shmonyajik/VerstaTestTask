
using System.ComponentModel.DataAnnotations;

namespace VerstaTestTask.Domain.Models
{
    public class Order: IValidatableObject
    {
        public int Id { get; set; }
        public Guid Number { get; set; }
        [Required]
        public string SenderCity { get; set; }
        [Required]
        public string SenderAddress { get; set; }
        [Required]
        public string DestinationCity { get; set; }
        [Required]
        public string DestinationAddress { get; set; }
        [Required]
        [Range(0, 1000000)]
        public double СargoWeight { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly PickupDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (СargoWeight < 0)
                errors.Add(new ValidationResult("Weight must be positive", new List<string> { "CargoWeight" }));

            return errors;
        }

    }
}
