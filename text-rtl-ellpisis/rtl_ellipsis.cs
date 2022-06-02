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
                Text = "Projector سیٹنگیں",
                Ellipsis = true,
                WidthSpecification = 160,
                HeightSpecification = 60,
                PixelSize = 26.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                LayoutDirection = ViewLayoutDirectionType.RTL,
            };
            view.Add(label1);


            // Normal label
            TextLabel label2 = new TextLabel
            {
                Text = "Projector سیٹنگیں",
                Ellipsis = true,
                WidthSpecification = 150,
                HeightSpecification = 60,
                PixelSize = 26.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                LayoutDirection = ViewLayoutDirectionType.RTL,
            };
            view.Add(label2);


            Button buttonMinus = new Button()
            {
                Text = "Minus label",
                WidthSpecification = 300,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(buttonMinus);
            buttonMinus.Clicked += (s, e) =>
            {
                if (label1.WidthSpecification > 5)
                {
                    label1.WidthSpecification -= 5;
                    label2.WidthSpecification -= 5;
                }
                else
                {
                    label1.WidthSpecification = 0;
                    label2.WidthSpecification = 0;
                }
            };

            Button buttonPlus = new Button()
            {
                Text = "Plus label",
                WidthSpecification = 300,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(buttonPlus);
            buttonPlus.Clicked += (s, e) =>
            {
                if (label1.WidthSpecification < 500)
                {
                    label1.WidthSpecification += 5;
                    label2.WidthSpecification += 5;
                }
                else
                {
                    label1.WidthSpecification = 500;
                    label2.WidthSpecification = 500;
                }
            };

            var fontsizeMinus = new Button()
            {
                Text = "font size minus",
                WidthSpecification = 300,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(fontsizeMinus);
            fontsizeMinus.Clicked += (s, e) =>
            {
                label1.PixelSize -= 1.0f;
                Tizen.Log.Error("NUI", $"Label PixelSize[{label1.PixelSize}] \n");
            };

            var fontsizePlus = new Button()
            {
                Text = "font size plus",
                WidthSpecification = 300,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(fontsizePlus);
            fontsizePlus.Clicked += (s, e) =>
            {
                label1.PixelSize += 1.0f;
                Tizen.Log.Error("NUI", $"Label PixelSize[{label1.PixelSize}] \n");
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
