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
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                {
                    var types = assembly.GetTypes();
                    foreach (var type in types)
                    {
                        var members = type.GetMembers();
                        foreach (var member in members)
                        {
                            var attributes = member.GetCustomAttributes(typeof(DocumentAttribute), false);
                            if (attributes.Length > 0)

                            {

                                Console.WriteLine("Type: {0}", member.MemberType);
                                Console.WriteLine("Name: {0}", member.Name);
                                Console.WriteLine($"Description: {((DocumentAttribute)attributes[0]).Description}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
