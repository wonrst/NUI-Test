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
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
                LayoutDirection = ViewLayoutDirectionType.RTL,

            };
            window.Add(view);

            //string longText = "Lorem ipsum dolor";

            //string longText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            //string longText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            string ltr_rtl = "Hello مرحبا بالعالم";
            string rtl_ltr = "مرحبا بمرحبا مرحبا مرحبا مرحبا مرحبا مرحبا مرحبا مرحبا العالم Hello...";
            string ltr = "مرحبا بالعالم.";
            string rtl = "Hello world...";

            TextLabel label = NewTextLabel(ltr_rtl);
            label.LayoutDirection = ViewLayoutDirectionType.LTR;
            view.Add(label);

            //TextLabel label2 = NewTextLabel(rtl_ltr);
            TextLabel label2 = NewTextLabel(rtl_ltr);
            view.Add(label2);

            TextLabel label3 = NewTextLabel(ltr);
            label3.LayoutDirection = ViewLayoutDirectionType.RTL;
            view.Add(label3);

            TextLabel label4 = NewTextLabel(rtl);
                        label4.LayoutDirection = ViewLayoutDirectionType.RTL;

            view.Add(label4);

            Button button = new Button
            {
                Text = "autoScroll info",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "EnableAutoScroll[" + label.EnableAutoScroll + "] \n");
                Tizen.Log.Error("NUI", "AutoScrollLoopCount[" + label.AutoScrollLoopCount + "] \n");
                Tizen.Log.Error("NUI", "AutoScrollGap[" + label.AutoScrollGap + "] \n");
                Tizen.Log.Error("NUI", "AutoScrollSpeed[" + label.AutoScrollSpeed + "] \n");
            };

            Button buttonOff = new Button
            {
                Text = "scene off",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(buttonOff);
            buttonOff.Clicked += (s, e) =>
            {
                view.Remove(label);
            };

            Button buttonAdd = new Button
            {
                Text = "scene add",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(buttonAdd);
            buttonAdd.Clicked += (s, e) =>
            {
                view.Add(label);
            };

            Button buttonStart = new Button
            {
                Text = "start",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(buttonStart);
            buttonStart.Clicked += (s, e) =>
            {
                label.EnableAutoScroll = true;
                label2.EnableAutoScroll = true;
                label3.EnableAutoScroll = true;
                label4.EnableAutoScroll = true;
            };

            Button buttonStop = new Button
            {
                Text = "stop",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(buttonStop);
            buttonStop.Clicked += (s, e) =>
            {
                label.EnableAutoScroll = false;
                label2.EnableAutoScroll = false;
                label3.EnableAutoScroll = false;
                label4.EnableAutoScroll = false;
            };

            Button buttonMultiLineTrue = new Button
            {
                Text = "system lan true",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(buttonMultiLineTrue);
            buttonMultiLineTrue.Clicked += (s, e) =>
            {
                label.MatchSystemLanguageDirection = true;
                label2.MatchSystemLanguageDirection = true;
                label3.MatchSystemLanguageDirection = true;
                label4.MatchSystemLanguageDirection = true;
            };

            Button buttonMultiLineFalse = new Button
            {
                Text = "system lan false",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(buttonMultiLineFalse);
            buttonMultiLineFalse.Clicked += (s, e) =>
            {
                label.MatchSystemLanguageDirection = false;
                label2.MatchSystemLanguageDirection = false;
                label3.MatchSystemLanguageDirection = false;
                label4.MatchSystemLanguageDirection = false;
            };
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                //MatchSystemLanguageDirection = true,
                //MultiLine = true,
                AutoScrollStopMode = AutoScrollStopMode.Immediate,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                EnableAutoScroll = true,
                AutoScrollLoopCount = 0,
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
