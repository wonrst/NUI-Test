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
                    //CellPadding = new Size2D(10, 10),
                },
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);


            // Normal field
            TextField field = new TextField
            {
                Text = "EnableGrabHandle = false",

                Size2D = new Size2D(400, 50),               

                MaxLength = 200,
                BackgroundColor = Color.White,

                EnableGrabHandle = false,
                //EnableSelection = false,
                EnableGrabHandlePopup = false,

                PointSize = 20.0f,
            };
            view.Add(field);


            // editor
            TextEditor editor = new TextEditor
            {
                Text = "(editor)EnableSelection = false",

                Size2D = new Size2D(410, 50),

                PointSize = 20.0f,
                BackgroundColor = Color.White,

                // Need to implements
                EnableGrabHandle = false,
                EnableGrabHandlePopup = false,
                //EnableSelection = false,
            };
            view.Add(editor);


            // Normal field
            TextField field2 = new TextField
            {
                Text = "EnableGrabHandle = false",
                
                Size2D = new Size2D(420, 50),               

                MaxLength = 200,
                BackgroundColor = Color.White,

                EnableGrabHandle = false,
                EnableSelection = false,

                PointSize = 20.0f,
            };
            view.Add(field2);


            // Normal field
            TextField field3 = new TextField
            {
                Text = "!handle !selection",
                
                Size2D = new Size2D(430, 50),
                
                MaxLength = 200,
                BackgroundColor = Color.White,

                EnableGrabHandle = false,
                EnableSelection = false,

                PointSize = 20.0f,
            };
            view.Add(field3);


            // Control field
            TextField field4 = new TextField
            {
                // Text = "!handle !selection",
                Size2D = new Size2D(440, 50),
               
                MaxLength = 200,
                BackgroundColor = Color.White,

                //EnableGrabHandle = false,
                //EnableSelection = false,

                PointSize = 20.0f,
            };
            view.Add(field4);

            field4.TextChanged += (s, e) =>
            {
                //Tizen.Log.Fatal("NUI", "field4 Text Changed : " + e.TextField.Text + "\n");

                //field3.EnableGrabHandle = false;
                //field3.EnableSelection = false;

                if (field4.Text.Length %2 == 0)
                {
                    field3.EnableGrabHandle = false;
                    field3.EnableSelection = false;
                }
                else
                {
                    field3.EnableGrabHandle = true;
                    field3.EnableSelection = true;
                }

                Tizen.Log.Fatal("NUI", "Field 3 handle : " + field3.EnableGrabHandle + ", sel : " + field3.EnableSelection + "\n");
            };

        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
