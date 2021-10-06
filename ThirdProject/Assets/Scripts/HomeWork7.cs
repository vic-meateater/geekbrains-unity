using System;
using System.Collections.Generic;
using System.Linq;

namespace BananaMan
{
    public static class HomeWork7
    {
        //Реализовать метод расширения для поиска количество символов в строке.
        public static int CharCount(this string str, char c)
        {
            return str.Count(element => element == c);
        }

        //Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции
        class Task2
        {
            private static Random r = new Random();
            public static List<int> myList0 = new List<int> { r.Next(10) };

            public static List<string> getElementCountInList<T>(List<T> myList0)
            {
                List<string> resultList = new List<string>();
                foreach (var c in myList0
                    .Select(a => new { a, counter = myList0.Count(b => a.Equals(b)) })
                    .Select(t => $"Элемент {t.a} встречается в листе {t.counter} раз(а)")
                    .Where(c => !resultList.Contains(c)))
                {
                    resultList.Add(c);
                }
                return resultList;
            }
        }
    }
}