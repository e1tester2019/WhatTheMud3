using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatTheMud3.ViewModels.DrillStringBuilder;

namespace WhatTheMud3.Views.DrillStringBuilder;

public partial class DrillStringBuilderPage : ContentPage
{
	public DrillStringBuilderPage(DrillStringBuilderPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}