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


            // reference LRE PDF RLE PDF
            // &#x202a; LTR &#x202c &#x202b; RTL &#x202c;
            string textOriginal = "[Original]\n امسح رمز QR باستخدام تطبيق الكاميرا على جهاز محمول لديك.تنتهي صلاحية الرمز في 24: 59.";

            string textWithoutSpace = "[without space]\n امسح رمز QR باستخدام تطبيق الكاميرا على جهاز محمول لديك.تنتهي صلاحية الرمز في 24:59.";

            string textWithSymbol = "[U200E]\n امسح رمز QR باستخدام تطبيق الكاميرا على جهاز محمول لديك.تنتهي صلاحية الرمز في &#x200e;24: 59.";

            string textWithSymbolPop = "[LRE PDF RLE PDF]\n امسح رمز QR باستخدام تطبيق الكاميرا على جهاز محمول لديك.تنتهي صلاحية الرمز في &#x202a;24: 59&#x202c;.";


            view.Add(NewTextLabel(textOriginal));
            view.Add(NewTextLabel(textWithoutSpace));
            view.Add(NewTextLabel(textWithSymbol));
            view.Add(NewTextLabel(textWithSymbolPop));
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                LayoutDirection = ViewLayoutDirectionType.RTL,
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
