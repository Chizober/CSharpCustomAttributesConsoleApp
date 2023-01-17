using System;
using System.Reflection;
using CodeDocumentationTool;

namespace DocumentTestTool
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ShowCodeDocuments.GetDocs(typeof(Enum));

            Console.WriteLine(sam.SampleMethod("stanley"));

            ShowCodeDocuments codedocs = new ShowCodeDocuments();

            Console.WriteLine(codedocs)
        }
    }
}