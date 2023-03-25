using System;
using CsvHelper.Configuration;
namespace WhatTheMud.ClassMaps;

public class SegmentMap: ClassMap<Segment>
{
	public SegmentMap()
	{
		Map(p => p.OuterDiameter).Index(0);
		Map(p => p.InnerDiameter).Index(1);
		Map(p => p.WeightInAir).Index(2);
		Map(p => p.TopDepth).Index(3);
		Map(p => p.BottomDepth).Index(4);
		Map(p => p.MudDensity).Index(5);
		Map(p => p.FluidType).Index(6);
	}
}