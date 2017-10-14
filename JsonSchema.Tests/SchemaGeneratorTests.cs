using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using JsonSchema.Model;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;

namespace JsonSchema.Tests
{
    [TestClass]
    public class SchemaGeneratorTests
    {
        [TestMethod]
        public void ShouldGeneratePersonSchemaWithSuccessfulValidation()
        {
            Assert.IsTrue(ShouldGeneratePersonSchema("Hans"));
        }

        [TestMethod]
        public void ShouldGeneratePersonSchemaWithFailedValidation()
        {
            Assert.IsFalse(ShouldGeneratePersonSchema("Annemaria-Helena"));
        }

        private bool ShouldGeneratePersonSchema(string firstName)
        {
            var sut = new Validator();
            var schema = sut.GetPersonSchema();
            var person = CreatePerson(firstName);
            var json = JObject.FromObject(person);

            return json.IsValid(schema, out IList<ValidationError> errors);
        }

        private Person CreatePerson(string firstName)
        {
            return new Person
            {
                FirstName = firstName,
                LastName = "Muster",
                Age = 30,
                BillingAddress = new Address { Street = "Alexanderplatz", HouseNumber = 23, City = "Berlin" },
                DeliveryAddress = new Address { Street = "Schanzenstrasse", HouseNumber = 11, City = "Hamburg" }
            };
        }
    }
}
