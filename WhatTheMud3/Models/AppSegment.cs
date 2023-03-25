namespace WhatTheMud3.Models;

public partial class AppSegment : ObservableObject
{
	[ObservableProperty] private double volume;
	[ObservableProperty] private double topDepth;
	[ObservableProperty] private double bottomDepth;
	[ObservableProperty] private double innerDiameter;
	[ObservableProperty] private double outerDiameter;
	[ObservableProperty] private int strokes;
	[ObservableProperty] private double mudDensity;
	[ObservableProperty] private string fluidType;

	public override string ToString()
	{
		return $"{TopDepth} - {BottomDepth} - {Volume}";
	}
}