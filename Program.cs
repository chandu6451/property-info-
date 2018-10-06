using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PropertyInfoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly myAssembly = Assembly.LoadFrom("ReflectionLibrary.dll");

            Type t = myAssembly.GetType("ReflectionLibrary.Employee");

            PropertyInfo[] props = t.GetProperties();
            Console.WriteLine("Number of Properties : " + props.Length);

            foreach (PropertyInfo p in props)
            {
                Console.WriteLine("Property Name : " + p.Name);
                Console.WriteLine("Can Read : " + p.CanRead);
                Console.WriteLine("Can Write : " + p.CanWrite);
                Console.WriteLine("Property Type : " + p.PropertyType);
                Console.WriteLine();
            }

            object empObj = myAssembly.CreateInstance("ReflectionLibrary.Employee");
            PropertyInfo id = t.GetProperty("EmpID");
            id.SetValue(empObj, 101);
            Console.WriteLine(id.GetValue(empObj));

            Console.ReadKey();
        }
    }
}
