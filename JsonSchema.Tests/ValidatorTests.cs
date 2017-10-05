using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsonSchema.Tests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void GetSchema()
        {
            var sut = new Validator();
            var schema = sut.GetSchema();
        }
    }
}
