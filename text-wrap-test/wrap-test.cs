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


            // Label PointSize = Field's length of text
            TextLabel label = new TextLabel
            //TextEditor label = new TextEditor
            {
                Text = "Hyphens wrap to multiple lines, staying inside of their container. I think other browsers are treating each hyphen as a soft wrap opportunity, and this is special behavior for hyphens and not for other characters.",
                //Text = "Photography",
                //Text = "hyphenation",
                //Text = "Photography hyphenation Photography hyphenation Photography hyphenation Photography hyphenation Photography hyphenation Photography hyphenation Photography hyphenation Photography hyphenation Photography hyphenation Photography hyphenation Photography hyphenation Photography hyphenation ",
                MultiLine = true,

                LineWrapMode = LineWrapMode.Hyphenation,
                //LineWrapMode = LineWrapMode.Word,
                //LineWrapMode = LineWrapMode.Character,

                Size2D = new Size2D(480, 480),
                PointSize = 25.0f,
                //PointSize = 35.0f,
                BackgroundColor = Color.CadetBlue,
                HorizontalAlignment = HorizontalAlignment.Begin,
                //VerticalAlignment = VerticalAlignment.Center,   // only single line
                //Ellipsis = false,

                //FontFamily = "Ubuntu Mono",
            };
            view.Add(label);


            // Label for information
            TextLabel dataLabel = new TextLabel
            {
                Text = "PointSize : " + label.PointSize + " Wrap : " + label.LineWrapMode,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(dataLabel);


            // Normal field
            TextField field = new TextField
            {
                // EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                MaxLength = 200,
                PointSize = 15.0f,
                BackgroundColor = Color.White,

                PlaceholderText = "Input Length = Label PointSize",
                PlaceholderTextFocused = "Input Length = Label PointSize",

                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };

            field.TextChanged += (s, e) =>
            {
                label.PointSize = (float)field.Text.Length;
                dataLabel.Text = "PointSize : " + label.PointSize + " Wrap : " + label.LineWrapMode;
                Tizen.Log.Error("NUI", "label point size [" + label.PointSize + "] \n");
            };

            view.Add(field);


            // Button Char wrap
            Button charButton = new Button
            {
                Text = "LineWrapMode.Character",
                Size2D = new Size2D(480, 30),
            };
            charButton.TextLabel.PointSize = 15;

            charButton.Clicked += (s, e) =>
            {
                label.LineWrapMode = LineWrapMode.Character;
                dataLabel.Text = "PointSize : " + label.PointSize + " Wrap : " + label.LineWrapMode;
                Tizen.Log.Error("NUI", "label line wrap mode [" + label.LineWrapMode + "] \n");
            };
            view.Add(charButton);


            // Button Word wrap
            Button wordButton = new Button
            {
                Text = "LineWrapMode.Word",
                Size2D = new Size2D(480, 30),
            };
            wordButton.TextLabel.PointSize = 15;

            wordButton.Clicked += (s, e) =>
            {
                label.LineWrapMode = LineWrapMode.Word;
                dataLabel.Text = "PointSize : " + label.PointSize + " Wrap : " + label.LineWrapMode;
                Tizen.Log.Error("NUI", "label line wrap mode [" + label.LineWrapMode + "] \n");
            };
            view.Add(wordButton);


            // Button Hyphen wrap
            Button hyphenButton = new Button
            {
                Text = "LineWrapMode.Hyphenation",
                Size2D = new Size2D(480, 30),
            };
            hyphenButton.TextLabel.PointSize = 15;

            hyphenButton.Clicked += (s, e) =>
            {
                label.LineWrapMode = LineWrapMode.Hyphenation;
                dataLabel.Text = "PointSize : " + label.PointSize + " Wrap : " + label.LineWrapMode;
                Tizen.Log.Error("NUI", "label line wrap mode [" + label.LineWrapMode + "] \n");
            };
            view.Add(hyphenButton);


            // Button Mixed wrap
            Button mixedButton = new Button
            {
                Text = "LineWrapMode.Mixed",
                Size2D = new Size2D(480, 30),
            };
            mixedButton.TextLabel.PointSize = 15;

            mixedButton.Clicked += (s, e) =>
            {
                label.LineWrapMode = LineWrapMode.Mixed;
                dataLabel.Text = "PointSize : " + label.PointSize + " Wrap : " + label.LineWrapMode;
                Tizen.Log.Error("NUI", "label line wrap mode [" + label.LineWrapMode + "] \n");
            };
            view.Add(mixedButton);


            // Long Text
            Button longButton = new Button
            {
                Text = "Long Text",
                Size2D = new Size2D(480, 30),
            };
            longButton.TextLabel.PointSize = 15;

            longButton.Clicked += (s, e) =>
            {
                label.Text = "Hyphens wrap to multiple lines, staying inside of their container. I think other browsers are treating each hyphen as a soft wrap opportunity, and this is special behavior for hyphens and not for other characters.";

                Tizen.Log.Error("NUI", "Long Text \n");
            };
            view.Add(longButton);
                

            // Short Text
            Button shortButton = new Button
            {
                Text = "Short Text",
                Size2D = new Size2D(480, 30),
            };
            shortButton.TextLabel.PointSize = 15;

            shortButton.Clicked += (s, e) =>
            {
                label.Text = "Photography hyphenation";

                Tizen.Log.Error("NUI", "Short Text \n");
            };
            view.Add(shortButton);



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
