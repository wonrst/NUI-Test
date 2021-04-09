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

            // Test for https://review.tizen.org/gerrit/#/c/platform/core/uifw/dali-toolkit/+/253286/

            // Label for title
            TextLabel label = new TextLabel
            {
                Text = "TextEditor",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                BackgroundColor = Color.CadetBlue,
            };
            view.Add(label);
            


            // TextEditor
            TextEditor editor = new TextEditor
            {
                Text = "Lorem ipsum dolor sit amet, \nconsectetur adipiscing elit, \nsed do eiusmod \ntempor \nincididunt ut \nlabore et \ndolore magna \naliqua.",
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                Size2D = new Size2D(480, 400),
            };
            view.Add(editor);



            // Button -> editor.GetNaturalSize()
            Button button = new Button
            {
                Text = "Get Natural Size",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };

            button.Clicked += (s, e) =>
            {
                var naturalSize = editor.GetNaturalSize();
                Tizen.Log.Fatal("NUI", "Editor Natural Size W : " + naturalSize.Width + " H : " + naturalSize.Height + "\n");
            };

            view.Add(button);


            // Label for title
            TextLabel label2 = new TextLabel
            {
                Text = "TextField",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                BackgroundColor = Color.CadetBlue,
            };
            view.Add(label2);


            // TextField
            TextField field = new TextField
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };
            view.Add(field);


            // Button -> field.GetNaturalSize()
            Button button2 = new Button
            {
                Text = "Get Natural Size",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };

            button2.Clicked += (s, e) =>
            {
                var naturalSize = field.GetNaturalSize();
                Tizen.Log.Fatal("NUI", "Field Natural Size W : " + naturalSize.Width + " H : " + naturalSize.Height + "\n");
            };

            view.Add(button2);



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
