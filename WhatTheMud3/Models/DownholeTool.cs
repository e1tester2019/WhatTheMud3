using System.ComponentModel.DataAnnotations;

namespace WhatTheMud3.Models;

public partial class DownholeTool : ObservableObject
{
	public Guid id = Guid.NewGuid();
	[ObservableProperty]
	[Display(Name = "Tool Name")]
	private string name;
	[ObservableProperty]
	[Display(Name = "Activation Type")]
	private string activationType;
	[ObservableProperty]
	[Display(Name = "Activation Pressure")]
	private string activationPressure;
	[ObservableProperty]
	[Display(Name = "Measured Depth")]
	private string measuredDepth;
	[ObservableProperty]
	private double dsHP_d;
	[ObservableProperty]
	private double annHP_d;
	[ObservableProperty]
	private double diff_d;

	public double ActivationPressure_D
	{
		get => convertToDouble(ActivationPressure);
	}

	public double MeasuredDepth_D
	{
		get => convertToDouble(MeasuredDepth);
	}
	public double TVD_D;
	
	[ObservableProperty]
	private double volumeAboveDS_d;
	[ObservableProperty]
	private double volumeBelowDS_d;
	[ObservableProperty]
	private double volumeAboveAnn_d;
	[ObservableProperty]
	private double volumeBelowAnn_d;
	[ObservableProperty]
	private int toolIndexDS;
	[ObservableProperty]
	private int toolIndexAnn;
	[ObservableProperty]
	private double currentfunctionPressure;

	private double convertToDouble(string value)
	{
		double val;
		bool result = (double.TryParse(value, out val));
		return result ? val : 0.0;
	}
}