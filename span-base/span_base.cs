using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Text;
using Tizen.NUI.Text.Spans;
using System.Collections.Generic;

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

            string str = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            var label = NewTextLabel();
            view.Add(label);

            var spannedText = SpannableString.Create(str);
            var redSpan = ForegroundColorSpan.Create(Color.Red);
            var blueSpan = ForegroundColorSpan.Create(Color.Blue);
            var greenSpan = ForegroundColorSpan.Create(Color.Green);
            var yellowSpan = ForegroundColorSpan.Create(Color.Yellow);

            spannedText.AttachSpan(redSpan, Tizen.NUI.Range.Create(2,5));
            spannedText.AttachSpan(blueSpan, Tizen.NUI.Range.Create(7,10));
            spannedText.AttachSpan(greenSpan, Tizen.NUI.Range.Create(12,20));
            spannedText.AttachSpan(yellowSpan, Tizen.NUI.Range.Create(25,35));
            spannedText.AttachSpan(ForegroundColorSpan.Create(Color.Gray), Tizen.NUI.Range.Create(40,50));

            TextSpannable.SetSpannedText(label, spannedText);






            var button = new Button
            {
                Text = "Span Information",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                PrintSpanInformation(spannedText);
            };
        }

        public void PrintSpanInformation(SpannableString spannedText)
        {
            List<BaseSpan> spans = new List<BaseSpan>();
            List<Tizen.NUI.Range> ranges = new List<Tizen.NUI.Range>();
            spannedText.RetrieveAllSpansAndRanges(spans, ranges);

            if (spans.Count != ranges.Count)
                return;

            Tizen.Log.Error("NUI", $"SpannableString [{spannedText.GetNumberOfCharacters()}]\n");
            Tizen.Log.Error("NUI", $"SpannableString [{spannedText.ToString()}]\n");

            Tizen.Log.Error("NUI", $"Span count[{spans.Count}] Range count[{ranges.Count}]\n");

            for (int i = 0 ; i < spans.Count ; i ++)
            {
                Tizen.Log.Error("NUI", $"Span[{i}] SpanType[{spans[i].SpanType}] Range[{ranges[i].StartIndex}, {ranges[i].EndIndex}]\n");
            }
        }

        public TextLabel NewTextLabel()
        {
            var label = new TextLabel
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                MultiLine = true,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            return label;
        }

        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
