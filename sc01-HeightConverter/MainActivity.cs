using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace sc01_HeightConverter
{
	[Activity(Label = "sc01_HeightConverter", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			Button button = FindViewById<Button>(Resource.Id.btnConvert);
			EditText amount2ConvertFeet = FindViewById<EditText>(Resource.Id.editHeightAmountFeet);
			EditText amount2ConvertInches = FindViewById<EditText>(Resource.Id.editHeightAmountInches);
			TextView result = FindViewById<TextView>(Resource.Id.textViewResult);
			button.Click += delegate
			{
				if (amount2ConvertFeet.Text.Length < 1 | amount2ConvertInches.Text.Length < 1)
				{
					if (amount2ConvertFeet.Text.Length < 1 & amount2ConvertInches.Text.Length < 1)
					{
						Toast.MakeText(this, "Please enter a Height in Feet and Inches above", ToastLength.Short).Show();
						result.Text = "";
						return;
					}
					else if (amount2ConvertFeet.Text.Length < 1)
						{
							amount2ConvertFeet.Text = "0";
						}
					else if (amount2ConvertInches.Text.Length < 1)
						{
							amount2ConvertInches.Text = "0";
						}
				}
				else if (Convert.ToDouble(amount2ConvertInches.Text) > 11)
				{
					Toast.MakeText(this, "Please enter an Inches amount below 12", ToastLength.Short).Show();
					result.Text = "";
					return;
				}
					var heightInches = Convert.ToDouble(amount2ConvertFeet.Text) * 12 + Convert.ToDouble(amount2ConvertInches.Text);
					var heightMeters = heightInches * 0.0254;
					result.Text = heightMeters + " Meters";
				

			};



		}
	}
}

