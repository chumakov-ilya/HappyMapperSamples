using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;

namespace HighloadTest
{
    public class Highload_SmokeTests
    {
        [SetUp]
        public void SetUp()
        {
            //manually run T4 template to generate new bunch of classes
        }

        [Test]
        public void Map()
        {
            var mapper = MapContainer.CreateMaps();

            MapContainer.Map(mapper);
            GC.Collect();
            Thread.Sleep(TimeSpan.FromSeconds(30));
            GC.Collect();
            Trace.WriteLine($"GC.GetTotalMemory(true): {GC.GetTotalMemory(true).FromBytesToMegabytes()} MB");
            Trace.WriteLine($"Process.GetCurrentProcess().WorkingSet64: {Process.GetCurrentProcess().WorkingSet64.FromBytesToMegabytes()} MB");

            //Approximate results per pair count (x64 process):

            //100
            //GC.GetTotalMemory(true): 11
            //Process.GetCurrentProcess().WorkingSet64: 74

            //200
            //GC.GetTotalMemory(true): 15
            //Process.GetCurrentProcess().WorkingSet64: 81

            //1000
            //GC.GetTotalMemory(true): 44
            //Process.GetCurrentProcess().WorkingSet64: 142
        }
    }

    public static class LongExtentions
    {
        public static long FromBytesToMegabytes(this long value)
        {
            return (long)(value/Math.Pow(2, 20));
        }
    }
}