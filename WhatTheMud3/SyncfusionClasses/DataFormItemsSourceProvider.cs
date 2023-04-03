using System;
using Syncfusion.Maui.DataForm;
namespace WhatTheMud3.SyncFusionClasses
{
	public class DataFormItemsSourceProvider : IDataFormSourceProvider
	{
        public object GetSource(string sourceName)
        {
            if (sourceName == "FluidType")
            {
                List<string> list = new List<string>()
                {
                    "Oil Based Mud",
                    "Water Based Mud",
                    "Water",
                    "Base Oil",
                    "HiVis Sweep",
                    "Weighted Sweep",
                    "Spacer",
                    "Lead Cement",
                    "Tail Cement",
                    "Displacement",
                };

                return list;
            } else if (sourceName == "ActivationType")
            {
                List<string> list = new List<string>
                {
                    "Absolute",
                    "Differential"
                };

                return list;
            }

            return new List<string>();
        }
    }
}

