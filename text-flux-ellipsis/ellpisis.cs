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
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            window.Add(view);


            View textbox = new View
            {
                BackgroundColor = Color.Red,
                Position2D = new Position2D(0, 0),
                //WidthResizePolicy = ResizePolicyType.FillToParent,
                //HeightResizePolicy = ResizePolicyType.FitToChildren,
                //HeightResizePolicy = ResizePolicyType.FitToChild,
                //Size2D = new Size2D(0, 0),
            };
            view.Add(textbox);
            //textbox.Hide();


            // Normal label
            TextLabel label = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                MultiLine = true,

                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                //HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                //Size2D = new Size2D(0, 0),
            };
            textbox.Add(label);

/*
            float lineCount = label.LineCount;
            int TextBoxHeight = (int)(label.NaturalSize.Height * lineCount);

            Tizen.Log.Error("NUI", "LineCount [" + lineCount + "] \n");
            Tizen.Log.Error("NUI", "TextBoxHeight [" + TextBoxHeight + "] \n");

            textbox.Size2D = new Size2D(480, (int)TextBoxHeight);
*/

            Button show = new Button
            {
                Text = "show",
                Position2D = new Position2D(0, 500),
            };
            view.Add(show);
            show.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "label size [" + label.Size2D.Width + ", " + label.Size2D.Height + "] \n");
                Tizen.Log.Error("NUI", "textbox size [" + textbox.Size2D.Width + ", " + textbox.Size2D.Height + "] \n");
                //Tizen.Log.Error("NUI", "scroll[" + label.NaturalSize2D.Width + ", " + label.NaturalSize2D.Height + "] \n");
                label.Show();
                textbox.Show();

                float height = label.GetHeightForWidth(480);
                Tizen.Log.Error("NUI", "label GetHeightForWidth[480, " + height + "] \n");

                float lineCount = label.LineCount;
                int TextBoxHeight = (int)(label.NaturalSize.Height * lineCount);

                Tizen.Log.Error("NUI", "LineCount [" + lineCount + "] \n");
                Tizen.Log.Error("NUI", "TextBoxHeight [" + TextBoxHeight + "] \n");

                textbox.Size2D = new Size2D(480, (int)TextBoxHeight);
            };

            Button hide = new Button
            {
                Text = "hide",
                Position2D = new Position2D(0, 600),
            };
            view.Add(hide);
            hide.Clicked += (s, e) =>
            {
                //Tizen.Log.Error("NUI", "scroll[" + label.NaturalSize2D.Width + ", " + label.NaturalSize2D.Height + "] \n");
                label.Hide();
                textbox.Hide();
                //textbox.Size2D = new Size2D(0, 100);
            };

            Button button = new Button
            {
                Text = "OverflowOption5",
                Position2D = new Position2D(0, 700),
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
