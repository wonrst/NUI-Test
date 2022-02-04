using System;
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
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);


            TextField field = new TextField
            {
                Text = "Hello",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                MaxLength = 20,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            setHandle(field);
            view.Add(field);

            field.SelectionStarted += (s, e) =>
            {
                Tizen.Log.Error("NUI", "SelectionStarted text : " + field.SelectedText + "\n");
                Tizen.Log.Error("NUI", "SelectionStarted text start : " + field.SelectedTextStart + "\n");
                Tizen.Log.Error("NUI", "SelectionStarted text end : " + field.SelectedTextEnd + "\n");
            };

            field.SelectionChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "SelectionChanged text : " + field.SelectedText + "\n");
                Tizen.Log.Error("NUI", "SelectionChanged text start : " + field.SelectedTextStart + "\n");
                Tizen.Log.Error("NUI", "SelectionChanged text end : " + field.SelectedTextEnd + "\n");
            };

            field.SelectionCleared += (s, e) =>
            {
                Tizen.Log.Error("NUI", "SelectionCleared text : " + field.SelectedText + "\n");
                Tizen.Log.Error("NUI", "SelectionCleared text start : " + field.SelectedTextStart + "\n");
                Tizen.Log.Error("NUI", "SelectionCleared text end : " + field.SelectedTextEnd + "\n");
            };


            TextEditor editor = new TextEditor
            {
                Text = "Hello",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            setHandle(editor);
            view.Add(editor);

            editor.SelectionStarted += (s, e) =>
            {
                Tizen.Log.Error("NUI", "SelectionStarted text : " + editor.SelectedText + "\n");
                Tizen.Log.Error("NUI", "SelectionStarted text start : " + editor.SelectedTextStart + "\n");
                Tizen.Log.Error("NUI", "SelectionStarted text end : " + editor.SelectedTextEnd + "\n");
            };

            editor.SelectionChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "SelectionChanged text : " + editor.SelectedText + "\n");
                Tizen.Log.Error("NUI", "SelectionChanged text start : " + editor.SelectedTextStart + "\n");
                Tizen.Log.Error("NUI", "SelectionChanged text end : " + editor.SelectedTextEnd + "\n");
            };

            editor.SelectionCleared += (s, e) =>
            {
                Tizen.Log.Error("NUI", "SelectionCleared text : " + editor.SelectedText + "\n");
                Tizen.Log.Error("NUI", "SelectionCleared text start : " + editor.SelectedTextStart + "\n");
                Tizen.Log.Error("NUI", "SelectionCleared text end : " + editor.SelectedTextEnd + "\n");
            };
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

        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
