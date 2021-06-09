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


            // Normal label
            TextLabel label = new TextLabel
            {
                Text = "Text Label",
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 100,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label);
            label.TextColor = Color.Green; // works fine


            // Normal field
            TextField field = new TextField
            {
                Text = "Text Field",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                SizeHeight = 100,

                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.Yellow,
            };
            view.Add(field);


            //field.TextColor = Color.Blue; // works fine
            field.Text = "Update from code";
            //field.TextColor = Color.Blue; // doesn't work


            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");

                field.InputColor = Color.Red;
                //field.FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular")); // If this is enabled, it works fine
                label.Text = field.Text;
            };


            TextEditor editor = new TextEditor
            {
                Text = "Text Editor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                SizeHeight = 100,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(editor);


            // editor.TextColor = Color.Red; // doesn't work
            // editor.FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular")); // works fine


            editor.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor Text Changed[" + e.TextEditor.Text + "] \n");

                editor.InputColor = Color.Blue;
                //editor.FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular")); // If this is enabled, it works fine
                label.Text = editor.Text;
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
