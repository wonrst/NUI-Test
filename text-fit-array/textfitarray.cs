using System;
using System.Collections.Generic;
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


            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            var labelTextFit = NewTextLabel(text, 300, 150);
            view.Add(labelTextFit);

            PropertyMap fit = new PropertyMap();
            fit.Add("enable", new PropertyValue(true));
            fit.Add("minSize", new PropertyValue(1.0f));
            fit.Add("maxSize", new PropertyValue(500.0f));
            labelTextFit.TextFit = fit;


            var labelTextFitArray = NewTextLabel(text, 300, 150);
            view.Add(labelTextFitArray);

            var textFitArray = new Tizen.NUI.Text.TextFitArray();
            textFitArray.Enable = true;
            textFitArray.OptionList = new List<Tizen.NUI.Text.TextFitArrayOption>()
            {
                new Tizen.NUI.Text.TextFitArrayOption(10, 12),
                new Tizen.NUI.Text.TextFitArrayOption(16, 18),
            };
            labelTextFitArray.SetTextFitArray(textFitArray);


            var btnOn = NewButton("ON");
            view.Add(btnOn);
            btnOn.Clicked += (s, e) =>
            {
                var fitArray = new Tizen.NUI.Text.TextFitArray();
                fitArray.Enable = true;
                fitArray.OptionList = new List<Tizen.NUI.Text.TextFitArrayOption>()
                {
                    new Tizen.NUI.Text.TextFitArrayOption(10, 12),
                    new Tizen.NUI.Text.TextFitArrayOption(15, 17),
                    new Tizen.NUI.Text.TextFitArrayOption(20, 22),
                    new Tizen.NUI.Text.TextFitArrayOption(18, 20),
                };
                labelTextFitArray.SetTextFitArray(fitArray);
            };

            var btnOff = NewButton("OFF");
            view.Add(btnOff);
            btnOff.Clicked += (s, e) =>
            {
                var fitArray = new Tizen.NUI.Text.TextFitArray();
                fitArray.Enable = false;
                fitArray.OptionList = null;
                labelTextFitArray.SetTextFitArray(fitArray);
            };


            var btnInfo = NewButton("INFO");
            view.Add(btnInfo);
            btnInfo.Clicked += (s, e) =>
            {
                Tizen.NUI.Text.TextFitArray getFitArray = labelTextFitArray.GetTextFitArray();

                Tizen.Log.Error("NUI", "GetTextFitArray:\n");
                Tizen.Log.Error("NUI", "GetTextFitArray:enable:" + getFitArray.Enable + "\n");

                for (int i = 0 ; i < getFitArray.OptionList.Count ; i ++)
                {
                    Tizen.Log.Error("NUI", $"GetTextFitArray:option:[{getFitArray.OptionList[i].PointSize}, {getFitArray.OptionList[i].MinLineSize}] \n");
                }
            };
        }

        public Button NewButton(string text)
        {
            var button = new Button
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            return button;
        }

        public TextLabel NewTextLabel(string text, int width, int height)
        {
            var label = new TextLabel
            {
                EnableMarkup = true,
                Text = text,
                MultiLine = true,
                WidthSpecification = width,
                HeightSpecification = height,
                PointSize = 30,
                MinLineSize = 0,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
            };
            return label;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
