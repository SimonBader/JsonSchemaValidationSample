using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;

namespace JsonSchema.Domain.CustomValidators
{
    public class DateValidator : JsonValidator
    {
        private const string lteDaysFromToday = "lteDaysFromToday";

        public override bool CanValidate(JSchema schema)
        {
            return schema?.Format?.ToLower() == "date";
        }

        public override void Validate(JToken value, JsonValidatorContext context)
        {
            var extensions = context.Schema.ExtensionData;

            foreach(var numberOfDays in extensions)
            {
                string validator = string.Empty;
                bool isValid = true;

                switch (numberOfDays.Key)
                {
                    case lteDaysFromToday:
                        validator = lteDaysFromToday;
                        isValid = Validate(value, Is.LessEqualThan, DateTime.Now.Add, numberOfDays);
                        break;
                }

                if (!isValid)
                {
                    context.RaiseError(validator);
                }
            }
        }

        private bool Validate(JToken value, Func<DateTime, DateTime, bool> comparer, Func<TimeSpan, DateTime> func, KeyValuePair<string, JToken> numberOfDays)
        {
            var days = Convert.ToDouble(numberOfDays.Value);
            var expected = func(TimeSpan.FromDays(days));
            return comparer(value.ToObject<DateTime>(), expected);
        }
    }
}
