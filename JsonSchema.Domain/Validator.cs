using JsonSchema.Domain.CustomValidators;
using JsonSchema.Domain.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace JsonSchema.Domain
{
    public class Validator
    {
        public bool ValidateDates(JObject json, out IList<ValidationError> errors)
        {
            JSchemaReaderSettings settings = new JSchemaReaderSettings
            {
                Validators = new List<JsonValidator>
                {
                    new DateValidator(),
                    new DateFieldsValidator()
                }
            };

            JSchema schema = JSchema.Parse(LoadSchema("dates-schema.json"), settings);
            var isValid = json.IsValid(schema, out errors);
            var dates = json.ToObject<Dates>();
            return isValid;
        }

        private string LoadSchema(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"JsonSchema.Domain.Schemas.{name}";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
