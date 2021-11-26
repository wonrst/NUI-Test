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
                /*
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
                */
            };
            window.Add(view);


            View textbox = new View
            {
                BackgroundColor = Color.Red,
                Position2D = new Position2D(0, 0),
                Size2D = new Size2D(0, 100),
                //SizeHeight = 100,
            };
            view.Add(textbox);
            textbox.Hide();


            // Normal label
            TextLabel label = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line

                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            textbox.Add(label);
            label.Hide();

            //Tizen.Log.Error("NUI", "label[" + label.NaturalSize2D.Width + ", " + label.NaturalSize2D.Height + "] \n");

            Button show = new Button
            {
                Text = "show",
                Position2D = new Position2D(0, 100),
            };
            view.Add(show);
            show.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "label size [" + label.Size2D.Width + ", " + label.Size2D.Height + "] \n");
                Tizen.Log.Error("NUI", "textbox size [" + textbox.Size2D.Width + ", " + textbox.Size2D.Height + "] \n");
                //Tizen.Log.Error("NUI", "scroll[" + label.NaturalSize2D.Width + ", " + label.NaturalSize2D.Height + "] \n");
                label.Show();
                textbox.Show();
                textbox.Size2D = new Size2D(300, 100);
            };

            Button hide = new Button
            {
                Text = "hide",
                Position2D = new Position2D(0, 200),
            };
            view.Add(hide);
            hide.Clicked += (s, e) =>
            {
                //Tizen.Log.Error("NUI", "scroll[" + label.NaturalSize2D.Width + ", " + label.NaturalSize2D.Height + "] \n");
                label.Hide();
                textbox.Hide();
                textbox.Size2D = new Size2D(0, 100);
            };

            Button button = new Button
            {
                Text = "OverflowOption5",
                Position2D = new Position2D(0, 300),
            };
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "label size [" + label.Size2D.Width + ", " + label.Size2D.Height + "] \n");
                Tizen.Log.Error("NUI", "textbox size [" + textbox.Size2D.Width + ", " + textbox.Size2D.Height + "] \n");
                Tizen.Log.Error("NUI", "button [" + label.NaturalSize2D.Width + ", " + label.NaturalSize2D.Height + "] \n");

                if (textbox.Size2D.Width != 0 && label?.NaturalSize2D.Width > textbox.Size2D.Width)
                {
                    scrollText(label);
                }
                else
                {
                    stopText(label);
                }
            };

        }

        void scrollText(TextLabel label)
        {
            Tizen.Log.Error("NUI", "scrollText [" + label.NaturalSize2D.Width + ", " + label.NaturalSize2D.Height + "] \n");
            label.EnableAutoScroll = true;
            label.AutoScrollLoopCount = 0;
        }

        void stopText(TextLabel label)
        {
            Tizen.Log.Error("NUI", "stopText [" + label.NaturalSize2D.Width + ", " + label.NaturalSize2D.Height + "] \n");
            label.AutoScrollStopMode = AutoScrollStopMode.Immediate;
            label.EnableAutoScroll = false;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
