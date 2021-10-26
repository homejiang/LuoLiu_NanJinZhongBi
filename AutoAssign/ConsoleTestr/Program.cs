using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestr
{
    class Program
    {
        static void Main(string[] args)
        {
            Common.CommonDAL.DBConnString = @"Server=172.16.1.78\JPS2008;Database=LuoLiuAssigner;User=sa;Password=zxp;Connect Timeout=120;";
            Class1 cl = new Class1();
            decimal decC0, R0, V0;
            decimal decC1, R1, V1;
            decimal decC2, R2, V2;
            decimal decC3, R3, V3;
            decimal decC4, R4, V4;
            decimal decC5, R5, V5;
            decimal decC6, R6, V6;
            decimal decC7, R7, V7;
            decimal decC8, R8, V8;
            decimal decC9, R9, V9;
            cl.GetDxOrgInfo(1, "047CBWK023A0119C10083755", "047CBWK023A011A320112893", "047CBWK023A011A2S0015463", "047CBWK023A0119C10021640", "047CBWK023A011A340017744", "O47CBWK023A0119C30003956", "047CBWK023A0119C10181276", "047CBWK023A011A2S0013256", "", ""
                , out decC0
                 , out decC1
                 , out decC2
                 , out decC3
                 , out decC4
                 , out decC5
                 , out decC6
                 , out decC7
                 , out decC8
                 , out decC9
                 , out R0
                 , out R1
                 , out R2
                 , out R3
                 , out R4
                 , out R5
                 , out R6
                 , out R7
                 , out R8
                 , out R9
                 , out V0
                 , out V1
                 , out V2
                 , out V3
                 , out V4
                 , out V5
                 , out V6
                 , out V7
                 , out V8
                 , out V9
                );
            Console.WriteLine(decC0.ToString());
            Console.WriteLine(decC1.ToString());
            Console.WriteLine(decC2.ToString());
            Console.WriteLine(decC3.ToString());
            Console.WriteLine(decC4.ToString());
            Console.WriteLine(decC5.ToString());
            Console.WriteLine(decC6.ToString());
            Console.WriteLine(decC7.ToString());
            Console.WriteLine(decC8.ToString());
            Console.WriteLine(decC9.ToString());
            Console.WriteLine(R0.ToString());
            Console.WriteLine(R1.ToString());
            Console.WriteLine(R2.ToString());
            Console.WriteLine(R3.ToString());
            Console.WriteLine(R4.ToString());
            Console.WriteLine(R5.ToString());
            Console.WriteLine(R6.ToString());
            Console.WriteLine(R7.ToString());
            Console.WriteLine(R8.ToString());
            Console.WriteLine(R9.ToString());
            Console.WriteLine(V0.ToString());
            Console.WriteLine(V1.ToString());
            Console.WriteLine(V2.ToString());
            Console.WriteLine(V3.ToString());
            Console.WriteLine(V4.ToString());
            Console.WriteLine(V5.ToString());
            Console.WriteLine(V6.ToString());
            Console.WriteLine(V7.ToString());
            Console.WriteLine(V8.ToString());
            Console.WriteLine(V9.ToString());
            Console.ReadKey();
        }
    }
}
