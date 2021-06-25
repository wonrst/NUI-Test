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
        public bool textChanged = false;

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
                HeightSpecification = 170,
                BackgroundColor = Color.Black,
            };
            window.Add(view);


            // Normal label
            TextLabel label = new TextLabel
            {
                Text = "",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label);


            // Normal field
            TextField field = new TextField
            {
                Text = "<background color='yellow'><u>Lorem ipsum dolor sit amet,</u></background> consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,

                MaxLength = 200,
                PointSize = 25.0f,
            };
            view.Add(field);
            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
                label.Text = field.Text;
            };


            TextEditor editor = new TextEditor
            {
                Text = "<background color='yellow'><u>Lorem ipsum dolor sit amet,</u></background> consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                PointSize = 25.0f,
                BackgroundColor = Color.Gray,
            };
            view.Add(editor);
            editor.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor Text Changed[" + e.TextEditor.Text + "] \n");
                label.Text = editor.Text;
                editor.InputColor = Color.Red;
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
