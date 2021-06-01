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
                    CellPadding = new Size2D(5, 5),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };

            // Test for https://review.tizen.org/gerrit/#/c/platform/core/uifw/dali-toolkit/+/253286/

            // Label for title
            TextLabel label = new TextLabel
            {
                Text = "TextEditor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.CadetBlue,
            };
            view.Add(label);
            


            // TextEditor
            TextEditor editor = new TextEditor
            {
                Text = "Lorem ipsum dolor sit amet, \nconsectetur adipiscing elit, \nsed do eiusmod \ntempor \nincididunt ut \nlabore et \ndolore magna \naliqua.",
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                Size2D = new Size2D(480, 250),
            };
            view.Add(editor);



            // Button -> editor.GetNaturalSize()
            Button button = new Button
            {
                Text = "Get Natural Size",
                Size2D = new Size2D(480, 30),
            };
            button.TextLabel.PointSize = 15;

            button.Clicked += (s, e) =>
            {
                var naturalSize = editor.GetNaturalSize();
                Tizen.Log.Fatal("NUI", "Editor Natural Size W : " + naturalSize.Width + " H : " + naturalSize.Height + "\n");
            };

            view.Add(button);


            // Label for title
            TextLabel label2 = new TextLabel
            {
                Text = "TextField",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.CadetBlue,
            };
            view.Add(label2);


            // TextField
            TextField field = new TextField
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(field);


            // Button -> field.GetNaturalSize()
            Button button2 = new Button
            {
                Text = "Get Natural Size",
                Size2D = new Size2D(480, 30),
            };
            button2.TextLabel.PointSize = 15;

            button2.Clicked += (s, e) =>
            {
                var naturalSize = field.GetNaturalSize();
                Tizen.Log.Fatal("NUI", "Field Natural Size W : " + naturalSize.Width + " H : " + naturalSize.Height + "\n");
            };

            view.Add(button2);



            // Label for title
            TextLabel label3 = new TextLabel
            {
                Text = "TextLabel",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.CadetBlue,
            };
            view.Add(label3);


            // TextLabel
            TextLabel multiLabel = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, \nconsectetur adipiscing elit, \nsed do eiusmod \ntempor \nincididunt ut \nlabore et \ndolore magna \naliqua.",
                //Text = "",
                MultiLine = true,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                Size2D = new Size2D(480, 250),
            };
            view.Add(multiLabel);
            //window.Add(multiLabel);


            // Button -> multiLabel.GetNaturalSize()
            Button button3 = new Button
            {
                Text = "Get Natural Size",
                Size2D = new Size2D(480, 30),
            };
            button3.TextLabel.PointSize = 15;

            button3.Clicked += (s, e) =>
            {
                Tizen.Log.Fatal("NUI", "Label Size W : " + multiLabel.Size.Width + " H : " + multiLabel.Size.Height + "\n");
                //multiLabel.Text = "Hello";
                var naturalSize = multiLabel.GetNaturalSize();
                Tizen.Log.Fatal("NUI", "Label Get Natural Size W : " + naturalSize.Width + " H : " + naturalSize.Height + "\n");
                Tizen.Log.Fatal("NUI", "Label Size W : " + multiLabel.Size.Width + " H : " + multiLabel.Size.Height + "\n");
                Tizen.Log.Fatal("NUI", "Label Natural Size W : " + multiLabel.NaturalSize.Width + " H : " + multiLabel.NaturalSize.Height + "\n");
            };

            view.Add(button3);




            window.Add(view);
        }


        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
