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
        }
    }
}