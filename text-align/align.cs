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

            string longText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            // Normal label
            var label = NewTextLabel(longText);
            view.Add(label);

            var field = NewTextField(longText);
            view.Add(field);

            var editor = NewTextEditor(longText);
            view.Add(editor);

            var top = NewButton("Top");
            view.Add(top);
            top.Clicked += (s, e) =>
            {
                label.VerticalAlignment = VerticalAlignment.Top;
                field.VerticalAlignment = VerticalAlignment.Top;
                editor.VerticalAlignment = VerticalAlignment.Top;

                label.HorizontalAlignment = HorizontalAlignment.Begin;
                field.HorizontalAlignment = HorizontalAlignment.Begin;
                editor.HorizontalAlignment = HorizontalAlignment.Begin;
            };

            var center = NewButton("Center");
            view.Add(center);
            center.Clicked += (s, e) =>
            {
                label.VerticalAlignment = VerticalAlignment.Center;
                field.VerticalAlignment = VerticalAlignment.Center;
                editor.VerticalAlignment = VerticalAlignment.Center;

                label.HorizontalAlignment = HorizontalAlignment.Center;
                field.HorizontalAlignment = HorizontalAlignment.Center;
                editor.HorizontalAlignment = HorizontalAlignment.Center;
            };

            var bottom = NewButton("Bottom");
            view.Add(bottom);
            bottom.Clicked += (s, e) =>
            {
                label.VerticalAlignment = VerticalAlignment.Bottom;
                field.VerticalAlignment = VerticalAlignment.Bottom;                
                editor.VerticalAlignment = VerticalAlignment.Bottom;

                label.HorizontalAlignment = HorizontalAlignment.End;
                field.HorizontalAlignment = HorizontalAlignment.End;
                editor.HorizontalAlignment = HorizontalAlignment.End;
            };
        }

        public Button NewButton(string text)
        {
            var button = new Button
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            return button;
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 150,
                MultiLine = true,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };
            return label;
        }

        public TextField NewTextField(string text)
        {
            var field = new TextField
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 150,
                MaxLength = 200,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
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
                HeightSpecification = 150,
                PointSize = 15.0f,
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
