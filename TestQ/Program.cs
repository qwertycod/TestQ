using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static LinkedList;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestQ
{
    public class GrandParent
    {
        public void Print() => Console.WriteLine("GrandParent");
    }

    public class Parent 
    {
        public virtual void Print() => Console.WriteLine("Parent");
    }

    public class Child : Parent
    {
        public override void Print() => Console.WriteLine("Child");
    }

    public class SuperChild : Child
    {
        public void Print() => Console.WriteLine("Super Child");
    }

    public class SuperNormalChild : Child
    {
        public new void Print() => Console.WriteLine("Super normal Child");
    }

    public class Counter
    {
        private int count;
        public void Increase() => count++;
    }

    class MyService
    {
        public MyService(string x) { 
            Console.WriteLine("string"); }
        public MyService(object x) {
            Console.WriteLine("object"); }
    }

    class Program
    {
        public Func<Employee, bool> isPro;  // this can also    be used
        delegate bool IsPromotable(Employee emp);
        public static void PromoteEmployee(IList<Employee> employeeList, Func<Employee, bool> isEligibleToPromote)
        {
            foreach (Employee emp in employeeList)
            {

                if (isEligibleToPromote(emp))
                {
                    Console.WriteLine(emp.Name + " Promoted");
                }
            }
        }
        static bool m1(int i)
        {
            return i > 3;
        }
        static async Task Main(string[] args)
        {
            //var x = GetSortedByLengthAndString();
               CharGrouping();

            IA x = new Test();
            x.Hello();
            IB y = new Test();
            y.Hello();
            var xy = new Test();
            ((IB)xy).Hello();;

            //RemoveDuplicateFromList();
            Console.WriteLine("ok");
            #region calling methods
            //  var x = await RunTaskWithErrorHandling();

            //  TestAB.main(["1"]);

            // var res = Get6174(1111, 0);
            //var list = new List<int> { 1, 2, 4, 5, 6, 7 };
            //ConsumeYield(list);            //TestLSPError.test();

            // Unboxing
            //Int32 a = 64;
            //object b = a;
            //long l = (long)b;

            //// Hashset
            //int[] numbers = { 9, 3, 5, 1, 4, 2, 5, 6 };
            //var seen = new HashSet<int>();

            //foreach (var num in numbers)
            //{
            //    if (!seen.Add(num))
            //    {
            //        Console.WriteLine($"number is : {num}");
            //    }
            //}

            //// Func Actions
            //var actions = new List<Action>();

            //for (int i = 0; i < 3; i++)
            //{
            //    actions.Add(() => Console.WriteLine(i));
            //}

            //foreach (var action in actions)
            //{
            //    action();
            //}
            //Console.WriteLine("");

            //// Multicast delegate
            //Func<int> f1 = () => 1;

            //Func<int> f2 = () => 2;

            //var f = f1 + f2;

            //Console.WriteLine(f());     // 2  // last output considered


            //var reversedSentence = reverseSentence("abcvba a bcd efg");
            //reverseEachword("abcd");
            // addition / dictionay problem
            // var res = addition2([2, 7, 11, 15], 26);

            // test Liskov substitution
            //TestLSPSuccess.Test();

            // check if string is more of the object type
            //MyService service = new MyService(null);

            //MyService service1 = new MyService((object)null);


            // check if same object
            //var c1 = new Counter();
            //var c2 = c1;
            //c2.Increase();
            //Console.WriteLine(c1 == c2);        // value ?

            // check polymorphism virual and override
            //GrandParent gp = new GrandParent();
            //Parent p = new Parent();
            //Child ch = new Child();
            GrandParent gc = new GrandParent();
            //SuperChild super = new SuperChild();

           // gc.Print();     // Grand parent as its not virtual
            //gp = new Parent();
            //gp.Print();     //GrandParent , Parent
            //gp = new Child();
            //gp.Print();     // Grandarent, Child
            //p = new Child();
            //p.Print();      // Child, Child

            //ch = new SuperChild();
            //ch.Print();		// Child, Child

            //Console.WriteLine(res);

            //Parent p = new Child();
            //p.Print();
            //Parent p1 = new SuperChild();
            //p1.Print();

            //Parent p2 = new SuperNormalChild();
            //p2.Print();

            //SuperNormalChild snc = new SuperNormalChild();
            //snc.Print();

            //virtual override
            //TestAnimal testDog = new TestDog();
            //var res = testDog.Eat();

            // on await, task, .Result
            //Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Main method started on Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            //Console.WriteLine("\n--- Scenario 1: Using await ---");
            //// We await the result of RunAsyncOperation.
            //// The Main method itself is async.
            //// This is the correct way to consume the Task from an async Main.
            //Task asyncTask = RunAsyncOperation();

            //// While RunAsyncOperation is awaiting its Task.Delay,
            //// the Main method can continue briefly before awaiting asyncTask.
            //// Or, if there was no 'await asyncTask' here, Main would exit,
            //// and the async operation would continue in the background.
            //Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Main method: I'm free to do other things while AsyncOp runs... (1) on Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            //// Simulate a tiny bit more synchronous work on Main thread
            //Thread.Sleep(500);
            //Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Main method: Still free... (2)  on Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            //// Now, Main *awaits* for RunAsyncOperation to complete.
            //// This is where Main method pauses, but *doesn't block*.
            //// It simply registers a continuation and returns control to the .NET runtime.
            //// The application's main thread is then available until asyncTask completes.
            //await asyncTask;
            //Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Main method: AsyncOp finished. (3)  on Thread ID: {Thread.CurrentThread.ManagedThreadId}");


            //Console.WriteLine("\n--- Scenario 2: Using .Result (Blocking) ---");
            //Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Main method: About to call RunBlockingOperation.");
            //RunBlockingOperation(); // This call will block Main thread for 2 seconds
            //Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Main method: RunBlockingOperation finished. (4)  on Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            //Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss.fff}] Main method finished on Thread ID: {Thread.CurrentThread.ManagedThreadId}");


            //MyAsync().GetAwaiter().GetResult();
            //Console.WriteLine(sumOfNIntRecur(4));
            // int[] arr = { 6,1,7,4,2, 3, -1, 5 };

            // BinarySearchTreePrograms();

            //var arr = new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 11 };

            //var res = BinarySearchTree3(arr, 1);
            //Console.WriteLine(res);
            //Console.WriteLine(TestBinarySearch(7, arr));
            //Console.WriteLine(TestBinarySearch(5, arr));
            //Console.WriteLine(TestBinarySearch(2, arr));    

            //WorkWithGraphsAdjacencyMatrix();
            // WorkWithGraphsAdjacencyMatrix();

            // Quick_Sort(arr, 0, arr.Length -1);
            //for (int j = 0; j < arr.Length; j++)
            //{
            //    Console.WriteLine(arr[j]);
            //}

            //CustomList<int> list1 = new CustomList<int>();
            //var arr = new[] { 1, 2, 3, 4, 5 };
            //var res = CustomList<int>.FilterItem(arr, m1);

            //Task.Run(() => EntryMethod());
            //EntryMethod();

            //var arr = new List<int> { 1, 2, 1 };
            //var res = new List<List<int>>();
            //var tempArr = new List<int>();
            //FindSumOfNRecur(0, tempArr, res, 0, arr);

            //var arr = new List<int> { 3, 1, 2 };
            //var res = new List<List<int>>();
            //RecursionTree(arr, new List<int>(), 0, arr.Count, res);
            //---------
            //  var res = Fibonacci(5);
            //---------

            //int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            //var res = ReverseArrayRecur(arr, 0, arr[0]);
            //---------

            //  int res = sumOfNIntRecur(6);
            //---------

            //PrintNameNTimes("Alex", 4);
            //---------

            //var res = new List<int>();
            //int[] arr = { 20, 40, 50, 10, 32, 7, 22, 12, 3, 0, 6, -1, -2 }; //{6, 7, 2 , 1};  //
            ////  LeadersInArray(arr, 0, res, arr[0]);
            //var leaders = LeadersInArray2(arr);

            // var arr = new[] { 1, 2, 3 };
            // permutate(arr); // correct permutation
            // old permutaion();

            // checkDefault(null);

            // makeMatrixCrossed();

            //var data = new int[] { 2,2,4,5,4,4,4,1,1 }; // data for isAllFriend func
            //var res = isAllFriend(data);

            //var res = isPercolates();

            // var xx = BinarySearch1(0,data.Length, data, 9);
            //var perms = new Permutations<char>("abc");
            //perms.Generate();

            //var xx = Binary(0, data.Length, data, 9);
            // var xx = GCD(72, 60);

            // Console.WriteLine(res);
            #endregion

            Console.ReadLine();
        }
        public static List<string> GetSortedByLengthAndString()
        {
            var s = new string[] { "ankit", "suraj", "xyz", "abc", "de" };



            var sorted = s
                .OrderBy(x => x.Length)      // First by length
                .ThenBy(x => x)              // Then alphabetically
                .ToList();

            var first = s.ToList();
            first.Sort();
            var sec = first.OrderBy(x => x.Length).ToList();
            return sec;
        }
        public static IEnumerable<int> IntersectInHashset()
        {
            var setA = new int[] { 1, 2, 3 };
            var setB = new int[] { 1, 2, 3, 4, 5 };

            var res = setA.Intersect(setB);

            Console.WriteLine(res);
            return res;
        }

        public static string GetMoreThanOneCountCharsUsingHashSet()
        {
            string s = "bbccfgaaavv";    // abcv        // find uniqure, sorted elements having count > 1
            //string s = "baasddsdsdvxxcxcxvvzmbbc";

            var seen = new HashSet<char>();
            var final= new HashSet<char>();

            foreach (var c in s)
            {
                seen.Add(c);
            }

            var arr = new string(seen.ToArray());

            Array.Sort(arr.ToCharArray());

            return new string(arr);
        }

        public static string GetMoreThanOneCountChars()
        {
            //string s = "bbccfgaaavv"    // abcv
            string s = "baasddsdsdvxxcxcxvvzmbbc";  
            string res = "";
            var d = new Dictionary<char, int>();      // SortedDictionary already sorted

            foreach (char c in s)
            {
                if (!d.ContainsKey(c))
                {
                    d.Add(c, 1);
                }
                else
                {
                    d[c]++;
                }
            }

            foreach(var key in d.Keys)
            {
                if (d[key] > 1)
                {
                    res = res + key;
                }
            }

            // using Linq --> String.Concat((input.orderby(x => x)); 
            var sorted1 = string.Concat(res.OrderBy(x => x));

            char[] chars = res.ToCharArray();
            Array.Sort(chars);
            string sorted = new string(chars);

            var cr = res.ToCharArray();
            Array.Sort(cr);
            res = new string(cr);

           
            return res;
        }

        public static int MaxCountWithoutDict()
        {
          // var arr = new int[] { 4, 4, 3, 2, 4 };  //4 as 4 occours more than half length of the arr
           // var arr = new int[] { 4, 3, 4 };  //4 as 4 occours more than half length of the arr
            var arr = new int[] { 2, 5, 4, 5, 5,  5, 5, 4, 4 }; // 5

            int candidate = -1;
            int count = 0;

            // Phase 1: Find a potential candidate
            foreach (var num in arr)
            {
                if (count == 0)
                {
                    candidate = num;
                    count = 1;
                }
                else if (candidate == num)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }

            // Phase 2: Confirm candidate appears more than n/2 times
            int finalCount = 0;
            foreach (var num in arr)
            {
                if (num == candidate)
                    finalCount++;
            }

            if (finalCount > arr.Length / 2)
                return candidate;
            else
                return -1; // No majority element
        }

        public static void RemoveDuplicateFromList()
        {
            var arr = new int[] { 1, 2, 3, 2, 4, 5 };
            var list = arr.ToList();

            var h = new HashSet<int>();
            foreach(var a in list)
            {
                if (!h.Add(a))
                {
                    list.Remove(a);
                }
            }

            var aa = list.ToArray();
        }

        public static int MinSwapsToBalance()
        {
            string s = "(()))())";
            int balance = 0, mismatch = 0;

            foreach (char ch in s)
            {
                if (ch == '(')
                    balance++;
                else // ch == ')'
                {
                    balance--;
                    if (balance < 0)
                    {
                        mismatch++;
                        balance = 0;
                    }
                }
            }

            return (mismatch + 1) / 2;
        }

        public static string CharAndCountFromString()   //a3b2c3d2e3
        {
            var s = "aaabbccccddeee";

            var res = from c in s
                      group c by c into g
                      select new
                      {
                          c = g.Key,
                          count = g.Count()
                      };

            return "a";
        }

        public static int GetMaxNumFromString()
        {
            var s = "dsd234dsd4567cdc4598ds1298";   // max num inside - 4598
            var max = 0;
            int hold = 0;
            foreach (var c in s)
            {
                if(int.TryParse(c.ToString(), out int n))
                {
                    hold = (hold * 10) + n;
                    max = max > hold ? max : hold; 
                }
                else
                {
                    hold = 0;
                }
            }

            return max;
        }

        public static int Get6174(int num, int count)
        {
            int c = count + 1;
            var sort = num;
            var digits = num.ToString().ToCharArray().ToList();
            digits.Sort();

            var asc = int.Parse(string.Join("", digits));

            // Descending sort
            digits.Reverse();
            var desc = int.Parse(string.Join("", digits));

            var diff = desc - asc;

            if (diff == 6174)
            {
                return c;
            }
            else if(diff  == 0)
            {
                return 0;
            }
            else
                return Get6174(diff, c);
             
        }

        public static void ConsumeYield(List<int> list)
        {
            foreach(var x in GetEven(list))
            {
                Console.WriteLine(x);
            }
        }

        public static IEnumerable<int> GetEven(List<int> list)
        {
            foreach(var x in list)
            {
                if(x % 2 == 0)
                {
                    yield return x;
                }
            }
        }

        //12321
        public static bool palindromeCheck(string str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length -i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static string reverseSentence(string str)
        {
            str = "Welcome to Csharp corner";
            string[] arr = str.Split(' ');
            var o = new string[arr.Length];

            for (int i = arr.Length-1; i >= 0; i--)
            {
                o[arr.Length - i -1] = arr[i];
            }

            string res = "";

            foreach(var x in o)
            {
                res = res + x + " ";
            }

            return res.Trim();
        }

        public static string reverseEachword(string s1)
        {
            var s = "hello world";
            var o = s.Reverse().ToArray();
            var res = new string(o);
            return res;
        }

        // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to the target.
        //  Explanation: nums[0] + nums[1] = 2 + 7 = 9
        // Input: nums = [2, 7, 11, 15], target = 9  
        public static int[] addition(int[] arr, int target)
        {
            int left = target;
            int[] output = new int[2];
            for (var i = 0; i < arr.Length; i++)
            {
                output[0] = arr[i];
                left = target - arr[i];

                for( var j = i + 1; j < arr.Length; j++)
                {
                    if(left - arr[j] == 0)
                    {
                        output[1] = arr[j];
                        left = 0;
                        break;
                    }
                }

                if(left == 0)
                {
                    break;
                }
            }
            return output;
        }

        public static int[] addition2(int[] arr, int target)
        {
            int left = target;
            int[] output = new int[2];

            var dict = new Dictionary<int, int>();
            for(int i = 0; i < arr.Length;i++)
            {
                output[0] = arr[i]; 
                left = target - arr[i];
                if (dict.ContainsKey(left))
                {
                    output[1] = left;
                    break;
                }
                dict.Add(arr[i], left);
            }
            
            return output;
        }

        public static string reverseStr(string str)
        {
            var ch = new Char[str.Length];
            for(int i =0, j = str.Length - 1; i < j; i++, j --)
            {
                ch[i] = str[j];
                ch[j] = str[i];
            }

            var o = new string(ch);

            return o;
        }
        public static string reverse1(string s)
        {
            var o = new Char[s.Length];
            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                o[i] = s[j];
                o[j] = s[i];
            }

            var result = new string(o);
            return result;
        }

        public static void CharGrouping()
        {
            ////1 dictionary, add data from dict to another which are not there
            ///
            var d1 = new Dictionary<string, int>();
            d1.Add("a", 1);
            d1.Add("ab", 2);
            d1.Add("ac", 3);
            d1.Add("as", 4);
            d1.Add("aa", 5);

            var d2 = new Dictionary<string, int>();
            d2.Add("z", 2);
            d2.Add("ac", 21);
            d2.Add("zf", 23);
            d2.Add("aa", 24);

            foreach (var x in d1.Keys)
            {
                if (!d2.ContainsKey(x))
                {
                    d2.Add(x, d1[x]);
                }
            }

            foreach (var y in d2.Keys)
            {
                Console.WriteLine(d2[y]);
            }

            string[] words = { "cat", "dog", "ant", "duck", "bird", "elephant", "lion" };

            // group by length and sort by alphabets inside also
            var g2 = from w in words
                     group w by w.Length into gr
                     select new
                     {
                         key = gr.Key,
                         words = gr.OrderBy(x => x).ToList()
                     };

            var groupedAndSorted = words
             .GroupBy(w => w.Length)     // 1. Group by word length
             .OrderBy(g => g.Key)        // 2. Order the groups by their key (length)
             .Select(g => new           // 3. Project into a new anonymous type
             {
                 Length = g.Key,
                 Words = g.OrderBy(w => w).ToList() // 4. Order words *within* each group alphabetically
             });


            // ⏳ 5.Find Top 3 Longest Words and also sort alphabaticallys
            string[] words2 = { "apple", "mangos", "banana", "payaya", "pear", "grapefruit", "kiwi" };
            var longestWords = words2
                    .OrderByDescending(w => w.Length)
                    .ThenBy(w => w) // Alphabetical order for same length
                    .Take(3);

            var employees = new List<Employee>
                {
                    new Employee { Id = 1, Name = "John", DepartmentId = 1, Salary = 1000 },
                    new Employee { Id = 2, Name = "Jane", DepartmentId = 2 , Salary = 1010 },
                    new Employee { Id = 3, Name = "Tom", DepartmentId = 3 , Salary = 1004 },
                    new Employee { Id = 4, Name = "Alex", DepartmentId = 1 , Salary = 1040 },
                    new Employee { Id = 5, Name = "Rohit", DepartmentId = 2 , Salary = 1050 },
                    new Employee { Id = 6, Name = "Rohit", DepartmentId = 2 , Salary = 1050 },
                     new Employee { Id = 7, Name = "Raj", DepartmentId = 4 , Salary = 1002 },
                    new Employee { Id = 8, Name = "Peter", DepartmentId = 1, Salary = 1010  },
                    new Employee { Id = 9, Name = "Allen", DepartmentId = 2 , Salary = 1003 },
                    new Employee { Id = 10, Name = "Mike", DepartmentId = 0, Salary = 1009  } // No department
                };

            var departments = new List<Department>
                {
                    new Department { Id = 1, DeptName = "HR" },
                    new Department { Id = 2, DeptName = "Finance" },
                    new Department { Id = 4, DeptName = "Science" },
                };

            // select emp who salary greater than 1020
            var res = from e in employees
                      where e.Salary > 1020
                      select e;

            var joinOutput = from e in employees
                     join d in departments
                     on e.DepartmentId equals d.Id into temp
                     select temp;

            foreach(var t in joinOutput)    // contains all matched elements
            {
                var x = t.FirstOrDefault();
                Console.WriteLine(x != null ?  x.DeptName : " No match");
            }

            // provide grouped data
            var groupOutput = from e in employees
                             join d in departments
                             on e.DepartmentId equals d.Id
                             group e by d.DeptName into g
                             select g;
                             

            foreach (var t in groupOutput)      // contains 3 groups
            {
                var x = t.FirstOrDefault();
                Console.WriteLine(x);
            }


            //  provide only deptname and id not emp info
            var groupbyDepCount1 = from e in employees
                                  join d in departments
                                  on e.DepartmentId equals d.Id
                                  into temp
                                  from t in temp
                                  group t by t.DeptName into g
                                  select new
                                  {
                                      name = g.Key,
                                      empGroup = g
                                  };



            // Need Group by DeptName  Output -
            //name = HR, count = 1
            //name = Finance, count = 2
            //name = Science, count = 3

            // shows name and id
            var groupbyDepCount = from e in employees
                                  join d in departments
                                  on e.DepartmentId equals d.Id
                                  group e by d.DeptName into g
                                  select new
                                  {
                                      name = g.Key,
                                      count = g.Count()
                                  };

            // Need  Output -
            //DepartmentId = 1, TotalSalary = 4300
            //DepartmentId = 2, TotalSalary = 4500

            var groupbysalary = from e in employees
                                group e by e.DepartmentId into g
                                select new
                                {
                                    id = g.Key,
                                    salary = g.Sum(x => x.Salary)
                                };

            ////inner join
            var innerRes = from e in employees
                           join d in departments
                           on e.DepartmentId equals d.Id
                           select new
                           {
                               Id = e.Id,
                               EmpName = e.Name,
                               DepName = d.DeptName
                           };

            ////left join
            var resLeft = from e in employees
                      join d in departments
                      on e.DepartmentId equals d.Id
                      into deptGroup                // ← group join
                      from d in deptGroup.DefaultIfEmpty()
                      select new
                      {
                          Empid = e.Id,
                          Name = e.Name,
                          DeptName = d != null ? d.DeptName : "na"
                      };

            foreach (var e in resLeft)
            {
                Console.WriteLine(e.Empid + " - " + e.Name + " " + e.DeptName);
            }

            // third highest salary
            var resSalary = (from e in employees
                            group e by e.Salary
                            into temp
                            orderby temp.Key descending
                            from t in temp
                            select new
                            {
                                salary = t.Salary,
                                temp = t
                            }).Skip(2).First();

            Console.WriteLine("Third highest salary = " + resSalary.salary + " Emp name = " + resSalary.temp.Name);

            // filter out/remove duplicate

            var resGroup =  (from e in employees
                      group e by new { e.Name, e.Salary, e.DepartmentId }
                      into temp
                      where temp.Count() > 1
                      select new {
                          id = temp.Key,
                          temp = temp
                      }).First().temp.Skip(1);

            //💡 Improved LINQ Query(Keeping One, Removing Rest)
            var distinctEmployees = employees
                .GroupBy(e => new { e.Name, e.Salary, e.DepartmentId })
                .Select(g => g.First());

            var first = resGroup.FirstOrDefault();

            //string s = "skjdnsjdsjsldsdslsd";

            //var res = from x in s
            //          group x by x into temp
            //          select new { temp.Key, temp };

            //Find all users who have made the same purchase (same item, same amount) more than once.
            var purchases = new List<Purchase>
            {
                new Purchase { UserId = 1, Item = "Laptop", Amount = 1000m, PurchaseDate = DateTime.Parse("2024-01-01") },
                new Purchase { UserId = 1, Item = "Laptop", Amount = 1000m, PurchaseDate = DateTime.Parse("2024-01-15") },
                new Purchase { UserId = 2, Item = "Mouse", Amount = 25m, PurchaseDate = DateTime.Parse("2024-02-01") },
                new Purchase { UserId = 2, Item = "Keyboard", Amount = 45m, PurchaseDate = DateTime.Parse("2024-02-05") },
                new Purchase { UserId = 2, Item = "Mouse", Amount = 25m, PurchaseDate = DateTime.Parse("2024-02-10") },
                new Purchase { UserId = 2, Item = "Mouse", Amount = 25m, PurchaseDate = DateTime.Parse("2024-02-11") },
                new Purchase { UserId = 3, Item = "Monitor", Amount = 300m, PurchaseDate = DateTime.Parse("2024-03-01") },
                new Purchase { UserId = 3, Item = "Monitor", Amount = 300m, PurchaseDate = DateTime.Parse("2024-04-01") },
                new Purchase { UserId = 3, Item = "Monitor", Amount = 350m, PurchaseDate = DateTime.Parse("2024-03-10") }, // different amount, won't be counted
                new Purchase { UserId = 1, Item = "Laptop", Amount = 900m, PurchaseDate = DateTime.Parse("2024-01-20") } // different amount
            };
            //
            var duplicatePurchases = purchases.GroupBy( p => new {p.UserId, p.Item, p.Amount })
                .Where(g => g.Count() > 1)
                .Select(g => new
                {
                    UserId = g.Key.UserId,
                    Item = g.Key.Item,
                    Amount = g.Key.Amount,
                    count = g.Count(),
                });

            foreach (var purchase in duplicatePurchases)
            {
                Console.WriteLine("item - " + purchase.Item + " amount " + purchase.Amount + " user " + purchase.UserId + " count " + purchase.count);
            }

            int[] arr = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };

            var ss = "Iam xyz Iam from Bangalore and Iam an Engineer.Bangalore is the IT capital and Iam a resident from 2020";

            var split = ss.Split(" ");
            var stringGrouped = from e in split
                                group e by e into temp
                                select new
                                {
                                    Key = temp.Key,
                                    count = temp.Count()
                                };

            foreach (var y in stringGrouped)
            {
                Console.WriteLine(y.Key.ToString() + " - " + y.count);
            }

            // for Count > 1
            var stringGrouped1 = from e in split
                                group e by e into temp
                                where temp.Count() > 1
                                select new
                                {
                                    Key = temp.Key,
                                    count = temp.Count()
                                };

            foreach (var y in stringGrouped1)
            {
                if(y.count > 1)
                Console.WriteLine(y.Key.ToString() + " - " + y.count);
            }
        }

        public static int BinarySearchTree3(int[] arr, int num)
        {
            int left = 0;
            int right = arr.Length -1;
            int mid = (right - left) / 2;

            int midEl = arr[mid];
            if(num == midEl)
            {
                return num;
            }
            else if(num > midEl)
            {
                left = mid + 1;
            }
            else if(num < midEl)
            {
                right = mid -1;
            }
            else
            {
                return 0;
            }
            return BinarySearchTreeHelper3(arr, left, right, num);
        }

        private static int BinarySearchTreeHelper3(int[] arr, int left, int right, int num)
        {
            int mid = left + (right - left) / 2;
            int midEl = arr[mid];
            if(midEl == num)
            {
                return num;
            }
            else if (num > midEl)
            {
                left = mid + 1;
            }
            else if (num < midEl)
            {
                right = mid - 1;
            }
            else
            {
                return 0;
            }

                return BinarySearchTreeHelper3(arr, left, right, num);
        }

        private static int TestBinarySearch2(int[] arr, int num)
        {
            var mid = arr.Length / 2;
            int left = 0;
            int right = arr.Length - 1;
            int ma = arr[mid];
            if (ma == num)
            {
                return mid;
            }
            else if (ma < num)
            {
                right = mid - 1;
            }
            else if (ma > num)
            {
                left = mid + 1;
            }
            else
            {
                return 0;
            }

            return BinarySearchHelper2(arr, left, right, num);   
        }

        private static int BinarySearchHelper2(int[] arr, int left, int right, int num)
        {
            var mid = left + (right - left) / 2;
            var midItem = arr[mid];

            if (midItem == num)
            {
                return mid;
            }
            else if (num < midItem)
            {
                right = mid - 1;
                return BinarySearchHelper2(arr, left, right, num);
            }
            else
            {
                left = arr.Length / 2 + mid + 1;
                return BinarySearchHelper2(arr, left, right, num);
            }
        }

        // Simulate an I/O-bound operation (like a network call or file read)
        // This method is truly asynchronous; it doesn't block a thread during the delay.
        private static async Task<string> PerformIOBoundOperation(string operationName, int delayMs)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {operationName}: Started on Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(delayMs); // Simulate actual async I/O
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {operationName}: Finished on Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"{operationName} Result";
        }

        // This method will use await and is non-blocking
        private static async Task RunAsyncOperation()
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] RunAsyncOperation: Invoked on Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            // When await is hit, control returns to the caller of RunAsyncOperation (which is Main in this case).
            // The Main thread will then be free to exit or continue if there's other code.
            string result = await PerformIOBoundOperation("AsyncOp", 2000); // 2-second delay

            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] RunAsyncOperation: Resumed after await with: {result} on Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }

        // This method will use .Result and is blocking
        private static void RunBlockingOperation()
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] RunBlockingOperation: Invoked on Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            // This line BLOCKS the calling thread (the Main thread in this example)
            // until PerformIOBoundOperation fully completes.
            string result = PerformIOBoundOperation("BlockingOp", 2000).Result; // 2-second delay

            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] RunBlockingOperation: Completed with: {result} on Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }
        private static int TestBinarySearch(int n, int[] arr)
        {
            // var data = new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 11 };
            int len = arr.Length;
            int left = 0;
            int right = len - 1;
            if (n == arr[len / 2]) { return len / 2; }
            else if (n < arr[len / 2])
            {
                left = 0;
                right = len/2 - 1;

                return TestBinarySearch1(n, left, right, arr);
            }
            else
            {
                left = len/2 - 1;
                return TestBinarySearch1(n, left, right, arr);
            }
        }

        private static int TestBinarySearch1(int n, int left, int right, int[] arr)
        {
            int mid = left + (right - left) / 2;
            if (n == arr[mid])
            {
                return mid;
            }
            else if(n < arr[mid])
            {
                right = mid - 1;
                return TestBinarySearch1(n, left, right, arr);
            }
            else if((left == right) && n != arr[left])
            {
                return 0;
            }
            else
            {
                left = mid + 1;
                return TestBinarySearch1(n, left, right, arr);
            }
        }

        private static void BinarySearchTreePrograms()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(new NodeBT(3));
            tree.Insert(new NodeBT(4));
            tree.Insert(new NodeBT(1));
            tree.Insert(new NodeBT(6));
            tree.Insert(new NodeBT(5));
            tree.Insert(new NodeBT(9));
            tree.Insert(new NodeBT(7));
            tree.Insert(new NodeBT(2));
            tree.Insert(new NodeBT(8));

            tree.Remove(5); // issues

            tree.Display();

            var res = tree.Search(7);
        }

        private static void WorkWithGraphsAdjacencyList()
        {
            TestQ.Graphs.Graph graph = new TestQ.Graphs.Graph();
            graph.AddNode(new Node1('A'));
            graph.AddNode(new Node1('B'));
            graph.AddNode(new Node1('C'));
            graph.AddNode(new Node1('D'));
            graph.AddNode(new Node1('E'));

            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(4, 0);
            graph.AddEdge(2, 4);
            graph.AddEdge(4, 2);

            graph.Print();

            Console.WriteLine(graph.CheckEdge(1, 2)); // B & C - should be true, similar to adjacency matrix 

            Console.WriteLine(graph.CheckEdge(0, 2)); // B & C - should be false,  similar to adjacency matrix 
        }
        // pic attached
        private static void WorkWithGraphsAdjacencyMatrix()
        {
            Graph graph = new Graph(5);
            graph.AddNode(new Node1('A'));
            graph.AddNode(new Node1('B'));
            graph.AddNode(new Node1('C'));
            graph.AddNode(new Node1('D'));
            graph.AddNode(new Node1('E'));

            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(4,0);
            graph.AddEdge(2,4);
            graph.AddEdge(4,2);

            graph.Print();

            // graph.depthFirstSearch(4);
            graph.BreadthFirstSearch(4);
        }
        public static void HashTable()
        {
            Hashtable ht = new Hashtable();

            // Adding values
            ht.Add(100, "Bob");
            ht.Add(123, "Patrik");
            ht.Add(321, "Sandy");
            ht.Add(444, "Squid");
            ht.Add(777, "Gary");
        }
        private static void Quick_Sort(int[] arr, int left, int right)
        {
            // Check if there are elements to sort
            if (left < right)
            {
                // Find the pivot index
                int pivot = Partition(arr, left, right);

                // Recursively sort elements on the left and right of the pivot
                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }
        }
        // Method to partition the array
        private static int Partition(int[] arr, int left, int right)
        {
            // Select the pivot element
            int pivot = arr[left];

            // Continue until left and right pointers meet
            while (true)
            {
                // Move left pointer until a value greater than or equal to pivot is found
                while (arr[left] < pivot)
                {
                    left++;
                }

                // Move right pointer until a value less than or equal to pivot is found
                while (arr[right] > pivot)
                {
                    right--;
                }

                // If left pointer is still smaller than right pointer, swap elements
                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    // Return the right pointer indicating the partitioning position
                    return right;
                }
            }
        }

        public static void Merge(int[] left, int[] right, int[] arr)    // not working
        {
           int leftSize = arr.Length/2;
           int rightSize = arr.Length/2 - leftSize;
           int i = 0, l = 0, r = 0;

            while (l < leftSize && r < rightSize) {
                if (left[l] < right[r]) {
                    arr[i] = left[l];
                    i++;
                    l++;
                }
                else
                {
                    arr[i] = right[r];
                    i++;
                    r++;
                }
            }

            while(l < leftSize)
            {
                arr[i] = left[l];
                i++;
                l++;
            }
            while(r < rightSize)
            {
                arr[i] = right[r];
                i++;
                r++;
            }
        }

        public static void MergeSort(int[] arr)
        {
            int len = arr.Length;
            int middle = len / 2;

            if(len <= 1) { return; }

            int[] leftArr = new int[middle];
            int[] rightArr = new int[len - middle];

            int i = 0;
            int j = 0;

            for (; i < len; i++)
            {
                if (i < middle)
                {
                    leftArr[i] = arr[i];
                }
                else
                {
                    rightArr[j] = arr[i];
                    j++;
                }
            }

            MergeSort(leftArr);
            MergeSort(rightArr);
            Merge(leftArr, rightArr, arr);
        }

        public static void InsertionSort(int[] arr) // O(n square)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];

                for(int j = i; j >= 1; j--)
                {
                    if (arr[j-1] > arr[j])
                    {
                        arr[j] = arr[j-1];
                        arr[j - 1] = temp;
                    }
                }
            }
        }

        public static void bubbleSort(int[] input)
        {
            int temp = 0;
            for (int i = 0; i < input.Length-1; i++)
            {
                for (int j = 0; j < input.Length -1 -i; j++)
                {
                    if (input[j] > input[j + 1])
                    {
                        temp = input[j];
                        input[j] = input[j + 1];
                        input[j + 1] = temp;
                    }
                }
            }
        }

        public static void selectionSort(int[] arr)
        {
            int temp = 0;
            for (int i =0; i < arr.Length; i++)
            {
                var lowest = arr[i];
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < lowest)
                    {
                        lowest = arr[j];
                        temp = j;
                    }
                }
                arr[temp] = arr[i];
                arr[i] = lowest;
            }
        }

        public static int binarySearch(int[] arr, int target)
        {
            int low = 0;
            int high = arr.Length - 1;

            while(high >= low)
            {
                int middle = low + (high - low) / 2;
                if (target == arr[middle])
                {
                    return middle;
                }
                else if (arr[middle] > target)
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }
            }
            return -1;
        }

        public static void RecMethod( string s, List<string> list)   //india --> i, in, ind, ... n, nd, ndi ... , d, di, ..i,ia, a
        {
            if (s.Length > 0)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    var split = s.Substring(0, i+1);
                    list.Add(split);
                }
                 RecMethod(s.Substring(1), list);
            }
            return;
        }

        static void Print4321Pattern(int input) {
            for (int i = input; i > 0; i--)
            {
                for(int j = i; j > 0; j--)
                {
                    Console.Write(j);
                }
                Console.WriteLine("");
            }
        }
        static void Print1234Pattern(int input)
        {
            int c = 1;
            for (int i = 0; i < input; i++)
            {
                for(int j = 0; j <=i; j++)
                {
                    Console.Write(c);
                    c++;
                }
                Console.WriteLine("");
            }
        }

        static string RemoveLastComma(string s)
        {
            string res = s;
            if (s[s.Length -1] == ',')
            {
                res = s.Substring(0, s.Length - 1);
            }
            return res;
        }

        public static async Task<object> RunTasksSync()
        {
            var d = DateTime.Now;

            var task1 = await M1();
            var task2 = await M2();
            var task3 = await M3();

            var d2 = DateTime.Now;

            var diff = d2 - d;

            var data = new
            {
                a = task1,
                b = task2,
                c = task3,
                time = diff,
            };

            Console.WriteLine(data);
            return data;
        }
        public static async Task<object> RunTaskWithErrorHandling()
        {
            var d = DateTime.Now;

            var task1 =  M1();
            var task2 =  M2();
            var task3 =  M3();

            var tasks = new [] {task1, task2, task3 };

            try
            {
                // pass tasks as variable to get all the results in TResult[]
                var allResults = await Task.WhenAll(task1, task2, task3);  // total time now is 2.0012

                var runResult =  await Task.WhenAll(tasks);

            }
            catch (Exception ex)
            {
               foreach( var t in tasks){
                    if (t.IsFaulted)
                    {
                        // Log or inspect t.Exception
                    }
                    else if(t.IsCompleted)
                    {
                        // t completed successfully
                    }
                }

                return (500, "One or more tasks failed.");
            }

            // All tasks completed successfully
            var news = await task1;
            var d2 = DateTime.Now;
            var diff = d2 - d;

            var data = new
            {
                taks1 = tasks[0].Status,
                taks2 = task2.Status,
                time = diff
            };
            Console.WriteLine(data);
            return data;
        }
        static async Task Starter()
        {
            await M1();
            await M2();
              Console.Write("c");
        }

        static async Task Finisher()
        {
            await M3();
            await M4();
            Console.Write("d");
        }

        public static async Task<string> M1() {
            await Task.Delay(2000);
            return "M1 result";
        }
        public static async Task<string> M2() { 
            await Task.Delay(2000);
            return "M2 result";
        }
        public static async Task<string> M3() { await Task.Delay(2000); 
            return "M3 result"; }
        public static async Task M4() { await Task.Delay(2000); }
        public static bool GoodExp(Employee emp)
        {
            return emp.Exp > 5;
        }
        public static bool GoodProjects(Employee emp)
        {
            return emp.Projects > 10;
        }
        public static async void EntryMethod()
        {
            Console.Write("a");
            await Starter();

            Console.Write("b");

            Finisher();

            Console.Write("e");
            //// Create a cancellation token source
            //var cts = new CancellationTokenSource();
            //CancellationToken token = cts.Token;

            //// Start the asynchronous operation
            //Task task = SomeAsyncOperation(token);

            //// Wait for some time
            //await Task.Delay(2000);

            //// Cancel the operation
            //cts.Cancel();

            //try
            //{
            //    // Wait for the task to complete
            //    await task;
            //}
            //catch (OperationCanceledException)
            //{
            //    Console.WriteLine("Operation was canceled before it could be completed.");
            //}
        }

        public static async Task<string> MyAsync()
        {
            Console.WriteLine("start the first method");
            await Starter();
            Console.WriteLine("after starter");

            await Finisher(); ;
            Console.WriteLine("after finisher");
            return "abc";
        } 
        public static async Task SomeAsyncOperation(CancellationToken token)
        {
            await Task.Delay(1000, token); // Simulate a long-running operation
            Console.WriteLine("Async operation completed.");
        }
        private static List<string> GetFilteredQueriesPerLanguageMarket1(string[] queries, string market)
        {
            List<string> filteredQueries = new List<string>();

            if (queries == null || queries.Length == 0 || string.IsNullOrEmpty(market))
            {
                return filteredQueries;
            }

            string targetMarket = market.Contains("xx") ? market.Substring(0, market.IndexOf("-")) : market;

            foreach (string query in queries)
            {
                string[] splitQuery = query.Split(';');
                //in case language contains strings like en-*
                if (splitQuery.Length > 1 && splitQuery[1].Contains("*"))
                {
                    splitQuery[1] = splitQuery[1].Substring(0, splitQuery[1].IndexOf("-"));
                }

                if (splitQuery.Length == 2 && splitQuery[1].Trim() == targetMarket)
                {
                    filteredQueries.Add(splitQuery[0]);
                }
            }

            return filteredQueries;
        }

        private static List<string> GetFilteredQueriesPerLanguageMarket(string[] queries, string market)
        {
            List<string> filteredQueries = new List<string>();

            if (queries == null || queries.Length == 0 || string.IsNullOrEmpty(market))
            {
                return filteredQueries;
            }

            string targetMarket = market.Contains("-xx") ? market.Substring(0, market.IndexOf("-")) : market;

            foreach (string query in queries)
            {
                string[] splitQuery = query.Split(';');
                string language = splitQuery[1] ?? "";
                if (splitQuery.Length > 1 && splitQuery[1].Contains("*"))           //Query with ;en-*
                {
                    language = splitQuery[1].Substring(0, splitQuery[1].IndexOf("-"));
                }
                else if(splitQuery.Length == 2 && splitQuery[1].Contains("-xx"))    //Query with ;en-xx
                {
                    language = splitQuery[1].Substring(0, splitQuery[1].IndexOf("-"));
                }
                else if (market.Contains("-xx") && splitQuery[1].IndexOf("-") > 0) // Query with ;en-us and market en-xx
                {
                    language = splitQuery[1].Substring(0, splitQuery[1].IndexOf("-"));
                }

                if (splitQuery.Length == 2 && language.Trim() == targetMarket)
                {
                    filteredQueries.Add(splitQuery[0]);
                }
            }

            return filteredQueries;
        }

        // https://www.youtube.com/watch?v=eQCS_v3bw0Q&list=PLgUwDviBIf0rGlzIn_7rsaR2FQ5e6ZOL9&index=7 // output => [2], [1,1]
        // Finding array with sum == 2
        // image attached for this
        private static void FindSumOfNRecur(int index, List<int> tempArr, List<List<int>> list, int sum, List<int> input)
        {
            if(index >= input.Count)
            {
                if (sum == 2)
                { 
                    list.Add(new List<int>(tempArr)); 
                }
                return;
            }

            sum = sum + input[index];
            tempArr.Add(input[index]);
            FindSumOfNRecur(index + 1, tempArr, list, sum, input);
            tempArr.Remove(input[index]);
            sum = sum - input[index];
            FindSumOfNRecur(index + 1, tempArr, list, sum, input);
        }

        //https://www.youtube.com/watch?v=AxNNVECce8c&list=PLgUwDviBIf0rGlzIn_7rsaR2FQ5e6ZOL9&index=6
        //Recursion on Subsequences | Printing Subsequences // [3,1,2] => 1,2,3,,12,31,312,32
        private static void RecursionTree(List<int> arr, List<int> temp, int index, int n, List<List<int>>  list)
        {
          //  var res = new List<List<int>>();
            if(index >= n)
            {
                list.Add(new List<int>(temp));
                Console.WriteLine(temp);
                return;
            }

            temp.Add(arr[index]);
            RecursionTree(arr, temp, index + 1, n, list);
            temp.Remove(arr[index]);
            RecursionTree(arr,temp, index + 1, n, list);
        }

        private static int[] ReverseArrayRecur(int[] arr, int index, int temp)
        {
            if (index >= arr.Length/2)
            {
                return arr;
            }

            temp = arr[index];

            arr[index] = arr[arr.Length - index -1];
            ReverseArrayRecur(arr, index + 1, temp);
            arr[arr.Length - index - 1] = temp;
            return arr;
        }

        private static int Fibonacci(int n)
        {
            if(n <= 1)
            {
                return n;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        private static int sumOfNIntRecur(int n)
        {          
            if(n == 0)
            {
                return 0;
            }
            else
            {
                return sumOfNIntRecur(n - 1) + n;
            }
        }

        private static void PrintNameNTimes(string name, int n)
        {
            if(n == 0) { return; }
            Console.WriteLine(name);
            PrintNameNTimes(name, n - 1);
        }

        #region methods
        // get all int which are largest compared to the right side of array
        // ref , differnt from - https://www.youtube.com/watch?v=cHrH9CQ8pmY
        private static void LeadersInArray(int[] arr, int index, List<int> res, int max) // { 22, 12, 4, 0, 6 - 2, -1 } // 10, 22, 12, 3, 0, 6 
        {
            for (int i = index; i < arr.Length; i++)
            {
                if ((i + 1 < arr.Count()) && arr[i + 1] > max)
                {
                    max = arr[i + 1];
                    index = i + 1;
                }

                if (i == arr.Count() - 2 || (index + 1 == arr.Length))
                {
                    res.Add(max);
                    if (index + 1 == arr.Count())
                    {
                        return;
                    }
                    LeadersInArray(arr, index + 1, res, arr[index + 1]);
                }
            }
        }

        //Another simple way
        private static List<int> LeadersInArray2(int[] arr)  // { 22, 12, 4, 0, 6 - 2, -1 } 
        {
            var res = new List<int>();
            int max = arr[arr.Length - 1];
            res.Add(max);
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    res.Add(max);
                }
            }

            res.Reverse();
            return res;
        }

        //https://www.youtube.com/watch?v=f2ic2Rsc9pU&t=907s
        private static void recurPurmutate(int index, List<List<int>> res, int[] arr) //[1,2,3] -->  [1,2,3], [1,3,2], [2,1,3], [2,3,2] , [3,1,2], [3,2,1]
        {
            if (index == arr.Length)
            {
                res.Add(arr.ToList());
                index = 0;
                return;
            }
            for (int i = index; i < arr.Length; i++)
            {
                Swap(i, index, arr);
                recurPurmutate(index + 1, res, arr);
                Swap(i, index, arr);
            }
        }
        private static void Swap(int i, int j, int[] arr)
        {
            var temp = arr[i]; arr[i] = arr[j]; arr[j] = temp;
        }
        //https://www.youtube.com/watch?v=f2ic2Rsc9pU&t=907s
        public static List<List<int>> permutate(int[] arr) // arr = [1,2,3] -->  [1,2,3], [1,3,2], [2,1,3], [2,3,2] , [3,1,2], [3,2,1]
        {
            int index = 0;
            var res = new List<List<int>>();
            recurPurmutate(index, res, arr);
            return res;
        }
        public static void checkDefault(int? xxx = 1)
        {
            var test = xxx;
            Console.Write(xxx);
        }
        private static bool isAllFriend(int[] arr)
        {
            var obj = new QuickUnionUF(arr);
            bool res = true;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                while (obj.root(arr[i]) != obj.root(arr[i + 1]))
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
        private static int GCD(int m, int n)
        {
            if (m%n == 0) return n;
            return GCD(n, m % n);
        }
        private static int BinarySearch1(int left, int right, int[] data, int v)
        {
            // var data = new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 11 };
            if( right - left <= 0) return -1;
            int mid = (left + right)/2;

            if (data[mid] == v) { return mid; }

            if (data[mid] > v) { right = mid - 1; }
            if (data[mid] < v) {
                left = mid + 1;
            }
            

            return BinarySearch1(left, right, data, v);

        }
        private static int BinarySearch(int left, int right, int[] data, int v)                                                                                     
        {
           // var data = new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 11 };

            int midIndex = (left + right) / 2;
            int mid = data[midIndex];
            if (((left == right) || (left + 1 == right)) && (mid != v))
            {
                return -1;
            }
            if (mid > v)
            {
                right = midIndex;
                return BinarySearch(left, right-1, data, v);
            }
            if(mid < v)
            {
                left = midIndex;
                return BinarySearch(left+1, right, data, v);
            }
            if(mid == v)
            {
                return midIndex;
            }
           
            return -1;
        }
        public static int fib(int n)
        {
            if(n == 0) return 0;
            if(n == 1) return 1;
            return fib(n - 1) + fib(n-2);
        }
        public static string BinaryConverter(int n)
        {
            string s = "";
            if (n <= 1)
            {
                return "1";
            }
            return BinaryConverter(n / 2) + (n % 2).ToString();
        }
        private static void LinkedListOps()
        {
            LinkedList list = new LinkedList();

            Node top = new Node(1);
            list.addToEnd(top, new Node(2));
            list.addToEnd(top, new Node(3));
            list.addToEnd(top, new Node(4));
            //list.addToEnd(top, new Node(5));

            printList(top);

            top = reverseLinkedList(top);

            printList(top);
        }
        public static Node reverseLinkedList(Node head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            Node newHead = reverseLinkedList(head.next);
            Node newNode = head.next;
            newNode.next = head;
            head.next = null;
            return newHead;

        }
        public static void printList(Node top)
        {
            while (top != null)
            {
                Console.WriteLine(top.value);
                top = top.next;
            }
        }
        public static async Task method1()
        {
            Console.WriteLine("task start");
            await method2();
            Console.WriteLine("task completed");
        }
        public static async Task method2()
        {
            Console.WriteLine("method2 start");
            await Task.Delay(5000);
            Console.WriteLine("method2 end");

        }
        internal static void RotateLeft()
        {
            int[] array = new int[5] { 1, 2, 3, 4, 5 };
            int size = array.Length;
            int temp;


            for(int i = 0; i < size-1; i++)
            {
                temp = array[i+1];
                array[i + 1] = array[i];
                array[i] = temp;
            }

            //for (int j = size - 1; j > 0; j--)
            //{
            //    temp = array[size - 1];
            //    array[array.Length - 1] = array[j - 1];
            //    array[j - 1] = temp;
            //}

            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
        }

        //int ticket1 = TicketCounter.GiveTicket();
        //int ticket2 = TicketCounter.GiveTicket();
        //int ticket3 = TicketCounter.GiveTicket();

        //static bool checkedAdjecent = false;
        //static int rowChecked = 0;
        //static int colChecked = 0;
        //static bool moveLeft = false;
        static bool[,] grid = new bool[10, 8]
                {
                   { true, true,  false, false,  false,  false,true,false },
                   { false, true, true,   false,  false,  false,true,true },
                   { false, false, true,  true,   false,  false,false,true  },
                   { false, true,  true,  true,   false,  false,true,true },
                   { true,  false,  false, false,  true ,  false, true,false  },
                   { false, true, false, false,  true  , true,true,false },
                   { true,  true, false,   true,  true  , true,true,false },
                   { true,  true, false,  false,  true  , false,true,false },
                   { true, true, false,   false,  true  , false,true,true },
                   { false, false, false,  true,  false , false,false,true }
                };
        public static bool isPercolates()
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            bool[,] visited = new bool[10, 8];

            for (int col = 0; col < cols; col++)
            {
                if (grid[0, col]  && !visited[0, col])
                {
                    if(DFS(0, col,rows, cols, visited))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool DFS(int row, int col, int rows, int cols, bool[,] visited)
        {
            if(row == rows - 1)
            {
                return true;
            }
            if (grid[row, col])
            {
                visited[row, col] = true;
            }

            int[] dr = {-1, 0, 1,  0 };
            int[] dc = {0,  1, 0, -1 };

            for(int i = 0; i < 4; i++)
            {
                int newRow = row + dr[i];
                int newCol = col + dc[i];

                if ( newRow < rows && newCol < cols && col < cols && row < rows && newRow >=0 && newCol >=0 &&
                    grid[newRow, newCol] && !visited[newRow, newCol])
                    {
                        return DFS(newRow, newCol, rows, cols, visited);  
                    }
            }
            return false;
        }

        static int[,] grid1 = {
            {1, 1, 0, 1, 0},
            {1, 0, 1, 1, 1},
            {1, 1, 1, 1, 1},
            {0, 0, 0, 1, 1}
        };
        public static void makeMatrixCrossed()
        {
            var rows = new int[4];
            var cols = new int[5];
            for (int i = 0; i < grid1.GetLength(0); i++)
            {
                for(int j = 0; j < grid1.GetLength(1); j ++ )
                {
                    if (grid1[i,j] == 0)
                    {
                        rows[i] = 1;
                        cols[j] = 1;
                    }
                }
            }

            makeZero(rows, cols);
        }
        public static void makeZero(int[] rows, int[] cols)
        {
            for (int i = 0; i < grid1.GetLength(0); i++)
            {
                for (int j = 0; j < grid1.GetLength(1); j++)
                {
                    if ((rows[i] == 1 || cols[j] == 1))
                    {
                        grid1[i, j] = 0;
                    }
                }
            }
        }
        public static void printPascalTriangle(int n)
        {
            n = 7;
            var arr = new int[n,n];
            arr[0, 0] = 1;
            for (int i = 0; i < n; i++)
            {
                for( int j = 0; j <= i;  j++)
                {
                    if (j > 0 && i > 0)
                    {
                        arr[i, j] = arr[i - 1, j - 1] + arr[i - 1, j];
                    }
                    else
                    {
                        arr[i, j] = 1;
                    }
                    Console.Write(arr[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void permutaion()
        {
            //            Problem statement
            //You are given an array ‘a’ of ‘n’ integers.
            //You have to return the lexicographically next to greater permutation.
            //Note:
            //If such a sequence is impossible, it must be rearranged in the lowest possible order.
            //Example:
            //        Input: 'a' = [1, 3, 2]
            //Output: 2 1 3
            //Explanation: All the permutations of[1, 2, 3] are[[1, 2, 3], [1, 3, 2], [2, 1, 3], [2, 3, 1], [3, 1, 2], [3, 2, 1], ].Hence the next greater permutation of[1, 3, 2] is [2, 1, 3].

            int[] arr = new int[] { 2,5,4,3,1 }; // --> 1432, 1234

            for (int i = arr.Length-1-1; i >= 0; i--)
            {
                var smallest = arr[i + 1];
                if ((smallest > arr[i]))
                {
                    var temp = arr[i];
                    arr[i] = arr[arr.Length - 1];
                    arr[arr.Length - 1] = temp;

                    var restArray = new int[arr.Length - i - 1];
                    if (restArray.Length > 1)
                    {
                        for (int j = 0; j < restArray.Length; j++)
                        {
                            restArray[j] = arr[j + i + 1];
                        }

                        sortArray(restArray);

                        for (int j = 0; j < restArray.Length; j++)
                        {
                            arr[j + i + 1] = restArray[j];
                        }
                    }
                    break;
                }
            }
            for (int j = 0; j < arr.Length; j++)
            {
                Console.Write(arr[j] + " ");
            }
        }
        public static void sortArray(int[] arr) 
        {
           // int[] arr = new int[] {4,2,1,5,3 };
            int t = 0;
            for (int i = 0; i < arr.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < arr.GetLength(0) - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        t = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = t;
                    }
                }
            }

            Console.Write(arr);
        }

        // 1,2,3,4  --> output 2,3,4,1 ; 3,4,1,2 ; 4,1,2,3
        public void numberRoud()
        {
            var arr = new int[] { 1, 4, 3, 2 }; 
            sortArray(arr); 
            var sorted = new int[6, arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                sorted[0, i] = arr[i];
            }
            for (int i = 1; i < sorted.GetLength(0); i++)
            {
                int lowest = sorted[i - 1, 0];
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    int temp = arr[0];
                    sorted[i, j] = sorted[i - 1, j + 1];
                    if (j + 2 == arr.Length)
                    {
                        sorted[i, j + 1] = lowest;
                    }
                }
            }
        }

        #endregion  methods
    }
}
public interface IA
{
      void Hello();
}
public interface IB
{
      void Hello();
}
class Test : IA, IB
{
    void IB.Hello()
    {
        Console.WriteLine("B");
    }

    void IA.Hello()
    {
        Console.WriteLine("A");
    }
    //void IA.Hello()
    //{
    //    Console.WriteLine("Hello to all-A");
    //}
    //void IB.Hello()
    //{
    //    Console.WriteLine("Hello to all-B");
    //}

}

/*
 finding root of the number, check is connected ? and union of 2 numbers.
This method is better than QuickFindUF. Its complexity is linear for worst case
 */
class QuickUnionUF //https://www.coursera.org/learn/algorithms-part1/lecture/ZgecU/quick-union
{
    public QuickUnionUF(int[] input)
    {
        arr = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            arr[i] = input[i];
        }
    }
    static int[] arr;

    public int root(int i)
    {
        while(i != arr[i])
        {
            i = arr[i];
        }
        return i;
    }

    private bool isConnected(int i, int j)
    {
        return root(i) == root(j);
    }

    private void union(int i, int j)
    {
        int p = root(i);    
        int q = root(j);

        arr[p] = q;
    }
}
class QuickFindUF //https://www.coursera.org/learn/algorithms-part1/lecture/EcF3P/quick-find
{
    static int[] arr;

    public QuickFindUF(int[] input)
    {
        arr = new int[input.Length];
        for (int i=0; i < input.Length; i++)
        {
            arr[i] = input[i];
        }
    }
    public static bool connected(int p, int q)
    {
        int idp = arr[p];
        int idq = arr[q];
        return idp == idq;
    }
    public static void union(int p, int q)  // make 3 connected to 4
    {
        int idp = arr[p];   //0
        int idq = arr[q];   //3

        for(int i = 0; i < 9;i++)
        {
            if (arr[i] == idp)
            {
                arr[i] = idq; // for better efficiency we add extra line - arr[i] = arr[arr[i]] above it
            }
        }
    }
}
class Permutations<T>
{

    private List<T> permutation = new List<T>();
    HashSet<T> chosen;

    int n;
    List<T> sequence;

    public Permutations(IEnumerable<T> sequence)
    {
        this.sequence = sequence.ToList();
        this.n = this.sequence.Count;
        chosen = new HashSet<T>();
    }

    public void Generate()
    {
        if (permutation.Count == n)
        {
            Console.WriteLine(string.Join(",", permutation));
        }
        else
        {
            foreach (var elem in sequence)
            {
                if (chosen.Contains(elem)) continue;
                chosen.Add(elem);
                permutation.Add(elem);
                Generate();
                chosen.Remove(elem);
                permutation.Remove(elem);
            }
        }
    }
}
public class LinkedList
{
    Node top;

    public class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
        }
    }

    public void addToEnd(Node old, Node n)
    {
        if (old == null)
            old = n;
        else
        {
            Node temp = old;
            while (temp.next != null)
                temp = temp.next;
            temp.next = n;
        }
    }
}
class Organism
    {
        public Organism(string Name)
        {

        }
    }
