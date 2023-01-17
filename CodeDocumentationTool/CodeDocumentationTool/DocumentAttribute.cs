using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodeDocumentationTool
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class DocumentAttribute : Attribute
    {

        public DocumentAttribute()
        {
        }
        public DocumentAttribute(string description)
        {
            Description = description;
        }
        public DocumentAttribute(string description,
            string input = "", string output = "")
        {
            Description = description;
            Input = input;
            Output = output;
        }
        public string Description { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }


        [Document(Description = "Female software developers in Genesys")]
        class FemaleDevelopers
        {
            [Document(Description = "This assigns value to the Name field",
            Input = "This is a field which is the Name of female software developers and the data type is  string")]
            FemaleDevelopers(string name)
            {
                Name = name;
            }
            [Document(Description = "This is a property, it sets and gets  the names of the software developers")] public string Name { get; set; }
            [Document(Description = "This is also a property, it sets and gets  their departments")] public string Department { get; set; }
            [Document(Description = "This describes what happens in each department",Input ="It takes a string department",Output="It returns their department")]
            public string SampleCode(string department,string name)
            {
                return name + " is a member of " + Departments.OS;

            }

            [Document(Description ="This contains enumerable for the different departments")]
        public enum Departments
        {
            OS,
            Networking,
            Finance
        }

    }

    internal class Program
    {

        public static void GetMethods(Type type)
        {


            MethodInfo[] getmeth = type.GetMethods();
            for (int i = 0; i < getmeth.GetLength(0); i++)
            {
                object[] methinfo = getmeth[i].GetCustomAttributes(true);

                foreach (Attribute doc in methinfo.Cast<Attribute>())
                {
                    if (doc is DocumentAttribute)
                    {
                        DocumentAttribute attribute = (DocumentAttribute)doc;

                        Console.WriteLine(attribute.Description);
                    }
                }
            }
        }
        public static void GetClass(Type type)
        {
            Console.WriteLine("Assembly: {0}", Assembly.GetExecutingAssembly());
            object[] classinfo = type.GetCustomAttributes(true);
            foreach (object attr in classinfo)
            {
                if (attr is DocumentAttribute)
                {
                    DocumentAttribute attribute = (DocumentAttribute)attr;

                    Console.WriteLine($"{attribute.Description} {attribute.Input}");
                }
            }

        }
        public static void GetProps(Type type)
        {
            PropertyInfo[] propinfo = type.GetProperties();
            for (int i = 0; i < propinfo.Length; i++)
            {
                object[] prop = propinfo[i].GetCustomAttributes(true);

                foreach (Attribute myprop in prop.Cast<Attribute>())
                {
                    if (myprop is DocumentAttribute)
                    {
                        DocumentAttribute attribute = (DocumentAttribute)myprop;

                        Console.WriteLine(attribute.Description);
                    }
                }

            }

        }
        public static void GetDocs(Type type)
        {
            GetClass(type);
            GetMethods(type);
            GetProps(type);
        }



        static void Main(string[] args)
        {
            Program.GetDocs(typeof(SchoolEnum));

            SampleClass sam = new SampleClass();

            Console.WriteLine(sam.SampleMethod("stanley"));
        }
    }
}



