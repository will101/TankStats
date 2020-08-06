using System;
using System.Linq;
using System.Text.RegularExpressions;

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

        /// <summary>
        /// Add a space in between two words that are joined together. E.g. FirstClass will become First Class
        /// </summary>
        public static string AddSpace(this string Input)
        {
            return Regex.Replace(Input, "([a-z])([A-Z])", "$1 $2");
        }
    }
}
