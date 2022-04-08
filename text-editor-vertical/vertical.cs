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

            string shortText = "Lorem ipsum dolor";
            string longText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            // Normal editor
            TextEditor editor = NewTextEditor(longText);
            view.Add(editor);

            var top = NewButton("Top");
            view.Add(top);
            top.Clicked += (s, e) =>
            {
                editor.VerticalAlignment = VerticalAlignment.Top;
            };

            var center = NewButton("Center");
            view.Add(center);
            center.Clicked += (s, e) =>
            {
                editor.VerticalAlignment = VerticalAlignment.Center;
            };

            var bottom = NewButton("Bottom");
            view.Add(bottom);
            bottom.Clicked += (s, e) =>
            {
                editor.VerticalAlignment = VerticalAlignment.Bottom;
            };
        }

        public TextEditor NewTextEditor(string text)
        {
            var editor = new TextEditor
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 500,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            setHandle(editor);
            return editor;
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
