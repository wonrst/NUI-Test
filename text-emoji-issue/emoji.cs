using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

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


            //string text = "\U0001F170\U0001F171\U0001F172abc\U0001F173\U0001F174";
            //string text = "\U0001F170\U0001F171\U0001F172\U0000FE0E\U0001F173\U0000FE0E\U0001F174\U0000FE0E";
            //string text = "&#x1f173;&#xfe0e;";
            //string text = "&#x1f170;&#x1f171;abc&#x1f172;&#x1f173;&#x1f174;";
            //string text = "&#x1f173;&#x1f170;";
            //string text = "&#x1f170;";
            //string text = "\U0001F170\U0001F171\U0001F172\U0001F173\U0001F174";
            //string text = "\U0000F01A";
            //string text = "🅰 🅱 🅲 🅳 🅴 🅵 🅶 🅷 🅸 🅹 🅺 🅻 🅼 🅽 🅾 🅿 🆀 🆁 🆂 🆃 🆄 🆅 🆆 🆇 🆈 🆉";
            //string text = "🅰🅱🅲🅳🅴🅵🅶🅷🅸🅹🅺🅻🅼🅽🅾🅿🆀🆁🆂🆃🆄🆅🆆🆇🆈🆉";
            //string text = "🅰🅱🅲&#xfe0e;🅳&#xfe0e;🅴&#xfe0e;🅵🅶🅷🅸🅹🅺🅻🅼🅽🅾🅿🆀🆁🆂🆃🆄🆅🆆🆇🆈🆉";



            // no varication seletor, text vs emoji
            string noVS = "&#x1f170;";
            var label1 = newTextLabel(noVS);
            view.Add(label1);

            var label2 = newTextLabel(noVS);
            label2.FontFamily = "SamsungColorEmoji";
            view.Add(label2);



            // compare VS15 and VS16
            string VS15 = "&#x1f170;&#xfe0e;";
            var label3 = newTextLabel(VS15);
            view.Add(label3);

            string VS16 = "&#x1f170;&#xfe0f;";
            var label4 = newTextLabel(VS16);
            view.Add(label4);



            // 1F170 ~ 1F174, text vs emoji
            //string textAtoE = "\U0001F170\U0001F171\U0001F172\U0001F173\U0001F174";
            string textAtoE = "&#x1f170;&#x1f171;&#x1f172;&#x1f173;&#x1f174;";
            var label5 = newTextLabel(textAtoE);
            view.Add(label5);

            var label6 = newTextLabel(textAtoE);
            label6.FontFamily = "SamsungColorEmoji";
            view.Add(label6);



            // space + 1F170 ~ 1F174, text vs emoji
            string textAtoEwithSpace = "\U0001F170 \U0001F171 \U0001F172 \U0001F173 \U0001F174";
            var label7 = newTextLabel(textAtoEwithSpace);
            view.Add(label7);

            var label8 = newTextLabel(textAtoEwithSpace);
            label8.FontFamily = "SamsungColorEmoji";
            view.Add(label8);



            //  1F170 ~ 1F174 with variation selector, text vs emoji
            string textAtoEwithVS = "&#x1f170;&#xfe0f;&#x1f171;&#xfe0f;&#x1f172;&#xfe0e;&#x1f173;&#xfe0e;&#x1f174;&#xfe0e;";
            var label9 = newTextLabel(textAtoEwithVS);
            view.Add(label9);

            var label10 = newTextLabel(textAtoEwithVS);
            label10.FontFamily = "SamsungColorEmoji";
            view.Add(label10);
        }

        public TextLabel newTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                VerticalAlignment = VerticalAlignment.Center,
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
