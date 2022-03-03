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

            // Normal label + Wrap Content
            TextLabel label = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                MultiLine = true,
                Ellipsis = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label);

            var button = NewButton("get height");
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"label height[{label.Size.Height}] \n");
                Tizen.Log.Error("NUI", $"label natural height[{label.NaturalSize.Height}] \n");
            };


            // Normal label + height 99 + ellipsis
            TextLabel label1 = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                MultiLine = true,
                Ellipsis = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 99,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label1);

            var button1 = NewButton("get height");
            view.Add(button1);
            button1.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"label1 height[{label1.Size.Height}] \n");
                Tizen.Log.Error("NUI", $"label1 natural height[{label1.NaturalSize.Height}] \n");
            };


            // height 100(enough space) + negative linespacing
            TextLabel label2 = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                MultiLine = true,
                Ellipsis = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 100,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                LineSpacing = -20.0f,
            };
            view.Add(label2);

            var button2 = NewButton("get height");
            view.Add(button2);
            button2.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"label2 height[{label2.Size.Height}] \n");
                Tizen.Log.Error("NUI", $"label2 natural height[{label2.NaturalSize.Height}] \n");
            };


            // height 99(not enough space) + negative linespacing + ellipsis
            TextLabel label3 = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                MultiLine = true,
                Ellipsis = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 99,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                LineSpacing = -20.0f,
            };
            view.Add(label3);

            var button3 = NewButton("get height");
            view.Add(button3);
            button3.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"label3 height[{label3.Size.Height}] \n");
                Tizen.Log.Error("NUI", $"label3 natural height[{label3.NaturalSize.Height}] \n");
            };


        }

        public Button NewButton(string text)
        {
            var button = new Button
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 25,

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
