using System;
using System.Collections.Generic;
using System.Linq;

namespace HighloadTest.Tools
{
    public class ClassPrinter
    {
        public static List<NamePair> PrintClasses(dynamic text, int pairCount)
        {
            var pairs = new List<NamePair>();
            var postfixes = CreatePostfixes(pairCount);

            for (int i = 0; i < pairCount; i++)
            {
                var pair = PrintClassPair(text, postfixes[i]);
                pairs.Add(pair);
            }

            return pairs;
        }

        private static string[] CreatePostfixes(int count)
        {
            var array = new string[count];

            for (int i = 1; i <= count; i++)
            {
                array[i - 1] = i.ToString();
            }

            return array;
        }

        public static NamePair PrintClassPair(dynamic text, string postfix)
        {
            string src = "Src_" + postfix;
            string dest = "Dest_" + postfix;

            PrintClass(text, src);
            PrintClass(text, dest);

            return new NamePair() { SrcName = src, DestName = dest };
        }

        public static void PrintClass(dynamic text, string className)
        {
            var type = typeof(Sample);

            text.PushIndent("\t");
            text.WriteLine("public class " + className);
            text.WriteLine("{");
            text.PushIndent("\t");

            foreach (var property in type.GetProperties())
            {
                Type propertyType = property.PropertyType;

                text.WriteLine(GetPropertyCode(propertyType.Name, property.Name));
            }

            text.PopIndent();
            text.WriteLine("}" + Environment.NewLine);
            text.PopIndent();
        }

        public static string GetPropertyCode(string typeName, string propertyName)
        {
            return "public " + typeName + " " + propertyName + " { get; set; }";
        }
    }
}