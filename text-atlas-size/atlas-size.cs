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
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.Black,
            };

            // Normal label
            TextLabel label = new TextLabel
            {
                Text = "A",
                Size2D = new Size2D(1200, 1200),

                PointSize = 100f,
                FontFamily = "Dejavu Sans",

                BackgroundColor = Color.White,
            };

            // Size label
            TextLabel sizeLabel = new TextLabel
            {
                Text = "Point Size : " + label.PointSize,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                PointSize = 25f,
                BackgroundColor = Color.White,
            };
            view.Add(sizeLabel);



            var minus_button = new Button
            {
                Text = "-",
                WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };
            minus_button.Clicked += (s, e) =>
            {
                label.PointSize -= 20;
                sizeLabel.Text = "Point Size : " + label.PointSize;
            };
            view.Add(minus_button);



            var plus_button = new Button
            {
                Text = "+",
                WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };
            plus_button.Clicked += (s, e) =>
            {
                label.PointSize += 20;
                sizeLabel.Text = "Point Size : " + label.PointSize;
            };
            view.Add(plus_button);



            view.Add(label);


            window.Add(view);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
