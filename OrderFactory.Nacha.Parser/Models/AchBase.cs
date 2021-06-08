using System;

namespace OrderFactory.Nacha.Parser.Models
{
    public abstract class AchBase
    {
        protected static void CheckNachaString(string nachaString, string? nachaStringError)
        {
            if (string.IsNullOrEmpty(nachaString) || nachaString.Length != 94)
                throw new ArgumentException(nachaStringError, nameof(nachaString));
        }
    }
}