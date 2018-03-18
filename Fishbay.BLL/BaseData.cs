using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using Fishbay.Core;

namespace Fishbay.BLL
{
    public abstract class BaseData
    {
        //public static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected static ObjectCache Cache
        {
            get { return MemoryCache.Default; }
        }

        /// <summary>
        /// Remove from cache all items whose key starts with the input prefix
        /// </summary>
        protected static void RemoveFromCache(string key)
        {
            key = key.ToLower();
            List<string> items = new List<string>();

            items = Cache.Select(kvp => kvp.Key).ToList();

            foreach (string item in items)
            {
                if (item.ToLower().StartsWith(key))
                {
                    Cache.Remove(item);
                }
            }
        }

        /// <summary>
        /// A better and more flexible solution
        /// TODO: http://stackoverflow.com/questions/4183270/how-to-clear-the-net-4-memorycache/22388943#comment34789210_22388943
        /// </summary>
        public static void ClearCache()
        {
            var allKeys = Cache.Select(o => o.Key);
            foreach (string item in allKeys)
            {
                Cache.Remove(item);
            }
            //Parallel.ForEach(allKeys, key => Cache.Remove(key));
        }

        /// <summary>
        /// Cache the input data
        /// </summary>
        protected static void CacheData(string key, object data)
        {
            if (data != null)
            {
                Cache.Add(key, data, DateTime.Now.AddDays(1), null);
            }
        }

        protected static int GetPageIndex(int pageIndex, int pageSize)
        {
            if (pageSize <= 0)
                return 0;
            else
                return (int)Math.Floor((double)pageIndex / (double)pageSize);
        }



        protected static bool BarCodeIsValid(string barCode)
        {
            bool result = false;
            if (barCode.Length == 12)
            {
                char[] codes = barCode.ToCharArray();
                foreach (char code in codes)
                {
                    int number;
                    if (!Int32.TryParse(code.ToString(), out number))
                    {
                        barCode = String.Empty;
                        break;
                    }
                }

                result = true;
            }
            else
            {
                barCode = String.Empty;
            }
            return result;
        }

        /// <summary>
        /// Generates BarCode in Int64 value
        /// The legacy system requires BarCode as Int64
        /// Remove upon get upgraded  
        /// </summary>
        /// <returns>BarCode in Int64 value</returns>
        protected static long GetBarCode()
        {
            long result = 0;
            Random random = new Random();
            while (result <= 0)
            {
                byte[] buf = new byte[8];
                random.NextBytes(buf);
                result = BitConverter.ToInt64(buf, 0);
            }
            return result;
        }


        public static string GetStatus(ItemState state)
        {
            return EnumName.GetStringValue(state);
        }

        





        public static string GetWeekDay(DateTime dt)
        {
            DayOfWeek dow = dt.DayOfWeek;
            switch (dow)
            {
                case DayOfWeek.Monday:
                    return "Понедельник";
                case DayOfWeek.Tuesday:
                    return "Вторник";
                case DayOfWeek.Wednesday:
                    return "Среда";
                case DayOfWeek.Thursday:
                    return "Четверг";
                case DayOfWeek.Friday:
                    return "Пятница";
                case DayOfWeek.Saturday:
                    return "Суббота";
                case DayOfWeek.Sunday:
                    return "Воскресенье";

            }
            return string.Empty;
        }

    }
}