using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Lab12Reflexion
{
    static class Reflector
    {
        public static void ClassInformationInFile(object inputClass)
        {
            string path = @"C:\Objects";

            string rwPath = @"C:\Objects\file.txt";            
            var type = inputClass.GetType();
            var name = type.Name;
            var fields = type.GetFields();
            var assembly = type.Assembly;
            var constructors = type.GetConstructors();
            var properties = type.GetProperties();
            var interfaces = type.GetInterfaces();
            var method = type.GetMethods();

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            using (StreamWriter stream = new StreamWriter(rwPath, false))
            {
                stream.WriteLine($"Class name {name.ToString()}");
                stream.WriteLine($"Assembly name: {assembly.ToString()}");

                stream.WriteLine($"Public constuctions: {constructors.Length}");

                stream.WriteLine($"Public fields");
                foreach (var item in fields) stream.WriteLine(item.Name);

                stream.WriteLine($"Public properties");
                foreach (var item in properties) stream.WriteLine(item.Name);

                stream.WriteLine($"Public metods");
                foreach (var item in method) stream.WriteLine(item.Name);

                stream.WriteLine($"implement the interface");
                foreach (var item in interfaces) stream.WriteLine(item.Name);
            }

        }


        public static void GetNameOfMethods(string ClassName,string TypeOfParams)
        {
            var type = Type.GetType(ClassName);
            var param = Type.GetType(TypeOfParams);
            if (param != null && type != null)
            {
                var request = type.GetMethods().Where(i => i.GetParameters().Any(item => item.ParameterType == param));
                if (request.Count() > 0)
                {
                    Console.WriteLine($"All methods");
                    foreach (var item in request) Console.WriteLine(item);
                }
                else
                {
                    Console.WriteLine("There no any methods with this parametrs");
                }
            }

        }

        public static void CallMethod(object InputClass,string MethodName)
        {
            var Type = InputClass.GetType();
            var Method = Type.GetMethod(MethodName);
            var ParametrsInfo = Method.GetParameters();
            object[] paramFromFile = new object[1];

            string rwPath = @"C:\file.txt";

            StreamReader stream = new StreamReader(rwPath);
            
            paramFromFile[0] = Int32.Parse(stream.ReadLine());
            
            if (ParametrsInfo.Length == 1) Method.Invoke(InputClass, paramFromFile);
            Random rnd = new Random();

            object[] Randparam = new object[1];
            int value = rnd.Next(10, 20);
            Randparam[0] = value;

            Method.Invoke(InputClass, Randparam);
        }

        public static Object Create(Type clas)
        {
            return Activator.CreateInstance(clas);
        }

    }
}
