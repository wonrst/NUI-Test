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
            window.Add(view);

            //EnglishOutlineTest(view);
            MultiLanguageOutlineTest(view);





        }

        public void EnglishOutlineTest(View view)
        {
            view.Add(NewTextLabel("uVWXYZ", 27.0f));
            view.Add(NewTextLabel("uVWXYZ", 28.0f));
            view.Add(NewTextLabel("uVWXYZ", 56.0f));
            view.Add(NewTextLabel("uVWXYZ", 58.0f));
            view.Add(NewTextLabel("uVWXYZ", 60.0f));
            view.Add(NewTextLabel("uVWXYZ", 80.0f));
        }

        public void MultiLanguageOutlineTest(View view)
        {
            string rtl1 = "تَعْدِيلْ قِسْمْ Arabic كَلِمَة أَرْمَلَة";
            string rtl2 = "ضرورت گرڈ میں تبدیل کرنا ہوگا";
            var emojiLabel = NewTextLabel("\xF0\x9F\x98\x81 A Quick Brown Fox Jumps Over The Lazy Dog", 16.0f);
            emojiLabel.FontFamily = "BreezeColorEmoji";

            view.Add(emojiLabel);
            view.Add(NewTextLabel(rtl1, 18.0f));
            view.Add(NewTextLabel("ໄປຫາຕາຕະລາງທີ່ກຳນົດ", 20.0f));
            view.Add(NewTextLabel("ပန္စီစဥ္ရန္ အျမင္ပံုစံကို စိတ္ၾကိဳက္လုပ္ႏိုင္ေသာ ဂရ", 22.0f));
            view.Add(NewTextLabel(rtl2, 24.0f));
            view.Add(NewTextLabel("보기 방식을 격자 보기(직접 설정)로", 26.0f));
        }

        public TextLabel NewTextLabel(string text, float pointSize)
        {
            var label = new TextLabel
            {
                Text = text,
                PointSize = pointSize,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };

            var outline = new Tizen.NUI.Text.Outline();
            outline.Width = 1.0f;
            outline.Color = Color.Red;
            label.SetOutline(outline);

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
