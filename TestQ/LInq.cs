using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestQ.Linq
{
    public static class Linq
    {
        public static IEnumerable<int> Ints()
        {
            int[] numbers = [5, 10, 8, 3, 6, 12];

            var res = numbers.
                Where(n => n %2 == 0)
                .OrderBy(n => n);

            return res;
        }

        public static IEnumerable<int> Range()
        {
            List<int> numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

            var res = numbers.Where(n => n > 3 && n < 7)
                .OrderBy(x => x)
                .ToList();

            return res;
        }

        public static void CharGrouping()
        {
        var emps = new List<TestQ.Linq.Employee>
            {
                new TestQ.Linq.Employee { DepartmentId = 1, Salary = 1000 },
                new TestQ.Linq.Employee { DepartmentId = 2, Salary = 2000 },
                new TestQ.Linq.Employee { DepartmentId = 1, Salary = 1500 },
                new TestQ.Linq.Employee { DepartmentId = 2, Salary = 2500 },
                new TestQ.Linq.Employee { DepartmentId = 1, Salary = 1800 }
            };

            var res = from e in emps
                      group e by e.DepartmentId into g
                      select new {
                          
                         id = g.Key,
                          
                          s = g.Sum(x => x.Salary) 
                      };
 

            //string[] groupingQuery = ["carrots", "cabbage", "broccoli", "beans", "barley"];

            //string s = "skjdnsjdsjsldsdslsd";

            //var t = s.ToList().FirstOrDefault(x => x.Equals('n'));
            //s.Remove(t);

            //var res = from x in s
            //          group x by x into temp
            //          select new { temp.Key, temp };

            //int[] arr = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };

            //var nums =  from x in arr
            //            group x by x into temp
            //            select new { temp.Key, temp };

            //foreach( var y in res)
            //{
            //    Console.WriteLine(y.Key.ToString() + " - " + y.temp.Count());
            //}
        }
    }

    public class Employee
    {
        public int DepartmentId { get; set; }
        public int Salary { get; set; }
    }

}
