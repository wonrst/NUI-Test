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
                BackgroundColor = Color.Yellow,
            };


            // Note: https://github.sec.samsung.net/dotnet/NUIBackend/issues/47

            var button = new Button
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                //WidthResizePolicy = ResizePolicyType.FitToChildren,
                //HeightResizePolicy = ResizePolicyType.FitToChildren,
                BackgroundColor = Color.CadetBlue,
            };

            button.Text = "Loooooooooooooo\noooooooooooooong text";
            button.TextLabel.MultiLine = true;
            button.TextLabel.WidthSpecification = LayoutParamPolicies.MatchParent;

            view.Add(button);

            var twoLineBtn = new Button
            {
                Text = "First\r\nSecond"
            };
            twoLineBtn.TextLabel.MultiLine = true;
            twoLineBtn.TextLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
            view.Add(twoLineBtn);


            var twolineLabel = new TextLabel
            {
                Text = "First\r\nSecond",
                BackgroundColor = Color.Red,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            };
            twolineLabel.MultiLine = true;
            twoLineBtn.TextLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
            view.Add(twolineLabel);

            Tizen.Log.Error("NUI", "label default [" + twolineLabel.WidthResizePolicy + " " + twolineLabel.HeightResizePolicy + "] \n");



            // Multiline label in Layout
            var multilineLabel = new TextLabel
            {
                Text = "a loooooooooooooooong text, multi line",
            };
            multilineLabel.MultiLine = true;
            multilineLabel.Ellipsis = false;
            multilineLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
            //multilineLabel.WidthResizePolicy = ResizePolicyType.FillToParent;

            Tizen.Log.Error("NUI", "multiline Label label default [" + multilineLabel.WidthResizePolicy + " " + multilineLabel.HeightResizePolicy + "] \n");

            view.Add(multilineLabel);



            // Multiline button in Layout
            var multiLineButton = new Button
            {
                Text = "a loooooooooooooooong text, multi line",
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            multiLineButton.TextLabel.MultiLine = true;
            multiLineButton.TextLabel.Ellipsis = false;
            //multiLineButton.TextLabel.WidthResizePolicy = ResizePolicyType.FillToParent;

            multiLineButton.TextLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
            //multiLineButton.TextLabel.HeightSpecification = LayoutParamPolicies.WrapContent;


            view.Add(multiLineButton);

            Tizen.Log.Error("NUI", "multiLine Button label default [" + multiLineButton.TextLabel.WidthResizePolicy + " " + multiLineButton.TextLabel.HeightResizePolicy + "] \n");

            window.Add(view);



            // Multiline label *no Layout
            var multilineLabel2 = new TextLabel
            {
                Text = "a loooooooooooooooong text, multi line",
                Position2D = new Position2D(0, 500),
            };
            multilineLabel2.MultiLine = true;
            multilineLabel2.Ellipsis = false;
            multilineLabel2.WidthSpecification = LayoutParamPolicies.MatchParent;

            Tizen.Log.Error("NUI", "multiline Label2 label default [" + multilineLabel2.WidthResizePolicy + " " + multilineLabel2.HeightResizePolicy + "] \n");

            window.Add(multilineLabel2);


        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
