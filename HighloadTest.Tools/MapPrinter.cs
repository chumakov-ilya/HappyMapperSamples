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
            text.PushIndent("\t");
            text.WriteLine("public static Mapper Create()");
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
            text.WriteLine("}");
            text.PopIndent();
        }
    }
}