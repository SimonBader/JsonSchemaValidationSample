using JsonSchema.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSchema.Tests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ShouldValidateDatesSuccessfully()
        {
            var json = JObject.Parse("{ firstDate: '2017-01-31', secondDate: '2017-01-30'}");
            var sut = new Domain.Validator();
            Assert.IsTrue(sut.ValidateDates(json, out IList<ValidationError> errors));
        }
    }
}
