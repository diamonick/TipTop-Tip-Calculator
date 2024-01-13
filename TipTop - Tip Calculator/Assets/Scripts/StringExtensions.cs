using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StringExtensionMethods
{
    public static class StringExtensions
    {
        public static string GetLast(this string source, int numberOfChars)
        {
            if (numberOfChars >= source.Length)
                return source;
            return source.Substring(source.Length - numberOfChars);
        }
    }
}
