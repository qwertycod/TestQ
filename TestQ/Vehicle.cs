using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQ
{
    public abstract class Vehicle
    {
        //   public int id { get; set; }

        public abstract string Run();   // abstract method, but not necessary to be present in abstract class

        public virtual string Name()
        {
            return "OK";
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        //public virtual void Print1(string message)
        //{
        //    Console.WriteLine(message);
        //}
    }

    public class Car : Vehicle
    {
        public string mode { get; set; }

        public override string Name()
        {
            throw new NotImplementedException();
        }

        public override string Run()
        {
            throw new NotImplementedException();
        }
    }

    public class Animal
    {
        public void Eat()
        {
            Console.WriteLine("eat");
        }
    }

    public class Dog: Animal
    {
        public void Eat()
        {
            Console.WriteLine("dog eat");
        }
    }

    public class Purchase
    {
        public int UserId { get; set; }
        public string Item { get; set; }
        public decimal Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

    //NOT Following LSP Liskov, TemporaryStudent will give error
    public class Student
    {
        public virtual string GetAccessLevel()
        {
            return "Basic Access";
        }
    }

    public class SeniorStudent : Student
    {
        public override string GetAccessLevel()
        {
            return "Senior Access";
        }
    }

    public class TemporaryStudent : Student
    {
        public override string GetAccessLevel()
        {
            throw new NotImplementedException("No access"); // //NOT Following LSP Liskov
        }
    }

    public class AccessService
    {
        public static string checkAccess(Student student)
        {
            var access = student.GetAccessLevel();  // Error 
            return access;
        }
    }

    public static class TestLSPError
    {
        public static void test()
        {
        //  AccessService accessService = new AccessService();
            Student student = new Student();  
            SeniorStudent seniorStudent = new SeniorStudent();
            TemporaryStudent tempStudent = new TemporaryStudent();

            var result = AccessService.checkAccess(student);
            var result1 = AccessService.checkAccess(seniorStudent);
            var result2 = AccessService.checkAccess(tempStudent);   // run time error
        }
    }

    // To implement LSV we create an Interface and pass the method GetAccessLevel() there and inhrit that Interface in the applicable classed
    public interface IAccessService {
        string GetAccessLevel();
    }

    // Following LSP

    public class StudentLSP : IAccessService
    {
        public void Study() { Console.WriteLine("Student study"); }
        public string GetAccessLevel()
        {
            return "Basic Access";
        }
    }

    public class SeniorStudentLSP : IAccessService
    {
        public void Study() { Console.WriteLine("Senior Student study"); }
        public string GetAccessLevel()
        {
            return "Senior Access";
        }
    }

    public class TempStudentLSP
    {
        public void Study() { Console.WriteLine("Temp Student study"); }
    }
    public class AccessServiceLSP
    {
        public string checkAccess(IAccessService student)
        {
            var access = student.GetAccessLevel();
            return access;
        }
    }

    public static class TestLSPSuccess
    {
        public static void Test()
        {
            AccessServiceLSP accessService = new AccessServiceLSP();
            StudentLSP student = new StudentLSP();
            SeniorStudentLSP seniorStudent = new SeniorStudentLSP();
            TemporaryStudent tempStudent = new TemporaryStudent();

            var result = accessService.checkAccess(student);
            var result1 = accessService.checkAccess(seniorStudent);
         //   var result2 = accessService.checkAccess(tempStudent);  cant be passed , compile time error
        }
    }

    // polymorphism
    public class A1
    {
        //void Add(String x, int16 i)     // compile time error, it will not work as the caller wont be able to decide which method will work
        //{
        //    Console.WriteLine("i");
        //}
        void Add(String x, Int32 i)
        {
            Console.WriteLine("i");
        }
    }

    class A
    {
        public void m1(String x)
        {
            Console.WriteLine("One");
        }
    }
    class B : A
    {
    }
    public class TestAB
    {
        public static void main(String[] args)
        {
            A a = new B();
            a.m1((new A()).ToString());     //One
        }
    }
         
}
