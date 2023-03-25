namespace WhatTheMud3.Models;

public class AppFluid
{
	public double FluidDensity;
	public string FluidType;
	public Color fluidColor
	{
		get {
			switch (FluidType)
			{
				case "Oil Based Mud":
					return Colors.Chocolate;
				case "Water Based Mud":
					return Colors.Bisque;
				case "Water":
					return Colors.LightBlue;
				case "Base Oil":
					return Colors.LightCyan;
				case "HiVis Sweep":
					return Colors.Orange;
				case "Weighted Sweep":
					return Colors.Red;
				case "Lead Cement":
					return Colors.LightGray;
				case "Tail Cement":
					return Colors.DarkGray;
				case "Displacement":
					return Colors.Aqua;
				default:
					return Colors.Beige;
			}
		}
	}

	public override string ToString()
	{
		return $"{FluidDensity} - {FluidType} - {fluidColor}";
	}
}