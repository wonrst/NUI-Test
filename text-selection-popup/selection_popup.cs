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
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            FocusManager.Instance.EnableDefaultAlgorithm(true);

            string shortText = "Lorem ipsum dolor";
            string longText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";


            TextField field = NewTextField(shortText);
            view.Add(field);

            TextEditor editor = NewTextEditor(longText);
            view.Add(editor);

            TextField field2 = NewTextField(shortText);
            view.Add(field2);

        }

        public TextField NewTextField(string text)
        {
            var field = new TextField
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            setHandle(field);
            return field;
        }

        public TextEditor NewTextEditor(string text)
        {
            var editor = new TextEditor
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 400,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            setHandle(editor);
            return editor;
        }

        public void setHandle(TextField field)
        {
            field.GrabHandleImage = "images/handle_down.png";

            var selectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage();
            selectionHandleImage.LeftImageUrl = "images/handle_downleft.png";
            selectionHandleImage.RightImageUrl = "images/handle_downright.png";
            field.SetSelectionHandleImage(selectionHandleImage);
        }

        public void setHandle(TextEditor editor)
        {
            editor.GrabHandleImage = "images/handle_down.png";

            var selectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage();
            selectionHandleImage.LeftImageUrl = "images/handle_downleft.png";
            selectionHandleImage.RightImageUrl = "images/handle_downright.png";
            editor.SetSelectionHandleImage(selectionHandleImage);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