class Animal : Organism
{
    public Animal(int Legs, string Kingdom, string Name) : base(Name)
    {

    }
}

class Cat : Animal
{
    public Cat(int Legs, string Kingdom, string Name) : base(Legs, Kingdom, Name)
    {

    }
}

class Student
{
    public int Age { get; set; }
    public string Name { get; set; }
}

class Employee { 
    public string Name { get; set; }
    public int Id { get; set; }
    public int Exp { get; set; }
    public int Projects { get; set; }
    public int Salary { get; set; }
    public int DepartmentId { get; set; }
}

static class TicketCounter
{
    static int ticketCount;

    static TicketCounter()
    {
        Console.WriteLine("TicketCounter contructor called");
    }

    public static int GiveTicket()
    {
        Console.WriteLine("Giving ticket number --> " + ticketCount);
        ticketCount++;
        return ticketCount;
    }
}

// virtual override new tests
class A
{
    public void Test() { Console.WriteLine("A::Test()"); }  // no virtual/new keyword
}
class B : A
{
    public virtual void Test() { Console.WriteLine("B::Test()"); }
}
class C : B
{
    public C()
    {

    }
    public override void Test() { Console.WriteLine("C::Test()"); }
}
class D : C
{
    public new void Test() { Console.WriteLine("D::Test()"); }
}
public class Singleton
{
    private static Singleton _singleton;
    private static readonly object lockableObject = new object();

