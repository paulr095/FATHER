using System;
using UIKit;

namespace Bhasvic10th.iOS
{

	public class PickerViewModel : UIPickerViewModel {
			string[] categories = new string[] { "Economics, Business & Acc", "Archaeology, Classical Civs, History", "Art, Photog, Textiles, Graphics", "Biology & Env Studies", "Chemistry", "Computing IT", "Media & Film", "Dance, Drama, Theatre Studies", "English", "ESOL", "Languages", "Geography", "Law, Politics, Philosophy", "Maths", "Music", "Physics", "Sociology, Psych, H & Soc Care", "Sport and PE", "SU Events", "General", "UCAS, University", "Apprenticeship, Work", "Extra-Curricular", "Tutor & Welfare" };
	
			public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
			{
			return categories.Length;
			}

			public override string GetTitle(UIPickerView pickerView, nint row, nint component)
			{
				

			return categories[row];
				
			}

			public override nint GetComponentCount(UIPickerView pickerView)
			{

				return 1;
			}
		}
	}
	

