

namespace WhatTheMud3;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(DrillStringBuilderPage), typeof(DrillStringBuilderPage));
		Routing.RegisterRoute(nameof(DownholeToolsPage), typeof(DownholeToolsPage));
		Routing.RegisterRoute(nameof(DrillStringSegmentsPage), typeof(DrillStringSegmentsPage));
		Routing.RegisterRoute(nameof(RestrictionsPage), typeof(RestrictionsPage));
		Routing.RegisterRoute(nameof(EditDrillStringSegmentPage), typeof(EditDrillStringSegmentPage));
	}
}