using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace TextComponentsTest
{
    class Example : NUIApplication
    {
        public TextField field1;
        public TextField field2;
        public TextField field3;
        public TextField field4;

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

            field1 = newTextField("Text Field Cursor Test This is long long text content because I need very long text.. scrollable text components", 20.0f);
            field1.PrimaryCursorPosition = 1;
            view.Add(field1);

            field2 = newTextField("Text Field Cursor Test This is long long text content because I need very long text.. scrollable text components", 20.0f);
            field2.PrimaryCursorPosition = 1;
            view.Add(field2);

            field3 = newTextField("Text Field Cursor Test This is long long text content because I need very long text.. scrollable text components", 20.0f);
            field3.PrimaryCursorPosition = 1;
            view.Add(field3);            

            field4 = newTextField("Text Field Cursor Test This is long long text content because I need very long text.. scrollable text components", 20.0f);
            field4.PrimaryCursorPosition = 1;
            view.Add(field4);
        }

        public void setHandle(TextField field)
        {
            field.GrabHandleImage = "images/handle_down.png";

            PropertyMap imageLeftMap = new PropertyMap();
            imageLeftMap.Add("filename", new PropertyValue("images/handle_downleft.png"));
            field.SelectionHandleImageLeft = imageLeftMap;

            PropertyMap imageRightMap = new PropertyMap();
            imageRightMap.Add("filename", new PropertyValue("images/handle_downright.png"));
            field.SelectionHandleImageRight = imageRightMap;
        }

        public TextField newTextField(string text, float size)
        {
            TextField textField = new TextField
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,

                MaxLength = 500,
                PointSize = size,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,

                Focusable = true,
            };
            setHandle(textField);

            return textField;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
