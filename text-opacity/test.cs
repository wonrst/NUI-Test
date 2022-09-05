using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;

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

            Color backgroundColor = Color.Gray;
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et <color value='blue'>dolore magna aliqua. Lorem ipsum dolor sit amet,</color> <color value='red'>consectetur adipiscing</color> elit, <color value='green'>sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Lorem ipsum dolor sit amet,</color> consectetur adipiscing elit, sed do eiusmod <color value='yellow'>tempor incididunt ut labore</color> et dolore magna aliqua.";

            var editor = new TextEditor()
            {
                Text = text,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 350,
                PointSize = 25.0f,
                BackgroundColor = backgroundColor,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(editor);

            var mask = new View()
            {
                Size2D = new Size2D(800, 150),
                Position2D = new Position2D(0, 0),
                BackgroundColor = backgroundColor,
                Opacity = 0.75f,
            };
            window.Add(mask);

            var mask2 = new View()
            {
                Size2D = new Size2D(800, 150),
                Position2D = new Position2D(0, 200),
                BackgroundColor = backgroundColor,
                Opacity = 0.75f,
            };
            window.Add(mask2);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}