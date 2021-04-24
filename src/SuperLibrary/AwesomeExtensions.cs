using System;

namespace System
{
    public static class AwesomeExtensions 
    {
        public static bool IsEmpty(this string text) => string.IsNullOrWhiteSpace(text);
    }
}
