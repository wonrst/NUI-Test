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
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            string shortText = "Lorem ipsum dolor";
            string longText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            string veryLongText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            var label = NewTextLabel(longText);
            view.Add(label);
/*
            var label2 = NewTextLabel(veryLongText);
            view.Add(label2);
*/

            var button = NewButton("label size up");
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                label.HeightSpecification += 10;
            };

            var button2 = NewButton("label size down");
            view.Add(button2);
            button2.Clicked += (s, e) =>
            {
                label.HeightSpecification -= 10;
            };

            var button3 = NewButton("point size up");
            view.Add(button3);
            button3.Clicked += (s, e) =>
            {
                label.PointSize += 2;
            };

            var button4 = NewButton("point size down");
            view.Add(button4);
            button4.Clicked += (s, e) =>
            {
                label.PointSize -= 2;
            };

        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 250,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 24.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Top,
            };
            return label;
        }

        public Button NewButton(string text)
        {
            var button = new Button
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 30,
                PointSize = 15.0f,
            };
            return button;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
