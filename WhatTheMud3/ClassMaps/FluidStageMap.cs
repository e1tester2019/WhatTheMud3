using System;
using CsvHelper.Configuration;

namespace WhatTheMud.ClassMaps
{
	public class FluidStageMap: ClassMap<FluidStage>
	{
		public FluidStageMap()
		{
			Map(p => p.FluidVolume).Index(0);
			Map(p => p.FluidType).Index(1);
            Map(p => p.Density).Index(2);
        }
	}
}

