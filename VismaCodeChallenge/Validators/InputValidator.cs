using System;
namespace VismaCodeChallenge.Validators
{
    static public class InputValidator
    {
        static public bool IsValid<T>(object value)
        {
            return value is T;
        }
    }
}

