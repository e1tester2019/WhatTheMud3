using System.Globalization;

namespace WhatTheMud3.Models;

public partial class Segment : ObservableObject
{
	public Guid Id = Guid.NewGuid();
	[ObservableProperty] private string outerDiameter;
	[ObservableProperty] private string innerDiameter;
	[ObservableProperty] private string weightInAir;
	[ObservableProperty] private string topDepth;
	[ObservableProperty] private string bottomDepth;
	[ObservableProperty] private string fluidType;
	[ObservableProperty] private string mudDensity;

	public double OuterDiameter_D
	{
		get
		{
			double val;
			bool result = (double.TryParse(OuterDiameter, out val));
			return result ? val : 0.0;
		}
	}


}