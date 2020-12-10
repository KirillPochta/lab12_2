using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12Reflexion
{
    
    
    class Program
    {

        static void Main(string[] args)
        {
            Director student = new Director("Kirill", 10, 2);
            Reflector.ClassInformationInFile(student);
            Reflector.GetNameOfMethods("Lab12Reflexion.Director", "System.Int32");
            Reflector.CallMethod(student, "GetSum");
            var student1 = Reflector.Create(typeof(Director));
            Console.WriteLine(student1.ToString());

        }
    }
}
