using System.ComponentModel.DataAnnotations;

namespace WhatTheMud3.Models;

public partial class Survey : ObservableObject
{
	public Guid id = Guid.NewGuid();
	[ObservableProperty]
	[Display(Name = "Inclination (°)")]
	private string inc;
	[ObservableProperty]
	[Display(Name = "Azimuth (°)")]
	private string azi;
	[ObservableProperty]
	[Display(Name = "Measured Depth (m)")]
	private string md;
	[ObservableProperty]
	[Display(Name = "True Vertical Depth (m)")]
	private string tvd;

	public double md_d
	{
		get => double.Parse(Md, System.Globalization.CultureInfo.InvariantCulture);
	}
	public double tvd_d
	{
		get => double.Parse(Tvd, System.Globalization.CultureInfo.InvariantCulture);
	}
}