using System;
using CsvHelper.Configuration;

namespace WhatTheMud.ClassMaps
{
    public class DownholeToolSegmentMap : ClassMap<DownholeTool>
    {
        public DownholeToolSegmentMap()
        {
            Map(p => p.Name).Index(0);
            Map(p => p.ActivationType).Index(1);
            Map(p => p.ActivationPressure).Index(2);
            Map(p => p.MeasuredDepth).Index(3);
        }
    }
}

