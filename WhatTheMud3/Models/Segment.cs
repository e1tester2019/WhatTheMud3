using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WhatTheMud3.Models;

public partial class Segment : ObservableObject
{
	public Guid Id = Guid.NewGuid();
	[Display(Name = "Outer Diameter (mm)")]
	[ObservableProperty] private string outerDiameter;
	[Display(Name = "Inner Diameter (mm)")]
	[ObservableProperty] private string innerDiameter;
	[Display(Name = "Weight in Air (kg/m)")]
	[ObservableProperty] private string weightInAir;
	[Display(Name = "Top Depth (m)")]
	[ObservableProperty] private string topDepth;
	[Display(Name = "Bottom Depth (m)")]
	[ObservableProperty] private string bottomDepth;
	[Display(Name = "Fluid Type")]
	[ObservableProperty] private string fluidType;
	[Display(Name = "Mud Density (kg/m)")]
	[ObservableProperty] private string mudDensity;

	public double OuterDiameter_D
	{
		get => ConvertToDouble(OuterDiameter);
	}

	public double InnerDiameter_D
	{
		get => ConvertToDouble(InnerDiameter);
	}

	public double Weight_D
	{
		get => ConvertToDouble(WeightInAir);
	}

	public double TopDepth_D
	{
		get => ConvertToDouble(TopDepth);
	}

	public double BottomDepth_D
	{
		get => ConvertToDouble(BottomDepth);
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
		get => ConvertToDouble(MudDensity);
	}

	private double ConvertToDouble(string value)
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