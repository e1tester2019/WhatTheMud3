using System.Globalization;

namespace WhatTheMud3.Models;

public partial class Segment : ObservableObject
{
	public Guid Id = Guid.NewGuid();
	[ObservableProperty] 
	private string outerDiameter;

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