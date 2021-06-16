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
                Text = "Text Field Changed",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                MaxLength = 20,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };

            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
                field.Text = "Field";
            };

            view.Add(field);


            // Need to implement layout editor
            TextEditor editor = new TextEditor
            {
                Text = "Text Editor Changed",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };

            editor.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor Text Changed[" + e.TextEditor.Text + "] \n");
                editor.Text = "Editor";
            };

            view.Add(editor);


            // Normal field
            TextField field2 = new TextField
            {
                Text = "Color update",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                MaxLength = 20,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };

            field2.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
                int len = field2.Text.Length;
                if (len > 10)
                    field2.TextColor = Color.Red;
                else
                    field2.TextColor = Color.Blue;
            };

            view.Add(field2);


            // Need to implement layout editor
            TextEditor editor2 = new TextEditor
            {
                Text = "Color update",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 100,

                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };

            editor2.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor Text Changed[" + e.TextEditor.Text + "] \n");
                int len = editor2.Text.Length;
                if (len > 10)
                    editor2.TextColor = Color.Red;
                else
                    editor2.TextColor = Color.Blue;
            };

            view.Add(editor2);


            var button = new Button
            {
                Text = "Set Text",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            button.Clicked += (s, e) =>
            {
                field.Text = "Set Text from button click";
                // field.InputColor = Color.Red;
            };
            view.Add(button);

        }


        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
