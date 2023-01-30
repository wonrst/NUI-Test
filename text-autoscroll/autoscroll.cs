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
            };
            window.Add(view);

            string shortText = "Lorem ipsum dolor";
            //string longText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            string longText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";

            TextLabel label = NewTextLabel(longText);
            view.Add(label);

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
            };
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                //MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                EnableAutoScroll = true,
                AutoScrollLoopCount = 1,
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
