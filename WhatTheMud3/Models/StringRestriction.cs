using System.ComponentModel.DataAnnotations;

namespace WhatTheMud3.Models;

public partial class StringRestriction : ObservableObject
{
	public Guid id = Guid.NewGuid();
	[ObservableProperty]
	[Display(Name = "Name")]
	private string name;
	[ObservableProperty]
	[Display(Name = "Inner Diameter (mm)")]
	private string innerDiameter;
	[ObservableProperty]
	[Display(Name = "Measured Depth (m)")]
	private string depth;
	[Display(Name = "Discharge Coefficient")]
	[ObservableProperty]
	private string dischargeCoefficient;
}