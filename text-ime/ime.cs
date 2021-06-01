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

            // Normal field
            TextField field = new TextField
            {
                Text = "Text Field",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(field);

            InputMethod ime = new InputMethod();
            ime.PanelLayout = InputMethod.PanelLayoutType.Number;
            field.InputMethodSettings = ime.OutputMap;

            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };


            // Normal editor
            TextEditor editor = new TextEditor
            {
                Text = "Text Editor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(editor);

            InputMethod ime2 = new InputMethod();
            ime2.PanelLayout = InputMethod.PanelLayoutType.PhoneNumber;
            editor.InputMethodSettings = ime2.OutputMap;

            editor.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor Text Changed[" + e.TextEditor.Text + "] \n");
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
