


using System;
using HighloadTest.Tools;
using HappyMapper;

namespace HighloadTest
{
	public class Src_1
	{
		public String MyProperty { get; set; }
	}

	public class Dest_1
	{
		public String MyProperty { get; set; }
	}

	public static class MapContainer
	{
		public static Mapper CreateMaps()
		{
			var config = new HappyConfig(cfg => {
				cfg.CreateMap<Src_1, Dest_1>();
			});
			return config.CompileMapper();
		}
	

		public static void Map(Mapper mapper)
		{
			var src_1 = Sample.Init(new Src_1());
			var dest_1 = mapper.Map<Dest_1>(src_1);
			

		}
	}
}

 