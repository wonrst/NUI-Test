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


            // Normal label
            TextLabel label = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                // EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(label);

            var button = new Button
            {
                Text = "get geometry of label",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                PrintGeometry(label, "Main Label");
            };


            TextLabel label2 = new TextLabel
            {
                Text = "Very short text for geometry test",
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(label2);

            var button2 = new Button
            {
                Text = "get geometry of label2",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button2);
            button2.Clicked += (s, e) =>
            {
                PrintGeometry(label2, "Ref Label");
            };


            var button3 = new Button
            {
                Text = "Change text and get geometry",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button3);
            button3.Clicked += (s, e) =>
            {
                label.Text = "Very short text for geometry test";
                PrintGeometry(label, "Main Label");
            };

            var button4 = new Button
            {
                Text = "Restore",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button4);
            button4.Clicked += (s, e) =>
            {
                label.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
                PrintGeometry(label, "Main Label");
            };

        }

        public void PrintGeometry(TextLabel label, string title)
        {
            Tizen.Log.Error("NUI", "[ " + title + " ] ============================\n");
            Tizen.Log.Error("NUI", "label line[" + label.LineCount + "] size[" + label.Size.Width + ", " + label.Size.Height + "] \n");

            List<Size2D> sizeList = TextGeometry.GetTextSize(label, 0, label.Text.Length - 1);
            List<Position2D> positionList = TextGeometry.GetTextPosition(label, 0, label.Text.Length - 1);

            Tizen.Log.Error("NUI", "sizeList count[" + sizeList.Count + "] \n");
            for (int i = 0 ; i < sizeList.Count ; i ++)
            {
                Tizen.Log.Error("NUI", "item[" + i + "] width[" + sizeList[i].Width + "] height[" + sizeList[i].Height + "] \n");
            }

            Tizen.Log.Error("NUI", "positionList count[" + positionList.Count + "] \n");
            for (int i = 0 ; i < positionList.Count ; i ++)
            {
                Tizen.Log.Error("NUI", "item[" + i + "] X[" + positionList[i].X + "] Y[" + positionList[i].Y + "] \n");
            }
            Tizen.Log.Error("NUI", "\n");
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
