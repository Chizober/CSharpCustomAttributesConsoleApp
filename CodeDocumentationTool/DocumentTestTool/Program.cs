using System;
using System.Reflection;
using CodeDocumentationTool;

namespace DocumentTestTool
{
    public class Program
    {

        static void Main(string[] args)
        {
            ShowCodeDocuments doc = new ShowCodeDocuments();
                doc.GetDocs();
          
        
        }
    }
}
