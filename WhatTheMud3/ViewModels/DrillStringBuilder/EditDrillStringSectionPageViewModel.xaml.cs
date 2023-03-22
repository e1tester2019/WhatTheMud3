using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatTheMud3.ViewModels.DrillStringBuilder;

public partial class EditDrillStringSectionPageViewModel : ContentPage
{
	public EditDrillStringSectionPageViewModel(EditDrillStringSectionPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}