    private Singleton()
    {
    }

    public static Singleton GetInstance()
    {
        if(_singleton == null)
        {
            lock (lockableObject)
            {
                if(_singleton == null)
                {
                    _singleton = new Singleton();
                }
            }
        }

        return _singleton;
    }
}

public class CustomList<T>()
{
    private static readonly  T[] arr = new T[0];
    
    public static T[]  getList = arr;

    public static void AddItem(T item)
    {
        arr[arr.Length] = item;
    }

    public static void RemoveItem<T>(T[] arr, T item)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (EqualityComparer<T>.Default.Equals(arr[i], item))  // Using EqualityComparer for robust comparison
            {
                arr[i] = default(T);
                break;  // If you want to stop after removing the first matching item
            }
        }
    }

   public static T FilterItem<T>(T[] arr, Func<T, bool> method)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (method(arr[i]))
            {
                return arr[i];
            }
        }
        return default(T);
    }
}
public class Node1      // // Graph by Bro code - https://youtu.be/CBYHwZcbD-s?t=10846s
{
    public char data;
    public Node1(char data)
    {
        this.data = data;
    }
}

// adjacency matrix Graph by Bro code - https://youtu.be/CBYHwZcbD-s?t=10846
public class Graph  //adjacency matrixr
{
    int[][] matrix;
    ArrayList nodes = new ArrayList();
    public Graph(int size)
    {
        matrix = new int[size][];
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = new int[size]; // Each row has 3 columns
        }
    }
    public void AddNode(Node1 node)
    {
        nodes.Add(node);
    }

    public void AddEdge(int x, int y) {
        matrix[x][y] = 1;
    }

    public bool CheckEdge(int x, int y) {
        return matrix[x][y] == 1;
    }

    internal void Print()
    {
        Console.Write("  ");
        for (int i = 0;i < nodes.Count; i++)
        {
            if (nodes[i] is Node1 item)  // Safe typecasting using pattern matching
            {
                Node1 p = (Node1)nodes[i];
                Console.Write(p.data + " ");
            }
        }
        Console.WriteLine();

        for (int i = 0; i < matrix.Length; i++)
        {
            Node1 p = (Node1)nodes[i];
            Console.Write(p.data + " ");
            for (int j = 0; j < matrix[0].Length;j++)
            {
                Console.Write(matrix[i][j]);
                Console.Write(" ");
            }

            Console.WriteLine();
        }

        Console.WriteLine(CheckEdge(1,2));
    }

     // Bro code https://youtu.be/CBYHwZcbD-s?t=12153
     public void depthFirstSearch(int startingRow)
     {
        bool[] visited = new bool[matrix[0].Length];
        dfsHelper(visited, startingRow);
     }

    private void dfsHelper(bool[] visited, int startingRow)
    {
        if (visited[startingRow] == true) { return; }
        else
        {
            visited[startingRow] = true;
            Node1 node = nodes[startingRow] as Node1;

            Console.WriteLine(node.data + " visited");
            for(int i = 0; i < matrix.Length; i++)
            {
                if (matrix[startingRow][i] == 1)
                {
                    dfsHelper(visited, i);
                }
            }
            return;
        }
    }

    public void BreadthFirstSearch(int startingRow)
    {
        startingRow = 4;
        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[matrix.Length];

        queue.Enqueue(startingRow);
        visited[startingRow] = true;

        while (queue.Count > 0)
        {
            startingRow = queue.Dequeue();
            var node = nodes[startingRow] as Node1;
            Console.WriteLine(node.data + " visited");

            for (int i = 0;i < matrix.Length; i++)
            {
                if(matrix[startingRow][i] == 1 && !visited[i])
                {
                    queue.Enqueue(i);
                    visited[i] = true;
                }
            }
        }
    }
}

