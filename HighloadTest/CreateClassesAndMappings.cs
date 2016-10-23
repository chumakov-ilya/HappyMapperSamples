


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
		public static Mapper Create()
		{
			var config = new HappyConfig(cfg => {
				cfg.CreateMap<Src_1, Dest_1>();
				cfg.CreateMap<Src_2, Dest_2>();
				cfg.CreateMap<Src_3, Dest_3>();
			});
			return config.CompileMapper();
		}
	}
}

 