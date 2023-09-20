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

            View mainView = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            window.Add(mainView);

            View padTop = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 20,
                BackgroundColor = Color.White,
            };
            mainView.Add(padTop);

            View view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            mainView.Add(view);

            View padLeft = new View()
            {
                WidthSpecification = 20,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            view.Add(padLeft);

            string text1 = "<color value='#CC6600'><p align='begin'><font family='SamsungColorEmoji' size='50'>🦊</font> <font family='SamsungOneUI 400' size='25'><u>The Quick Brown Fox Jumps Over The Lazy Dog</u></font> 🐶</p></color>" +
                           "<font size='30' family='SamsungColorEmoji'>🎋</font><font family='SamsungOneUISCN 600' size='20'><color value='#0066CC'><b>TIZEN</b></color> <color value='#606060'>興國安邦，巨擘八方！</color></font>" +
                           "<font size='20'><p align='end'><background color='#CC99FF'><color value='white'>مرحبا بكم في عالم النص.</color></background> مرحبا بالعالم. 🏜🐪 <b>Right-To-Left</b> </i>Languages</i>❗️\n<u color='#FF9933' height='2'>ברוכים הבאים לעולם הטקסט.</u> \nשלום עולם <font size='30' family='NotoColorEmoji'>🌴🐅🐘</font></p>" +
                           "<font size='50' family='SamsungColorEmoji'>🗻</font>よろしくおねがいします。\n</font>" +
                           "<color value='#808080'><font size='15' family='SamsungOneUIKorean 600'><b><color value='#0066CC'>✵타이젠</color></b>은 <background color='yellow'>모바일</background>, <background color='#FF8000'><s>웨어러블</s></background>, <background color='#FF9999'>TV</background>, <background color='#00CCCC'>IVI</background>, <background color='#66FFB2'>IoT</background> 기기 등\n<color value='red'>멀티 플랫폼</color>에 대응하는 범용 운영 체제이다.\n</font></color>" +
                           "<font family='SamsungColorEmoji' size='50'>😃😷😆😅🤣🥳</font>\n" +
                           " ";


            var label1 = newTextLabel(text1);
            view.Add(label1);

/*
            var label2 = newTextLabel(text1);
            label2.LayoutDirection = ViewLayoutDirectionType.RTL;
            view.Add(label2);
*/



            View padRight = new View()
            {
                WidthSpecification = 20,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            view.Add(padRight);
        }

        public TextLabel newTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = "SamsungOneUI 200",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                Padding = new Extents(100, 100, 100, 100),
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