public class TestAnimal { 
    public virtual string Eat()
    {
        return "food";
    }
}

public class TestDog : TestAnimal
{
    public override string Eat()
    {
        return "flesh";
    }
}

public class Department
{
    public int Id { get; set; }
    public string DeptName { get; set; }
}

public class DiscountCalculator
{
    public double BaseCalculateDiscount(double price, string customerType)
    {
        double discount = 0;
        discount = price * 0.05;
        return price - discount;
    }

    public double VIPDiscountCalculator(double price)
    {
        double discount = 0;
        discount = price * 0.07;
        return price - discount;
    }

    public double NewDiscountCalculator(double price)
    {
        double discount = 0;
        discount = price * 0.01;
        return price - discount;
    }
}

// OCP principle, OPen closed
/*
 the base Invoice class have CalculateDiscount(customerType) method,
if we want to add new customerType then we would have to change the method

So we created class InvoiceOCP, its CalculateDiscount method takes customer 
but now customer has overriden the GetDiscount() method already.
 */
public class Invoice
{
    public double CalculateDiscount(string customerType)
    {
        if (customerType == "Regular")
            return 10;
        else if (customerType == "Premium")
            return 20;
        else
            return 0;
    }
}

public abstract class Customer
{
    public abstract double GetDiscount();
}

// Extension 1
public class RegularCustomer : Customer
{
    public override double GetDiscount() => 10;
}

// Extension 2
public class PremiumCustomer : Customer
{
    public override double GetDiscount() => 20;
}

public class InvoiceOCP
{
    public double CalculateDiscount(Customer customer)
    {
        return customer.GetDiscount(); // No change needed to add new customer types
    }
}

// check LSV