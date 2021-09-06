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
            TextLabel label = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit,",
                MultiLine = true,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                Size2D = new Size2D(480, 40),
            };
            view.Add(label);
            AdjustTextLabelHeight(label);


            TextLabel label2 = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet",
                MultiLine = true,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                Size2D = new Size2D(480, 40),
            };
            view.Add(label2);
            AdjustTextLabelHeight(label2);


            TextLabel label3 = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor",
                MultiLine = true,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                Size2D = new Size2D(480, 40),
            };
            view.Add(label3);
            AdjustTextLabelHeight(label3);


            TextLabel label4 = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                MultiLine = true,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                Size2D = new Size2D(480, 40),
            };
            view.Add(label4);
            AdjustTextLabelHeight(label4);


            var button = new Button
            {
                //Text = "GetHeightForWidth 240",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                label.Text = "Lorem ipsum";
                AdjustTextLabelHeight(label);
                label2.Text = "Lorem ipsum";
                AdjustTextLabelHeight(label2);
                label3.Text = "Lorem ipsum";
                AdjustTextLabelHeight(label3);
                label4.Text = "Lorem ipsum";
                AdjustTextLabelHeight(label4);
            };

            var button2 = new Button
            {
                //Text = "GetHeightForWidth 480",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(button2);
            button2.Clicked += (s, e) =>
            {
                label.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
                AdjustTextLabelHeight(label);
                label2.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
                AdjustTextLabelHeight(label2);
                label3.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
                AdjustTextLabelHeight(label3);
                label4.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
                AdjustTextLabelHeight(label4);
            };
        }

        public void AdjustTextLabelHeight(TextLabel label)
        {
            int lineCount = label.LineCount;
            if (lineCount == 1)
            {
                label.VerticalAlignment = VerticalAlignment.Center;
                label.HorizontalAlignment = HorizontalAlignment.Center;
            }
            else
            {
                label.VerticalAlignment = VerticalAlignment.Center;
                label.HorizontalAlignment = HorizontalAlignment.Begin;
            }
            Tizen.Log.Error("NUI", "LineCount = " + lineCount + "\n");

            //if (label.GetHeightForWidth(480) > label.SizeHeight)
            {
                label.SizeHeight = label.GetHeightForWidth(480);
                Tizen.Log.Error("NUI", "GetHeightForWidth(480) = " + label.SizeHeight + "\n");
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
