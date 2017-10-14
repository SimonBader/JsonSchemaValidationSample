using JsonSchema.Model;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace JsonSchema
{
    public class Validator
    {
        public JSchema GetPersonSchema()
        {
            var generator = new JSchemaGenerator();
            return generator.Generate(typeof(Person));
        }
    }
}
