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
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            // Selection
            TextLabel selectionLabel = newTextLabel("Selection Length : ", 15.0f);
            view.Add(selectionLabel);

            // Cursor Position
            TextLabel cursorPosLabel = newTextLabel("Cursor Position : ", 15.0f);
            view.Add(cursorPosLabel);

            // Selected text label
            TextLabel selectedLabel = newTextLabel("Selected Text : ", 15.0f);
            view.Add(selectedLabel);


            // Normal field
            TextField field = new TextField
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            setHandle(field);
            view.Add(field);

            // field.TextChanged += onTextFieldTextChanged;
            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };

            field.CursorPositionChanged += (s, e) =>
            {
                cursorPosLabel.Text = "Cursor Position : " + field.PrimaryCursorPosition;
            };

            field.SelectionChanged += (s, e) =>
            {
                selectionLabel.Text = "Selection Length : " + field.SelectedText.Length;
                cursorPosLabel.Text = "Cursor Position : " + field.PrimaryCursorPosition;
                selectedLabel.Text = "Selected Text : " + field.SelectedText + " [" + field.SelectedTextStart + ", " + field.SelectedTextEnd + "]";
            };

            field.SelectionCleared += (s, e) =>
            {
                selectionLabel.Text = "Selection Length : " + field.SelectedText.Length;
                cursorPosLabel.Text = "Cursor Position : " + field.PrimaryCursorPosition;
                selectedLabel.Text = "Selected Text : " + field.SelectedText + " [" + field.SelectedTextStart + ", " + field.SelectedTextEnd + "]";

                Tizen.Log.Error("NUI", "Text selection cleared \n");
            };


            // Normal editor
            TextEditor editor = new TextEditor
            {
                Text = "Lorem ipsum dolor sit amet, \n\n\n\n\n\n\n\nconsectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 200,

                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            setHandle(editor);
            view.Add(editor);
            editor.SelectText(5, 10);

            editor.SelectionChanged += (s, e) =>
            {
                selectionLabel.Text = "Selection Length : " + editor.SelectedText.Length;
                cursorPosLabel.Text = "Cursor Position : " + editor.PrimaryCursorPosition;
                selectedLabel.Text = "Selected Text : " + editor.SelectedText + " [" + editor.SelectedTextStart + ", " + editor.SelectedTextEnd + "]";

                Tizen.Log.Error("NUI", "selection changed \n");
            };

            editor.SelectionCleared += (s, e) =>
            {
                selectionLabel.Text = "Selection Length : " + editor.SelectedText.Length;
                cursorPosLabel.Text = "Cursor Position : " + editor.PrimaryCursorPosition;
                selectedLabel.Text = "Selected Text : " + editor.SelectedText + " [" + editor.SelectedTextStart + ", " + editor.SelectedTextEnd + "]";

                Tizen.Log.Error("NUI", "Text selection cleared \n");
            };
        }

        public TextLabel newTextLabel(string text, float size)
        {
            TextLabel textLabel = new TextLabel
            {                
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = size,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            return textLabel;
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

        public void setHandle(TextEditor editor)
        {
            editor.GrabHandleImage = "images/handle_down.png";

            PropertyMap imageLeftMap = new PropertyMap();
            imageLeftMap.Add("filename", new PropertyValue("images/handle_downleft.png"));
            editor.SelectionHandleImageLeft = imageLeftMap;

            PropertyMap imageRightMap = new PropertyMap();
            imageRightMap.Add("filename", new PropertyValue("images/handle_downright.png"));
            editor.SelectionHandleImageRight = imageRightMap;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
