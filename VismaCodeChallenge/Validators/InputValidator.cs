using System;
namespace VismaCodeChallenge.Validators
{
    static public class InputValidator
    {
        static public bool IsValid<T>(this object value)
        {
            return value is T;
        }

        static public bool InValidRange(this object value, double min, double max)
        {
            return double.TryParse(value.ToString(), out double numericValue) &&
                numericValue >= min &&
                numericValue <= max;
        }
    }
}

