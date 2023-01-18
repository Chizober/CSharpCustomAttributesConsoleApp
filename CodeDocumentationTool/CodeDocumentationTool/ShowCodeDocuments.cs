using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CodeDocumentationTool
{
    public class ShowCodeDocuments
    {

        public void GetDocs()
        {
            var assemblyData = Assembly.GetExecutingAssembly();

            Console.WriteLine(assemblyData);
            var typeData = assemblyData.GetTypes();



            foreach (Type type in typeData)
            {
                var attributeData = type.GetCustomAttributes(typeof(DocumentAttribute), true);

                if (attributeData.Length > 0)
                {
                    if (type.IsClass)
                    {
                        Console.WriteLine($"Class: {type.Name}");
                        Console.WriteLine($"\tDescription: {((DocumentAttribute)attributeData[0]).Description}\n");
       


                        foreach (ConstructorInfo constructor in type.GetConstructors())
                        {
                            var constructorAttributes = constructor.GetCustomAttributes(typeof(DocumentAttribute), true);
                            if (constructorAttributes.Length > 0)
                            {
                                Console.WriteLine($"Constructor: {constructor.Name}");
                                
                                Console.WriteLine($"\tDescription:{((DocumentAttribute)constructorAttributes[0]).Description}");
                                Console.WriteLine($"\tInput:{((DocumentAttribute)constructorAttributes[0]).Input}\n");
                            }
                        }

                        foreach (MethodInfo method in type.GetMethods())
                        {
                            var methodAttributes = method.GetCustomAttributes(typeof(DocumentAttribute), true);
                            if (methodAttributes.Length > 0)
                            {
                                Console.WriteLine($"Method:{method.Name}\n");
                                Console.WriteLine($"\tDescription: {((DocumentAttribute)methodAttributes[0]).Description}");
                                Console.WriteLine($"\tInput:{((DocumentAttribute)methodAttributes[0]).Input}");
                                Console.WriteLine($"\tOutput:{((DocumentAttribute)methodAttributes[0]).Output}\n");
                      
                            }
                        }

                        foreach (PropertyInfo property in type.GetProperties())
                        {
                            var propertyAttributes = property.GetCustomAttributes(typeof(DocumentAttribute), true);
                            if (propertyAttributes.Length > 0)
                            {
                                Console.WriteLine($"Property:{property.Name}");
                                Console.WriteLine($"\tDescription:{((DocumentAttribute)propertyAttributes[0]).Description}");
                                Console.WriteLine($"\tOutput:{((DocumentAttribute)propertyAttributes[0]).Output}\n");
                  
                            }
                        }

                    }

                    if (type.IsEnum)
                    {
                        Console.WriteLine($"Enum: {type.Name}");
                        Console.WriteLine($"\tDescription: {((DocumentAttribute)attributeData.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description}\n");

                        string[] names = type.GetEnumNames();
                        foreach (string name in names)
                        {
                            Console.WriteLine(name);

                        }
            
                    }

                }
            }
        }
    }
}
