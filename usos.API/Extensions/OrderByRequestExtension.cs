using System;

namespace usos.API.Extensions
{
    public static partial class OrderByRequestExtension
    {
        public const string Asc = "ASC";
        public const string Desc = "DESC";
    
        private static bool IsSortDir(string sortDirA, string sortDirB = Asc)
        {
            return string.Equals(sortDirA, sortDirB, StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool IsSortBy(string sortByA, string sortByB)
        {
            return string.Equals(sortByA, sortByB, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}