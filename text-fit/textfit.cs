using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace TextComponentsTest
{
    class Example : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            View view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            // Normal label
            TextLabel label = new TextLabel
            {
                //Text = "Lorem ipsum dolor",
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                MultiLine = true,
                Size2D = new Size2D(200, 50),
                //WidthSpecification = LayoutParamPolicies.MatchParent,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };

            // enable (bool) True to enable the text fit or false to disable (the default value is false)
            // minSize (float) Minimum Size for text fit (the default value is 10.f)
            // maxSize (float) Maximum Size for text fit (the default value is 100.f)
            // stepSize (float) Step Size for font increase (the default value is 1.f)
            // fontSize (string) The size type of font, You can choose between "pointSize" or "pixelSize". (the default value is "pointSize")

            PropertyMap fit = new PropertyMap();
            fit.Add("enable", new PropertyValue(true));
            fit.Add("minSize", new PropertyValue(1.0f));
            label.TextFit = fit;

            view.Add(label);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
