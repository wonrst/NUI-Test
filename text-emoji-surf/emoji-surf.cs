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

            TextLabel label = new TextLabel
            {
                Text = "&#x1f3c4;&#x1f3fc;&#x200d;&#x2642;",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label);

            TextLabel label2 = new TextLabel
            {
                Text = "&#x1f3c4;&#x1f3fd;&#x200d;&#x2640;",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label2);

            TextLabel label3 = new TextLabel
            {
                Text = "&#x1f3c4;&#x1f3ff;&#x200d;&#x2640;",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label3);

            TextLabel label4 = new TextLabel
            {
                Text = "&#x1f3c4;&#x200d;&#x2640;",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label4);

            TextLabel label5 = new TextLabel
            {
                Text = "&#x1f3c4;&#x1f3fc;&#x200c;&#x2640;\n&#x1f3c4;&#x1f3fc;&#x200c;&#x2640;&#xfe0f;\n&#x1f3c4;&#x1f3fc;&#x200c;&#x2640;&#xfe0e;\n&#x1f3c4;&#x1f3fc;&#x200d;&#x2640;\n&#x1f3c4;&#x1f3fc;&#x200d;&#x2640;&#xfe0f;\n&#x1f3c4;&#x1f3fc;&#x200d;&#x2640;&#xfe0e;",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label5);
        }


        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
