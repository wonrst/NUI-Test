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

            string shorMarkup = "<p align='center'>Hello world</p>";
            string markupText = "<p align='center'>Hello\nworld</p><p align='begin'>Second\nworld</p><p align='end'>Third\nworld</p>";

            TextLabel label = NewTextLabel(shorMarkup);
            view.Add(label);


            TextLabel multilineLabel = NewTextLabel(markupText);
            view.Add(multilineLabel);
            multilineLabel.MultiLine = true;


            // Markup Field
            TextField markupField = NewTextField(markupText);
            view.Add(markupField);
            markupField.EnableMarkup = true;

            // Markup Editor
            TextEditor markupEditor = NewTextEditor(markupText);
            view.Add(markupEditor);
            markupEditor.EnableMarkup = true;
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return label;
        }

        public TextField NewTextField(string text)
        {
            var field = new TextField
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                MaxLength = 200,
                PointSize = 15.0f,
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
                HeightSpecification = 100,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
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
