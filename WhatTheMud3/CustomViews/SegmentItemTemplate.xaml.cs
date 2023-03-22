using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatTheMud3.CustomViews;

public partial class SegmentItemTemplate : DataTemplate
{
	// private static readonly BindableProperty StringSegmentProperty = BindableProperty.Create(
	// 	nameof(StringSegment),
	// 	typeof(Segment),
	// 	typeof(SegmentItemTemplate),
	// 	null);
	//
	// public Segment StringSegment
	// {
	// 	get => (Segment)GetValue(StringSegmentProperty);
	// 	set => SetValue(StringSegmentProperty, value);
	// }


	public SegmentItemTemplate()
	{
		InitializeComponent();
	}
}