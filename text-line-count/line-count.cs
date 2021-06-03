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


            // LineCount label
            TextLabel label = new TextLabel
            {
                Text = "Lorem ipsum dolor",
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 100,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(label);


            Button shortBtn = new Button
            {
                Text = "Short Text",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(shortBtn);
            shortBtn.Clicked += (s, e) =>
            {
                label.Text = "Lorem ipsum dolor";
                setTextAlignment(label);
            };


            Button longBtn = new Button
            {
                Text = "Long Text",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(longBtn);
            longBtn.Clicked += (s, e) =>
            {
                label.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
                setTextAlignment(label);
            };
        }

        public void setTextAlignment(TextLabel label)
        {
            float h = label.GetHeightForWidth(label.Size2D.Width);
            Tizen.Log.Error("NUI", "label h " + h + " \n");

            int lineCount = label.LineCount;
            Tizen.Log.Error("NUI", "label LineCount " + lineCount + " \n");

            if (lineCount > 1)
            {
                label.HorizontalAlignment = HorizontalAlignment.Begin;
                Tizen.Log.Error("NUI", "label HorizontalAlignment.Begin \n");
            }
            else
            {
                label.HorizontalAlignment = HorizontalAlignment.Center;
                Tizen.Log.Error("NUI", "HorizontalAlignment.Center \n");
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
