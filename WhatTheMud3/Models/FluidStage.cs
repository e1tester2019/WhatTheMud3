using System.ComponentModel.DataAnnotations;

namespace WhatTheMud3.Models;

public partial class FluidStage : ObservableObject
{
	public Guid id = Guid.NewGuid();
	[ObservableProperty]
	[Display(Name = "Stage Volume (m3)")]
	private string fluidVolume;
	[ObservableProperty]
	[Display(Name = "Fluid Type")]
	private string fluidType;
	[ObservableProperty]
	[Display(Name = "Density (kg/m3)")]
	private string density;

	public double volume_d
	{
		get => double.Parse(FluidVolume, System.Globalization.CultureInfo.InvariantCulture);
	}

	public double mudDensity_d
	{
		get => double.Parse(Density, System.Globalization.CultureInfo.InvariantCulture);
	}

	public string fluidType_s
	{
		get => FluidType;
	}

}