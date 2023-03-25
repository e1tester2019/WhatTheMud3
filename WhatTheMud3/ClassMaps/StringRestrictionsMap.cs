using System;
using CsvHelper.Configuration;

namespace WhatTheMud.ClassMaps
{
	public class StringRestrictionsMap: ClassMap<StringRestriction>
    {
		public StringRestrictionsMap()
		{
            Map(p => p.Name).Index(0);
            Map(p => p.InnerDiameter).Index(1);
            Map(p => p.Depth).Index(2);
            Map(p => p.DischargeCoefficient).Index(3);
        }
	}
}

