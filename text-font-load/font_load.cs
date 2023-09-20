using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;

namespace TextComponentsTest
{
    class Example : NUIApplication
    {
        protected override void OnPreCreate()
        {
            List<string> fallbackFamilyList = new List<string>(new string[] {"SamsungOneUI", "SamsungOneUI_200", "SamsungOneUI_300", "SamsungOneUI_400", "SamsungOneUI_450", "SamsungOneUI_500", "SamsungOneUI_600", "SamsungOneUI_700"});
            List<string> extraFamilyList = new List<string>(new string[] {"SamsungOneFallbackVD"});
            string localeFamily = "SamsungOneUIKorean";
            bool useThread = true;
            FontClient.PreCache(fallbackFamilyList, extraFamilyList, localeFamily, useThread);
            
            List<string> fontPathList = new List<string>(new string[] {
                "/usr/share/fonts/SamsungOneUI-200.ttf",
                "/usr/share/fonts/SamsungOneUI-300.ttf",
                "/usr/share/fonts/SamsungOneUI-400.ttf",
                "/usr/share/fonts/SamsungOneUI-500.ttf",
                "/usr/share/fonts/SamsungOneUI-600.ttf",
                "/usr/share/fonts/SamsungOneUI-700.ttf",
                "/usr/share/fonts/SamsungOneUIKorean-200.ttf",
                "/usr/share/fonts/SamsungOneUIKorean-300.ttf",
                "/usr/share/fonts/SamsungOneUIKorean-400.ttf",
                "/usr/share/fonts/SamsungOneUIKorean-500.ttf",
                "/usr/share/fonts/SamsungOneUIKorean-600.ttf",
                "/usr/share/fonts/SamsungOneUIKorean-700.ttf"});
            FontClient.FontPreLoad(fontPathList, null, useThread);
        }

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

            string shortENG = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            string shortKOR = "국민의 자유와 권리는 헌법에 열거되지 아니한 이유로 경시되지 아니한다.";

            TextLabel label = NewTextLabel(shortENG, "SamsungOneUI 300");
            view.Add(label);

            TextLabel label2 = NewTextLabel(shortENG, "SamsungOneUI 400");
            view.Add(label2);

            TextLabel label3 = NewTextLabel(shortENG, "SamsungOneUI 600");
            view.Add(label3);

            TextLabel label4 = NewTextLabel(shortENG, "SamsungOneUI 700");
            view.Add(label4);

            TextLabel label5 = NewTextLabel(shortKOR, "SamsungOneUIKorean 300");
            view.Add(label5);

            TextLabel label6 = NewTextLabel(shortKOR, "SamsungOneUIKorean 400");
            view.Add(label6);

            TextLabel label7 = NewTextLabel(shortKOR, "SamsungOneUIKorean 600");
            view.Add(label7);

            TextLabel label8 = NewTextLabel(shortKOR, "SamsungOneUIKorean 700");
            view.Add(label8);

        }

        public TextLabel NewTextLabel(string text, string family)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = family,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 10.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
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
