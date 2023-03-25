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
		get => convertToDouble(OuterDiameter);
	}

	public double InnerDiameter_D
	{
		get => convertToDouble(InnerDiameter);
	}

	public double Weight_D
	{
		get => convertToDouble(WeightInAir);
	}

	public double TopDepth_D
	{
		get => convertToDouble(TopDepth);
	}

	public double BottomDepth_D
	{
		get => convertToDouble(BottomDepth);
	}

	public double Capacity_D
	{
		get => Math.Pow(InnerDiameter_D, 2) * 0.0007854;
	}

	public double Volume_D
	{
		get => Capacity_D * (BottomDepth_D - TopDepth_D);
	}

	public double MudDensity_D
	{
		get => convertToDouble(MudDensity);
	}

	private double convertToDouble(string value)
	{
		double val;
		bool result = (double.TryParse(value, out val));
		return result ? val : 0.0;
	}

	public override string ToString()
	{
		return $"{OuterDiameter_D}mm x {InnerDiameter_D}mm {Weight_D}kg/m from {TopDepth_D}m to {BottomDepth_D}m \n" +
		       $"{MudDensity_D} kg/m3 : {FluidType}";
	}
}