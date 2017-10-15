using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;

namespace JsonSchema.Domain.CustomValidators
{
    public class DateFieldsValidator : JsonValidator
    {
        private const string gteDateField = "gteDateField";

        public override bool CanValidate(JSchema schema)
        {
            return schema?.Format?.ToLower() == "date-field";
        }

        public override void Validate(JToken value, JsonValidatorContext context)
        {
            foreach(var property in context.Schema.Properties)
            {
                var extensions = property.Value.ExtensionData;

                foreach (var dateField in extensions)
                {
                    string validator = string.Empty;
                    bool isValid = true;

                    switch (dateField.Key)
                    {
                        case gteDateField:
                            validator = gteDateField;
                            var actual = value[property.Key].ToObject<DateTime>();
                            var expected = value[dateField.Value.Value<string>()].ToObject<DateTime>();
                            isValid = Is.GreaterEqualThan(actual, expected);
                            break;
                    }

                    if (!isValid)
                    {
                        context.RaiseError(validator);
                    }
                }
            }
        }
    }
}
