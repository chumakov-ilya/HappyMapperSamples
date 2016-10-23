


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

	public class Src_2
	{
		public String MyProperty { get; set; }
	}

	public class Dest_2
	{
		public String MyProperty { get; set; }
	}

	public class Src_3
	{
		public String MyProperty { get; set; }
	}

	public class Dest_3
	{
		public String MyProperty { get; set; }
	}

	public static class MapContainer
	{
		public static Mapper CreateMaps()
		{
			var config = new HappyConfig(cfg => {
				cfg.CreateMap<Src_1, Dest_1>();
				cfg.CreateMap<Src_2, Dest_2>();
				cfg.CreateMap<Src_3, Dest_3>();
			});
			return config.CompileMapper();
		}
	

		public static void Map(Mapper mapper)
		{
			var src_1 = Sample.Init(new Src_1());
			var dest_1 = mapper.Map<Dest_1>(src_1);
			

			var src_2 = Sample.Init(new Src_2());
			var dest_2 = mapper.Map<Dest_2>(src_2);
			

			var src_3 = Sample.Init(new Src_3());
			var dest_3 = mapper.Map<Dest_3>(src_3);
			

		}
	}
}

 