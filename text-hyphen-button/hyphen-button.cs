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
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.Black,
            };


            Button mainButton = new Button
            {
                Text = "Hyphens wrap to multiple lines, staying inside of their container. I think other browsers are treating each hyphen as a soft wrap opportunity, and this is special behavior for hyphens and not for other characters.",
                Size2D = new Size2D(480, 480),
            };
            view.Add(mainButton);

            mainButton.TextLabel.LineWrapMode = LineWrapMode.Hyphenation;
            mainButton.TextLabel.MultiLine = true;
            //mainButton.TextLabel.Size2D = new Size2D(480, 480);

            mainButton.TextLabel.WidthResizePolicy = ResizePolicyType.FillToParent;
            //mainButton.TextLabel.HeightResizePolicy = ResizePolicyType.FillToParent;
            
            //mainButton.TextLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
            //mainButton.TextLabel.HeightSpecification = LayoutParamPolicies.WrapContent;


            // Label for information
            TextLabel dataLabel = new TextLabel
            {
                Text = "PointSize : " + mainButton.TextLabel.PointSize + " Wrap : " + mainButton.TextLabel.LineWrapMode,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
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
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,

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
                mainButton.TextLabel.PointSize = (float)field.Text.Length;
                dataLabel.Text = "PointSize : " + mainButton.TextLabel.PointSize + " Wrap : " + mainButton.TextLabel.LineWrapMode;
                Tizen.Log.Error("NUI", "label point size [" + mainButton.TextLabel.PointSize + "] \n");
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
                mainButton.TextLabel.LineWrapMode = LineWrapMode.Character;
                dataLabel.Text = "PointSize : " + mainButton.TextLabel.PointSize + " Wrap : " + mainButton.TextLabel.LineWrapMode;
                Tizen.Log.Error("NUI", "label line wrap mode [" + mainButton.TextLabel.LineWrapMode + "] \n");
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
                mainButton.TextLabel.LineWrapMode = LineWrapMode.Word;
                dataLabel.Text = "PointSize : " + mainButton.TextLabel.PointSize + " Wrap : " + mainButton.TextLabel.LineWrapMode;
                Tizen.Log.Error("NUI", "label line wrap mode [" + mainButton.TextLabel.LineWrapMode + "] \n");
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
                mainButton.TextLabel.LineWrapMode = LineWrapMode.Hyphenation;
                dataLabel.Text = "PointSize : " + mainButton.TextLabel.PointSize + " Wrap : " + mainButton.TextLabel.LineWrapMode;
                Tizen.Log.Error("NUI", "label line wrap mode [" + mainButton.TextLabel.LineWrapMode + "] \n");
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
                mainButton.TextLabel.LineWrapMode = LineWrapMode.Mixed;
                dataLabel.Text = "PointSize : " + mainButton.TextLabel.PointSize + " Wrap : " + mainButton.TextLabel.LineWrapMode;
                Tizen.Log.Error("NUI", "label line wrap mode [" + mainButton.TextLabel.LineWrapMode + "] \n");
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
                mainButton.TextLabel.Text = "Hyphens wrap to multiple lines, staying inside of their container. I think other browsers are treating each hyphen as a soft wrap opportunity, and this is special behavior for hyphens and not for other characters.";

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
                mainButton.TextLabel.Text = "Photography hyphenation";

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
