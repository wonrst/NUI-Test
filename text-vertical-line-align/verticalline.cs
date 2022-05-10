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
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            string mixed = "<p rel-line-height=0.5>Lorem ipsum dolor sit amet, consectetur adipiscing elit,</p><p rel-line-height=2.0>sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>";
            string text = "<p rel-line-height=2.0>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>";

/*
            var top = NewTextLabel(text);
            top.VerticalLineAlignment = VerticalLineAlignment.Top;
            view.Add(top);

            var center = NewTextLabel(text);
            center.VerticalLineAlignment = VerticalLineAlignment.Center;
            view.Add(center);

            var bottom = NewTextLabel(text);
            bottom.VerticalLineAlignment = VerticalLineAlignment.Bottom;
            view.Add(bottom);
*/

            var top2 = NewTextLabel(mixed);
            top2.VerticalLineAlignment = VerticalLineAlignment.Top;
            view.Add(top2);

            var center2 = NewTextLabel(mixed);
            center2.VerticalLineAlignment = VerticalLineAlignment.Center;
            view.Add(center2);


            var bottom2 = NewTextLabel(mixed);
            bottom2.VerticalLineAlignment = VerticalLineAlignment.Bottom;
            view.Add(bottom2);
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                EnableMarkup = true,
                MultiLine = true,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            return label;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
