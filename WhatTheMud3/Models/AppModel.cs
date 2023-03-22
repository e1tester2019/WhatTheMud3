namespace WhatTheMud3.Models;

public partial class AppModel : ObservableObject
{
	#region AppParameters

	[ObservableProperty] private string wellName;

	#endregion
	
	#region Collection Parameters

	[ObservableProperty] private ObservableCollection<Segment> casings = new()
	{
		new Segment
		{
			Id = Guid.NewGuid(),
			OuterDiameter="177.8"
		}
	};

	#endregion
}