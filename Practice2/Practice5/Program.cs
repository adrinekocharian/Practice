using System;
using System.Collections.Generic;

namespace Practice5
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = RomanNumericalsDecode.Decode("IV");
            string a = "";
            string b = string.Empty;

            if(a == null)
                Console.WriteLine("is null");
            bool isnullOrempty = string.IsNullOrEmpty(a);
            bool isnullOrwhiteSpace = string.IsNullOrWhiteSpace(a);
            if (string.IsNullOrEmpty(a) || string.IsNullOrWhiteSpace(a))
            {

            }

            // HashSet
            
            HashSet<char> set = new HashSet<char>();
            var arr1 = new char[] { 'a', 'b', 'c', 'a' };
            var arr2 = new char[] { 'b', 'd', 'e', 'f' };

            set.Add('a');
            set.Add('a');
            set.Add('b');

            HashSet<char> set2 = new HashSet<char>(arr1);
            bool isremoved2 = set2.Remove('x');
            set2.UnionWith(arr2); // a, b, c, d, e, f

            foreach (char item in set)
            {
                Console.WriteLine(item);
            }

            // Dictionary  key-value pair

            // pdf - acrobat, Edge
            // txt - notepad.exe
            // docx - winword.exe

            Dictionary<string, string> types = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);         
            // types.Add("pdf", "acrobat");
            types.Add("txt", "notepad");
            types.Add("docx", "winword");

            Dictionary<string, string> types2 = new Dictionary<string, string>()
            {
                {"pdf", "acrobat" },
                {"txt", "notepad.exe" },
            };
            Dictionary<string, string> types3 = new Dictionary<string, string>()
            {
                ["pdf"] = "acrobat",
                ["txt"] ="notepad.exe",
            };

            if (!types.ContainsKey("pdf"))
            {
                types.Add("pdf", "something");
            }
            else
            {
                types["pdf"] = "something";
            }

            types["pdf"] = "acrobat";
            types["Pdf"] = "Acrobat";

            string ae = types["sdf"];
            types["pptx"] = "something";
            types["pptx"] = "somethinge";
            //types.Add("pptx", "powerpoint");

            if(types.ContainsValue("acrobat"))
            {

            }

            // string - List<string>
            // pdf - {"acrobat", "Edge"}
            Dictionary<string, List<string>> programs = new Dictionary<string, List<string>>();

            List<string> myList = new List<string>() { "acrobat", "edge" };
            programs.Add("txt", myList);

            programs.Add("pdf", new List<string> { "acrobat" }); // pdf - {acrobat}
            programs["pdf"].Add("Edge");                         // pdf - {acrobat, edge}
            programs["pdf"].Add("Google");                       // pdf - {acrobat, edge, google}
            programs["pdf"] = new List<string>() { "Edge2" };    // pdf - {edge2}
            //programs.Add("pdf", new List<string> { "acrobat" });


            foreach (string item in types.Keys)
            {
                Console.WriteLine(item);
            }

            foreach (string item in types.Values)
            {
                Console.WriteLine(item);
            }

            foreach (KeyValuePair<string, string> item in types)
            {
                Console.WriteLine(item);
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            bool isremoved = types.Remove("pdf");

            if (types.Remove("pdf", out string txtvalue))
            {
                Console.WriteLine(txtvalue);
            }

            //bool isRmv = types.Remove("txt", out string stringValue);
            
            //types.Clear();

            Console.WriteLine(types.Count);

            Console.ReadLine();
        }
    }
}
