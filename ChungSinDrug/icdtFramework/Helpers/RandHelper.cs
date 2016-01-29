using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace icdtFramework.Helpers
{
    public static class RandHelper
    {
        private static Random random = new Random();

        public static string GetRandAlphanumericString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new string(
                Enumerable.Repeat(chars, length)
                    .Select(s=>s[random.Next(s.Length)])
                    .ToArray()
                );
            return result;
        }
    }
}