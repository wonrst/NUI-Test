using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

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
            TextLabel label1 = new TextLabel
            {
                Text = "Line of Duty - فصل 3 قسط  6",
                Ellipsis = true,
                WidthSpecification = 300,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(label1);


            // Normal label
            TextLabel label2 = new TextLabel
            {
                Text = "فصل 3 قسط  6 - Line of Duty",
                Ellipsis = true,
                WidthSpecification = 300,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(label2);


            Button buttonMinus = new Button()
            {
                Text = "Minus",
                WidthSpecification = 300,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(buttonMinus);
            buttonMinus.Clicked += (s, e) =>
            {
                if (label1.WidthSpecification > 10)
                {
                    label1.WidthSpecification -= 10;
                    label2.WidthSpecification -= 10;
                }
            };

            Button buttonPlus = new Button()
            {
                Text = "Plus",
                WidthSpecification = 300,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(buttonPlus);
            buttonPlus.Clicked += (s, e) =>
            {
                if (label1.WidthSpecification < 500)
                {
                    label1.WidthSpecification += 10;
                    label2.WidthSpecification += 10;
                }
            };




        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
