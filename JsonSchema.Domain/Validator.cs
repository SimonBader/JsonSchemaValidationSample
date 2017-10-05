using JsonSchema.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System.Collections.Generic;
using System.IO;

namespace JsonSchema
{
    public class Validator
    {
        public JSchema GetSchema()
        {
            var person = CreatePerson();
            var generator = new JSchemaGenerator();
            return generator.Generate(typeof(Person));
        }

        public IList<ValidationError> Validate(JObject json)
        {
            IList<ValidationError> errors;
            var schema = GetSchema();

            if (json.IsValid(schema, out errors))
            {
                return errors;
            }

            var model = json.ToObject<Person>();
            return new List<ValidationError>();
        }

        private Person CreatePerson()
        {
            return new Person
            {
                FirstName = "Hans",
                LastName = "Muster",
                Age = 30,
                BillingAddress = new Address { Street = "Alexanderplatz", HouseNumber = 23, City = "Berlin" },
                DeliveryAddress = new Address { Street = "Schanzenstrasse", HouseNumber = 11, City = "Hamburg" }
            };
        }
    }
}
