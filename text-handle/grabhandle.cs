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
            window.Add(view);


            // Normal field
            TextField field = new TextField
            {
                Text = "Text Field",

                Size2D = new Size2D(480, 100),               

                MaxLength = 200,
                BackgroundColor = Color.White,
                VerticalAlignment = VerticalAlignment.Center,

                EnableGrabHandle = true,
                EnableGrabHandlePopup = true,
                EnableSelection = true,

                PointSize = 20.0f,
            };
            view.Add(field);


            // editor
            TextEditor editor = new TextEditor
            {
                Text = "Text Editor",

                Size2D = new Size2D(480, 100),

                PointSize = 20.0f,
                BackgroundColor = Color.White,

                EnableGrabHandle = true,
                EnableGrabHandlePopup = true,
                EnableSelection = true,
            };
            view.Add(editor);


            var button1 = new Button
            {
                Text = "EnableGrabHandle True",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };
            button1.Clicked += (s, e) =>
            {
                field.EnableGrabHandle = !field.EnableGrabHandle;
                editor.EnableGrabHandle = !editor.EnableGrabHandle;
                button1.Text = "EnableGrabHandle " + field.EnableGrabHandle;
            };
            view.Add(button1);


            var button2 = new Button
            {
                Text = "EnableGrabHandlePopup True",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };
            button2.Clicked += (s, e) =>
            {
                field.EnableGrabHandlePopup = !field.EnableGrabHandlePopup;
                editor.EnableGrabHandlePopup = !editor.EnableGrabHandlePopup;
                button2.Text = "EnableGrabHandlePopup " + field.EnableGrabHandlePopup;
            };
            view.Add(button2);


            var button3 = new Button
            {
                Text = "EnableSelection True",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };
            button3.Clicked += (s, e) =>
            {
                field.EnableSelection = !field.EnableSelection;
                editor.EnableSelection = !editor.EnableSelection;
                button3.Text = "EnableSelection " + field.EnableSelection;
            };
            view.Add(button3);


            var button4 = new Button
            {
                Text = "Get handle image",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };
            button4.Clicked += (s, e) =>
            {
                Tizen.Log.Fatal("NUI", "Field handle image : " + field.GrabHandleImage + "\n");

                string left, right;
                field.SelectionHandleImageLeft.Find(0, "filename").Get(out left);
                field.SelectionHandleImageLeft.Find(0, "filename").Get(out right);

                Tizen.Log.Fatal("NUI", "Field handle left : " + left + "\n");
                Tizen.Log.Fatal("NUI", "Field handle right : " + right + "\n");
            };
            view.Add(button4);

            /* Image set

            field.GrabHandleImage = "handle_down.png";

            PropertyMap imageLeftMap = new PropertyMap();
            imageLeftMap.Add("filename", new PropertyValue("handle_downleft.png"));
            field.SelectionHandleImageLeft = imageLeftMap;

            PropertyMap imageRightMap = new PropertyMap();
            imageRightMap.Add("filename", new PropertyValue("handle_downright.png"));
            field.SelectionHandleImageRight = imageRightMap;
            */
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
