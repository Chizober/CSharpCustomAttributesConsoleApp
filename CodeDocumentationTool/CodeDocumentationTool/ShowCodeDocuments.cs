using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CodeDocumentationTool
{
    public class ShowCodeDocuments
    {


            public static void GetMethods(Type type)
            {


                MethodInfo[] fetchmethodInfo = type.GetMethods();
                for (int i = 0; i < fetchmethodInfo.GetLength(0); i++)
                {
                    object[] methinfo = fetchmethodInfo[i].GetCustomAttributes(true);

                    foreach (Attribute doc in fetchmethodInfo.Cast<Attribute>())
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
                object[] fetchclassInfo = type.GetCustomAttributes(true);
                foreach (object attr in fetchclassInfo)
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
                PropertyInfo[] fetchpropinfo = type.GetProperties();
                for (int i = 0; i < fetchpropinfo.Length; i++)
                {
                    object[] prop = fetchpropinfo[i].GetCustomAttributes(true);

                    foreach (Attribute props in prop.Cast<Attribute>())
                    {
                        if (props is DocumentAttribute)
                        {
                            DocumentAttribute attribute = (DocumentAttribute)props;

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



           
        }
    }

