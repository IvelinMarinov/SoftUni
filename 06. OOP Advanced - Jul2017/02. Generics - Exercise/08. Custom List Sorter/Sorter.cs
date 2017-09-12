using System;
using System.Linq;

namespace _08.Custom_List_Sorter
{
    public class Sorter
    {
        public static CustomList<T> Sort<T>(CustomList<T> customList)
            where T : IComparable<T>
        {
            var temp = customList.Data.OrderBy(x => x);

            return new CustomList<T>(temp);
        }
    }
}
