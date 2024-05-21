using Android.Content;
using Android.Content.PM;
using Com.Qualtrics.Digital;

namespace QualtricsAndroid7._0
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : Activity, IQualtricsCallback
    {
        public void Run(TargetingResult? p0)
        {
            if (p0.TargetingResultStatus == TargetingResultStatus.Passed)
            {
                Qualtrics.Instance().DisplayIntercept(this, p0.InterceptID);
            }
        }

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Qualtrics.Instance().InitializeProject("bcbsla", "ZN_7ZFKkESfPMPpYbA", this);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var btn = FindViewById<Button>(Resource.Id.clickMeBtn);
            btn.Click += (s, e) =>
            {
                Qualtrics.Instance().Properties.SetString("RoomCreated", "RoomCreated");
                Qualtrics.Instance().EvaluateIntercept("SI_d6vKmxusvrwzYWy", this);
            };
        }
    }
}