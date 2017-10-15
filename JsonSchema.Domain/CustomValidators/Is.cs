using System;

namespace JsonSchema.Domain.CustomValidators
{
    public static class Is
    {
        public static Func<DateTime, DateTime, bool> GreaterThan { get { return (x, y) => x > y; } }
        public static Func<DateTime, DateTime, bool> GreaterEqualThan { get { return (x, y) => x >= y; } }
        public static Func<DateTime, DateTime, bool> LessThan { get { return (x, y) => x < y; } }
        public static Func<DateTime, DateTime, bool> LessEqualThan { get { return (x, y) => x <= y; } }
    }
}
