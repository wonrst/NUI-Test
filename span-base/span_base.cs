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

//            string str = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";


/*
            var label = NewTextLabel();
            view.Add(label);

            string str = "Lorem ipsum dolor sit amet";
            var spannedText = SpannableString.Create(str);

            var redSpan = ForegroundColorSpan.Create(Color.Red);
            var underlineSpan = UnderlineSpan.Create();
            var fontSpan = FontSpan.Create("Ubuntu Mono",
                                            40.0f,
                                            FontWeightType.Light,
                                            FontWidthType.Condensed,
                                            FontSlantType.Italic);


            spannedText.AttachSpan(redSpan, Tizen.NUI.Range.Create(2, 8));
            spannedText.AttachSpan(underlineSpan, Tizen.NUI.Range.Create(12, 25));
            spannedText.AttachSpan(fontSpan, Tizen.NUI.Range.Create(5, 15));

            spannedText.AttachSpan(BoldSpan.Create(), Tizen.NUI.Range.Create(15, 25));
            spannedText.AttachSpan(BackgroundColorSpan.Create(Color.Yellow), Tizen.NUI.Range.Create(10, 20));

            label.SetSpannedText(spannedText);

*/

            var label = NewTextLabel();
            view.Add(label);

            string str = "Lorem ipsum dolor sit amet";
            var spannedText = SpannableString.Create(str);

            var redSpan = ForegroundColorSpan.Create(Color.Red);
            var blueSpan = ForegroundColorSpan.Create(Color.Blue);

            for (uint i = 0 ; i < spannedText.GetNumberOfCharacters() ; i ++)
            {
                if (i % 2 == 0)
                    spannedText.AttachSpan(redSpan, Tizen.NUI.Range.Create(i, i));
                else
                    spannedText.AttachSpan(blueSpan, Tizen.NUI.Range.Create(i, i));
            }

            label.SetSpannedText(spannedText);

            spannedText.DetachSpan(redSpan);

            label.SetSpannedText(spannedText);


/*
            spannedText.AttachSpan(greenSpan, Tizen.NUI.Range.Create(12, 20));
            spannedText.AttachSpan(yellowSpan, Tizen.NUI.Range.Create(25, 35));
            spannedText.AttachSpan(ForegroundColorSpan.Create(Color.Gray), Tizen.NUI.Range.Create(40,50));
*/


/*
            spannedText.AttachSpan(redSpan, Tizen.NUI.Range.Create(2, 5));
            spannedText.AttachSpan(redSpan, Tizen.NUI.Range.Create(8, 10));
            spannedText.AttachSpan(underlineSpan, Tizen.NUI.Range.Create(0, 15));

            spannedText.AttachSpan(ForegroundColorSpan.Create(Color.Blue), Tizen.NUI.Range.Create(7, 10));
            spannedText.AttachSpan(BoldSpan.Create(), Tizen.NUI.Range.Create(13, 18));

            spannedText.AttachSpan(fontSpan, Tizen.NUI.Range.Create(4, 23));
            spannedText.AttachSpan(fontSpan, Tizen.NUI.Range.Create(30, 40));
            spannedText.AttachSpan(fontSpan, Tizen.NUI.Range.Create(45, 50));
            spannedText.AttachSpan(BackgroundColorSpan.Create(Color.Green), Tizen.NUI.Range.Create(4, 23));
*/




            var button = new Button
            {
                Text = "Span Information",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            //view.Add(button);
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
                if (spans[i] != null)
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
