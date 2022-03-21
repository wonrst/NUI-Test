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

            string lineHeight1 = "<p rel-line-height=2.0>Lorem ipsum dolor sit amet, consectetur adipiscing elit,</p> sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            string lineHeight2 = "<p rel-line-height=0.5>Lorem ipsum dolor sit amet, consectetur adipiscing elit,</p> sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            // negative line spacing
            TextLabel label = new TextLabel
            {
                Text = lineHeight2,
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label);


            TextEditor editor = new TextEditor
            {
                Text = lineHeight2,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(editor);


            // positive line spacing
            TextLabel label2 = new TextLabel
            {
                Text = lineHeight1,
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label2);


            TextEditor editor2 = new TextEditor
            {
                Text = lineHeight1,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 150,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(editor2);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
