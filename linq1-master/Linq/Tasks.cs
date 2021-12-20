using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Linq.Objects;

namespace Linq
{
    public static class Tasks
    {
        #region Low

        public static IEnumerable<string> Task1(char c, IEnumerable<string> stringList)
        { 
            return stringList.Where(i => i.Length > 1 && i.First() == c && i.Last() == c);
        }

        public static IEnumerable<int> Task2(IEnumerable<string> stringList)
        {
            return stringList.Select(i => i.Length).OrderBy(c => c);
        }

        public static IEnumerable<string> Task3(IEnumerable<string> stringList)
        {
            return stringList.Select(i => i.First().ToString() + i.Last().ToString());
        }

        public static IEnumerable<string> Task4(int k, IEnumerable<string> stringList)
        {
            return stringList.Where(i => i.Length == k && int.TryParse(i.Last().ToString(), out _)).Select(k => k).OrderBy(c => c);
        }

        public static IEnumerable<string> Task5(IEnumerable<int> integerList)
        {
            return integerList.Where(i => i % 2 != 0).Select(c => c.ToString()).OrderBy(a => Convert.ToInt32(a));
        }

        #endregion

        #region Middle

        public static IEnumerable<string> Task6(IEnumerable<int> numbers, IEnumerable<string> stringList)
        {
            return numbers.Select(n => stringList.FirstOrDefault(s => s.Count() == n && s.Any() && char.IsDigit(s.First())) ?? "Not found");
        }

        public static IEnumerable<int> Task7(int k, IEnumerable<int> integerList)
        { 
            return integerList.Where(n => n % 2 == 0).Except(integerList.Skip(k)).Reverse();
        }
        
        public static IEnumerable<int> Task8(int k, int d, IEnumerable<int> integerList)
        {
            
            return integerList.TakeWhile(x => x <= d).Union(integerList.Skip(k)).OrderByDescending(c => c);
        }

        public static IEnumerable<string> Task9(IEnumerable<string> stringList)
        {
            return stringList.GroupBy(s => s.First()).Select(s => s.Sum(q => q.Count()) + "-" + s.Key).OrderByDescending(s => Convert.ToInt32(s.Substring(0, s.IndexOf('-')))).ThenBy(s => s.Last());
        }

        public static IEnumerable<string> Task10(IEnumerable<string> stringList)
        {
            return stringList.OrderBy(s => s).GroupBy(s => s.Count()).Select(k => new string(k.Select(s => char.ToUpper(s[^1])).ToArray())).OrderByDescending(s => s.Count());
        }

        #endregion

        #region Advance

        public static IEnumerable<YearSchoolStat> Task11(IEnumerable<Entrant> nameList)
        {
            return nameList.GroupBy(e => e.Year).Select(yst => new YearSchoolStat()
            {
                Year = yst.Key,
                NumberOfSchools = yst.GroupBy(y => y.SchoolNumber).Count()
            }).OrderBy(a => a.NumberOfSchools).ThenBy(b => b.Year);
        }

        public static IEnumerable<NumberPair> Task12(IEnumerable<int> integerList1, IEnumerable<int> integerList2)
        {
            return integerList1
                .SelectMany(list1 => integerList2,
                    (i, i1) => (Math.Abs(i % 10) - Math.Abs(i1 % 10) == 0) ? new NumberPair() {Item1 = i, Item2 = i1} : null).Where(i => i != null)
                .OrderBy(n => n.Item1).ThenBy(n => n.Item1 == n.Item2 ? n.Item1 : n.Item2);
        }

        public static IEnumerable<YearSchoolStat> Task13(IEnumerable<Entrant> nameList, IEnumerable<int> yearList)
        {
            return yearList.Select(year => new YearSchoolStat()
            {
                Year = year,
                NumberOfSchools = nameList.Where(l => l.Year == year).GroupBy(n => n.SchoolNumber).Count()
            }).OrderBy(n => n.NumberOfSchools).ThenBy(y => y.Year);
        }

        public static IEnumerable<MaxDiscountOwner> Task14(IEnumerable<Supplier> supplierList,
                IEnumerable<SupplierDiscount> supplierDiscountList)
        {
            return supplierList.Join(supplierDiscountList, supplier => supplier.Id, supD => supD.SupplierId,
                    (suppForOwner, suppDiscount) => new MaxDiscountOwner { ShopName = suppDiscount.ShopName, Owner = suppForOwner, Discount = suppDiscount.Discount })
                    .GroupBy(maxDisc => maxDisc.ShopName)
                    .Select(a => a.OrderByDescending(maxDiscOwn => maxDiscOwn.Discount)
                    .ThenBy(maxDiscOwn => maxDiscOwn.Owner.Id).First())
                    .OrderBy(maxDiscOwn => maxDiscOwn.ShopName);
        }

        public static IEnumerable<CountryStat> Task15(IEnumerable<Good> goodList,
            IEnumerable<StorePrice> storePriceList)
        {
            return goodList.GroupBy(good => good.Country)
                .Select(ofGood => ofGood.First())
                .Select(good => storePriceList.Any(storePrice => storePrice.GoodId == good.Id) ? goodList
                    .Join(storePriceList, good => good.Id, storePrice => storePrice.GoodId,
                        (g, storePr) => new
                        {
                            g.Country,
                            storePr.Shop,
                            storePr.Price
                        })
                    .GroupBy(x => x.Country)
                    .Select(col => new CountryStat
                    {
                        Country = col.Key,
                        StoresNumber = col.Select(c => c.Shop).Distinct().Count(),
                        MinPrice = col.Select(c => c.Price).Min()
                    })
                    .First(countStat => countStat.Country == good.Country) : new CountryStat
                {
                    Country = good.Country,
                    StoresNumber = 0,
                    MinPrice = 0
                }).OrderBy(countSt => countSt.Country);
        }

        #endregion

    }
}
