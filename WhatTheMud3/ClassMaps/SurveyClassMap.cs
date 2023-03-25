using System;
using CsvHelper.Configuration;

namespace WhatTheMud.ClassMaps
{
    public class SurveyClassMap : ClassMap<Survey>
    {
        public SurveyClassMap()
        {
            Map(p => p.Md).Index(0);
            Map(p => p.Inc).Index(1);
            Map(p => p.Azi).Index(2);
            Map(p => p.Tvd).Index(3);
        }
    }
}