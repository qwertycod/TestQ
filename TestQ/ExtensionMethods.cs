using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQ
{
    public static class ExtensionMethods
    {
        const int myint = 5;
        static int mysint = 6;
        public static string RemoveLastComma(this string s){

            var y = s.Substring(s.Length -2);
            mysint = 7;

            return y;
        }
    }
}
