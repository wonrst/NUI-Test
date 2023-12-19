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
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);


            string defaultColor = "default color, blue->magenta : <a href='https://www.tizen.org/'>TIZEN</a>";
            string markupColor = "markup color, red->blue : <a color='red' clicked-color='blue' href='https://www.tizen.org/'>TIZEN</a>";
            string mixColor = "default + markup color, blue->magenta + red->blue : <a href='https://www.tizen.org/'>TIZEN</a> + <a color='red' clicked-color='blue' href='https://www.tizen.org/'>TIZEN</a>";
            string propertyColor = "property color, green->yellow : <a href='https://www.tizen.org/'>TIZEN</a>";

            string complexUrl = "https://www.google.com/search?q=%EB%A7%A4%EC%9A%B0+%EB%B3%B5%EC%9E%A1%ED%95%9C+url&sca_esv=592044316&rlz=1C1GCEU_koKR1039KR1039&ei=q_iAZeX8HYDm1e8Pyo2O4AQ&ved=0ahUKEwil_pqTs5qDAxUAc_UHHcqGA0wQ4dUDCBA&uact=5&oq=%EB%A7%A4%EC%9A%B0+%EB%B3%B5%EC%9E%A1%ED%95%9C+url&gs_lp=Egxnd3Mtd2l6LXNlcnAiFOunpOyasCDrs7XsnqHtlZwgdXJsMgoQABhHGNYEGLADMgoQABhHGNYEGLADMgoQABhHGNYEGLADMgoQABhHGNYEGLADMgoQABhHGNYEGLADMgoQABhHGNYEGLADMgoQABhHGNYEGLADMgoQABhHGNYEGLADMgoQABhHGNYEGLADMgoQABhHGNYEGLADSIYSUO0GWKQRcAV4AZABAZgB0AGgAfMGqgEFMS40LjG4AQPIAQD4AQHCAggQIRigARjDBOIDBBgAIEGIBgGQBgo&sclient=gws-wiz-serp";
            string complexText = "Hello, world! <a href='"+ complexUrl +"'>go hyperlink</a>";



            var defaultLabel = NewLabel(defaultColor);
            view.Add(defaultLabel);

            var markupLabel = NewLabel(markupColor);
            view.Add(markupLabel);

            var mixLabel = NewLabel(mixColor);
            view.Add(mixLabel);

            var propertyLabel = NewLabel(propertyColor);
            propertyLabel.AnchorColor = Color.Green;
            propertyLabel.AnchorClickedColor = Color.Yellow;
            view.Add(propertyLabel);

            var complexLabel = NewLabel(complexText);
            view.Add(complexLabel);


            int colorIndex = 0;
            Color[] colors = new Color[] {Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Pink, Color.Purple, Color.Black};
            string[] colorNames = new string[] {"Color.Red", "Color.Orange", "Color.Yellow", "Color.Green", "Color.Blue", "Color.Pink", "Color.Purple", "Color.Black"};

            var colorButton = NewButton("Change Anchor Color");
            view.Add(colorButton);
            colorButton.Clicked += (s, e) =>
            {
                defaultLabel.AnchorColor = colors[colorIndex];
                markupLabel.AnchorColor = colors[colorIndex];
                mixLabel.AnchorColor = colors[colorIndex];
                propertyLabel.AnchorColor = colors[colorIndex];
                complexLabel.AnchorColor = colors[colorIndex];

                colorButton.Text = "Color : " + colorNames[colorIndex];

                colorIndex = colorIndex + 1 < colors.Length ? colorIndex + 1 : 0;
            };

            var colorClickedButton = NewButton("Change Anchor Clicked Color");
            view.Add(colorClickedButton);
            colorClickedButton.Clicked += (s, e) =>
            {
                defaultLabel.AnchorClickedColor = colors[colorIndex];
                markupLabel.AnchorClickedColor = colors[colorIndex];
                mixLabel.AnchorClickedColor = colors[colorIndex];
                propertyLabel.AnchorClickedColor = colors[colorIndex];
                complexLabel.AnchorClickedColor = colors[colorIndex];

                colorClickedButton.Text = "Clicked Color : " + colorNames[colorIndex];

                colorIndex = colorIndex + 1 < colors.Length ? colorIndex + 1 : 0;
            };

            var ressetButton = NewButton("Reset Text");
            view.Add(ressetButton);
            ressetButton.Clicked += (s, e) =>
            {
                defaultLabel.Text = defaultColor;
                markupLabel.Text = markupColor;
                propertyLabel.Text = propertyColor;
                mixLabel.Text = mixColor;     
                complexLabel.Text = complexText;
            };


            complexLabel.FontSizeScale = 1.0f;

            var scalePlusButton = NewButton("Scale Plus");
            view.Add(scalePlusButton);
            scalePlusButton.Clicked += (s, e) =>
            {
                complexLabel.FontSizeScale += 0.1f;
            };

            var scaleMinusButton = NewButton("Scale Minus");
            view.Add(scaleMinusButton);
            scaleMinusButton.Clicked += (s, e) =>
            {
                complexLabel.FontSizeScale -= 0.1f;
            };
        }

        private void OnAnchorClicked(object sender, AnchorClickedEventArgs e)
        {
            Tizen.Log.Info("NUI", $"anchor text : {(sender as TextLabel).Text} \n");
            Tizen.Log.Info("NUI", $"anchor href : {e.Href} \n");
        }

        public TextLabel NewLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
            };
            label.AnchorClicked += OnAnchorClicked;
            return label;
        }

        public Button NewButton(string text)
        {
            var button = new Button()
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            return button;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
