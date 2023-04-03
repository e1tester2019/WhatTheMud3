using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Maui.DataForm;
using WhatTheMud3.ViewModels.DrillStringBuilder;
using WhatTheMud3.SyncFusionClasses;

namespace WhatTheMud3.Views.DrillStringBuilder;

public partial class EditDrillStringSegmentPage : ContentPage
{
	public EditDrillStringSegmentPage(EditDrillStringSegmentPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.segmentDataForm.ItemsSourceProvider = new DataFormItemsSourceProvider();
		this.segmentDataForm.RegisterEditor("FluidType", DataFormEditorType.ComboBox);
		this.segmentDataForm.GenerateDataFormItem += OnGenerateDataFormItem;
	}

	private void OnGenerateDataFormItem(object sender, GenerateDataFormItemEventArgs e)
	{
		if (e.DataFormItem != null && e.DataFormItem.FieldName.EndsWith("_D") &&
		    e.DataFormItem is DataFormTextEditorItem textEditor) { textEditor.IsVisible = false; };
		if (e.DataFormItem != null &&
		    (e.DataFormItem.FieldName == "OuterDiameter" ||
		     e.DataFormItem.FieldName == "InnerDiameter" ||
		     e.DataFormItem.FieldName == "TopDepth" ||
		     e.DataFormItem.FieldName == "BottomDepth" ||
		     e.DataFormItem.FieldName == "WeightInAir" ||
		     e.DataFormItem.FieldName == "MudDensity")
		    && e.DataFormItem is DataFormTextEditorItem textEditorItem)
		{
			textEditorItem.Keyboard = Keyboard.Numeric;
			// textEditorItem.LabelTextStyle = new DataFormTextStyle()
			// {
			// 	TextColor = Application.Current.RequestedTheme == AppTheme.Dark ? Colors.Black : Colors.Black
			//
			// };
			// textEditorItem.EditorTextStyle = new DataFormTextStyle()
			// {
			// 	TextColor = Application.Current.RequestedTheme == AppTheme.Dark ? Colors.Black : Colors.White
			//
			// };
		}
		// else if (e.DataFormItem != null && e.DataFormItem.FieldName == "FluidType" && e.DataFormItem is DataFormComboBoxItem comboBoxItem)
		// {
		// 	comboBoxItem.LabelTextStyle = new DataFormTextStyle()
		// 	{
		// 		TextColor = Application.Current.RequestedTheme == AppTheme.Dark ? Colors.White : Colors.Black,
		// 	};
		// }
		e.DataFormItem.Padding = new Thickness(0);
	}
}