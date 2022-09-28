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

            string defaultString = "Hello";
            string markupString = "<color value='red'>Markup Red</color> Property Green <color value='blue'>Markup Blue</color>";


            var label = NewTextLabel(defaultString);
            label.Text = markupString;
            label.TextColor = Color.Green;
            view.Add(label);

            var label2 = NewTextLabel(defaultString);
            label2.TextColor = Color.Green;
            label2.Text = markupString;
            view.Add(label2);


            var field = NewTextField(defaultString);
            field.Text = markupString;
            field.TextColor = Color.Green;
            view.Add(field);

            var field2 = NewTextField(defaultString);
            field2.TextColor = Color.Green;
            field2.Text = markupString;
            view.Add(field2);


            var editor = NewTextEditor(defaultString);
            editor.Text = markupString;
            editor.TextColor = Color.Green;
            view.Add(editor);

            var editor2 = NewTextEditor(defaultString);
            editor2.TextColor = Color.Green;
            editor2.Text = markupString;
            view.Add(editor2); 


        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                EnableMarkup = true,
                PointSize = 15.0f,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
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
                EnableMarkup = true,
                PointSize = 15.0f,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return field;
        }

        public TextEditor NewTextEditor(string text)
        {
            var editor = new TextEditor
            {
                Text = text,
                EnableMarkup = true,
                PointSize = 15.0f,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return editor;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
