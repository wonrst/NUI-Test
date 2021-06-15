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
                HeightSpecification = 300,
                BackgroundColor = Color.Black,
            };
            window.Add(view);


            // Normal label
            TextLabel label = new TextLabel
            {
                Text = "Text Label in Layout",
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
                Text = "Text Field in Layout",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                SizeHeight = 100,

                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.Yellow,
            };
            view.Add(field);
            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
                label.Text = field.Text;
            };


            TextEditor editor = new TextEditor
            {
                Text = "Text Editor in Layout",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                SizeHeight = 100,
                PointSize = 25.0f,
                BackgroundColor = Color.Blue,
            };
            view.Add(editor);
            editor.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor Text Changed[" + e.TextEditor.Text + "] \n");
                label.Text = editor.Text;
            };


            View view2 = new View()
            {
                Size2D = new Size2D(480, 400),
                Position2D = new Position2D(0, 350),
            };
            window.Add(view2);


            // Normal label
            TextLabel label2 = new TextLabel
            {
                Text = "Text Label in View",
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 100,
                Position2D = new Position2D(0, 0),
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view2.Add(label2);
            label2.TextColor = Color.Red; // works fine


            // Normal field
            TextField field2 = new TextField
            {
                Text = "Text Field in View",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                SizeHeight = 100,
                Position2D = new Position2D(0, 100),
                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.Yellow,
            };
            view2.Add(field2);
            field2.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
                label2.Text = field2.Text;
            };


            TextEditor editor2 = new TextEditor
            {
                Text = "Text Editor in View",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                SizeHeight = 100,
                PointSize = 25.0f,
                Position2D = new Position2D(0, 200),
                BackgroundColor = Color.White,
            };
            view2.Add(editor2);
            editor2.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor Text Changed[" + e.TextEditor.Text + "] \n");
                label2.Text = editor2.Text;
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
