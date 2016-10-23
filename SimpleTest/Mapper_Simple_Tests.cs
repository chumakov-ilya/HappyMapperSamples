using System;
using HappyMapper;
using NUnit.Framework;

namespace SimpleTest
{
    public class Mapper_Simple_Tests
    {
        public class Src
        {
            public int Id { get; set; }

            public SrcChild Child { get; set; }
        }

        public class Dest
        {
            public int Id { get; set; }
            public DestChild Child { get; set; }
        }

        public class CustomDest
        {
            public int CustomId { get; set; }
        }

        public class SrcChild
        {
            public int P1 { get; set; }
        }

        public class DestChild
        {
            public int P1 { get; set; }
        }

        [Test]
        public void Mapper_MapSimpleTypes_Success()
        {
            var config = new HappyConfig(cfg =>
            {
                cfg.CreateMap<Src, Dest>();
            });
            var mapper = config.CompileMapper();

            var src = new Src { Id = 1 };

            var dest = mapper.Map<Dest>(src);

            Assert.AreEqual(src.Id, dest.Id);
        }

        [Test]
        public void Mapper_MapNestedTypes_Success()
        {
            var config = new HappyConfig(cfg =>
            {
                cfg.CreateMap<Src, Dest>();
            });
            var mapper = config.CompileMapper();

            var src = new Src { Id = 1, Child = new SrcChild { P1 = 2 } };

            var dest = mapper.Map<Dest>(src);

            Assert.AreEqual(src.Id, dest.Id);
            Assert.AreEqual(src.Child.P1, dest.Child.P1);
        }


        [Test]
        public void Mapper_CustomMap_Success()
        {
            var config = new HappyConfig(cfg =>
            {
                cfg.CreateMap<Src, CustomDest>().ForMember(d => d.CustomId, opt => opt.MapFrom(s => s.Id));
            });
            var mapper = config.CompileMapper();

            var src = new Src { Id = 1 };

            var dest = mapper.Map<CustomDest>(src);

            Assert.AreEqual(src.Id, dest.CustomId);
        }

    }
}
