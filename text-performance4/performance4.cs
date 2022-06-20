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

            var view = new View()
            {
                Size2D = new Size2D(200, 200),
                BackgroundColor = Color.White,
            };
            window.Add(view);

            var scroll = new ScrollableBase()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.White,
            };
            view.Add(scroll);

            string temp = "";
            for (int i = 0 ; i < 5000 ; i ++)
            {
                temp += 'a';
            }

            var label = new TextLabel
            {
                Text = temp,
                PointSize = 32,
                MultiLine = true,
                Ellipsis = false,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.Fixed,
                BackgroundColor = Color.Gray,
            };
            scroll.Add(label);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
