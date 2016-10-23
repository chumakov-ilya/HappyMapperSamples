using System;
using System.Collections.Generic;

namespace HighloadTest.Tools
{
    public static class MapPrinter
    {
        public static void PrintMaps(dynamic text, List<NamePair> namePairs)
        {

            text.PushIndent("\t");
            text.WriteLine("public static class MapContainer");
            text.WriteLine("{");

            CreateMaps(text, namePairs);

            text.WriteLine(Environment.NewLine);

            CreateMapCalls(text, namePairs);

            text.WriteLine("}");
            text.PopIndent();
        }

        private static void CreateMapCalls(dynamic text, List<NamePair> namePairs)
        {
            text.PushIndent("\t");
            text.WriteLine("public static void Map(Mapper mapper)");
            text.WriteLine("{");
            text.PushIndent("\t");

            foreach (NamePair pair in namePairs)
            {
                string srcVarName = pair.SrcName.ToLower();
                string destVarName = pair.DestName.ToLower();
                text.WriteLine($"var {srcVarName} = Sample.Init(new {pair.SrcName}());");
                text.WriteLine($"var {destVarName} = mapper.Map<{pair.DestName}>({srcVarName});");
                text.WriteLine($"Sample.Compare({srcVarName}, {destVarName});");
                text.WriteLine(Environment.NewLine);
            }

            text.PopIndent();
            text.WriteLine("}");
            text.PopIndent();
        }

        private static void CreateMaps(dynamic text, List<NamePair> namePairs)
        {
            text.PushIndent("\t");
            text.WriteLine("public static Mapper CreateMaps()");
            text.WriteLine("{");
            text.PushIndent("\t");

            text.WriteLine("var config = new HappyConfig(cfg => {");

            foreach (NamePair pair in namePairs)
            {
                text.PushIndent("\t");
                text.WriteLine($"cfg.CreateMap<{pair.SrcName}, {pair.DestName}>();");
                text.PopIndent();
            }

            text.WriteLine("});");
            text.WriteLine("return config.CompileMapper();");

            text.PopIndent();
            text.WriteLine("}");
            text.PopIndent();
        }
    }
}