using System;
using System.Linq;

namespace TankStats.Extensions
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string Input)
        {
            switch (Input)
            {
                case null: throw new ArgumentNullException(nameof(Input));
                case "": throw new ArgumentException($"{nameof(Input)} cannot be empty");
                default: return Input.First().ToString().ToUpper() + Input.Substring(1);
            }
        }
    }
}
