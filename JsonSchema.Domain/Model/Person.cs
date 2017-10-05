using System.ComponentModel.DataAnnotations;

namespace JsonSchema.Model
{
    public class Person
    {
        [Required][MaxLength(10)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Address BillingAddress { get; set; }
        public Address DeliveryAddress { get; set; }
    }
}
