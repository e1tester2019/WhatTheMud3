using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatTheMud3.Views;

public partial class PumperPage : ContentPage
{
	public PumperPage(PumperPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}