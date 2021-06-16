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
                Text = "Text Label in Layout",
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
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
                HeightSpecification = 50,

                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.Yellow,
            };
            field.TextColor = Color.Blue;
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
                HeightSpecification = 50,
                PointSize = 25.0f,
                BackgroundColor = Color.Blue,
            };
            editor.TextColor = Color.Blue;
            view.Add(editor);
            editor.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor Text Changed[" + e.TextEditor.Text + "] \n");
                label.Text = editor.Text;
            };


            // NO Layout - VIEW 
            View view2 = new View()
            {
                Size2D = new Size2D(480, 190),
                Position2D = new Position2D(0, 180),
                BackgroundColor = Color.Gray,
            };
            window.Add(view2);


            // Normal label
            TextLabel label2 = new TextLabel
            {
                Text = "Text Label in View",
                MultiLine = true,
                Size2D = new Size2D(480, 50),
                Position2D = new Position2D(0, 10),
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view2.Add(label2);
            label2.TextColor = Color.Red; // works fine


            // Normal field
            TextField field2 = new TextField
            {
                Text = "Text Field in View",
                Size2D = new Size2D(480, 50),
                Position2D = new Position2D(0, 70),
                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.Yellow,
            };
            field2.TextColor = Color.Blue;
            view2.Add(field2);
            field2.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
                label2.Text = field2.Text;
/*
                if (field2.Text.Length > 10)
                    field2.TextColor = Color.Purple;
                else
                    field2.TextColor = Color.Red;
*/
                 field2.InputColor = Color.Red; // dosen't work

                 textChanged = true;
            };


            TextEditor editor2 = new TextEditor
            {
                Text = "Text Editor in View",
                Size2D = new Size2D(480, 50),
                PointSize = 25.0f,
                Position2D = new Position2D(0, 130),
                BackgroundColor = Color.White,
            };
            editor2.TextColor = Color.Blue;
            view2.Add(editor2);
            editor2.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor Text Changed[" + e.TextEditor.Text + "] \n");
                label2.Text = editor2.Text;
/*
                if (editor2.Text.Length > 10)
                    editor2.TextColor = Color.Purple;
                else
                    editor2.TextColor = Color.Red;
*/
                 editor2.InputColor = Color.Red; // dosen't work
            };


            var button = new Button
            {
                Text = "Set Text",
                Size2D = new Size2D(480, 50),
                Position2D = new Position2D(0, 400),
            };
            button.Clicked += (s, e) =>
            {
                textChanged = false;

                Tizen.Log.Error("NUI", "before textChanged [" + textChanged + "] \n");
                
                field2.Text = "Set Text from button click";

                Tizen.Log.Error("NUI", "after textChanged [" + textChanged + "] \n"); // textChanged should be true
            };

            window.Add(button);


        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
