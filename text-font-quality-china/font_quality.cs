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
                BackgroundColor = new Color(0.15f, 0.20f, 0.30f, 1.0f),

            };
            window.Add(view);

            string text1 = "SamsungOneUI_600, 14 : 篇海多事多端龍國欟虌钃䶩虋龗齉寤寐不忘輾轉反側九曲肝腸鳥輾轉不寐ইফেক্টস্বয়ংক্ৰিয়লৈছেটকৰিলেএইফাংছনউপলভ্যက်ရောက်မှုကိုအော်တိုထားချိန်မှာသည်လုပ်ဆောင်ချက်မရနိုင်ပါ။৷ไม่สามารถใช้ฟังก์ชั่นนี้ได้เมื่อตั้งเอฟเฟ";
            string text2 = "SamsungOneUI_600, 16 : 篇海多事多端龍國欟虌钃䶩虋龗齉寤寐不忘輾轉反側九曲肝腸鳥輾轉不寐ইফেক্টস্বয়ংক্ৰিয়লৈছেটকৰিলেএইফাংছনউপলভ্যက်ရောက်မှုကိုအော်တိုထားချိန်မှာသည်လုပ်ဆောင်ချက်မရနိုင်ပါ။৷ไม่สามารถใช้ฟังก์ชั่นนี้ได้เมื่อตั้งเอฟเฟ";
            string text3 = "SamsungOneUI_600, 18 : 篇海多事多端龍國欟虌钃䶩虋龗齉寤寐不忘輾轉反側九曲肝腸鳥輾轉不寐ইফেক্টস্বয়ংক্ৰিয়লৈছেটকৰিলেএইফাংছনউপলভ্যက်ရောက်မှုကိုအော်တိုထားချိန်မှာသည်လုပ်ဆောင်ချက်မရနိုင်ပါ။৷ไม่สามารถใช้ฟังก์ชั่นนี้ได้เมื่อตั้งเอฟเฟ";
            string text4 = "SamsungOneUI_600, 20 : 篇海多事多端龍國欟虌钃䶩虋龗齉寤寐不忘輾轉反側九曲肝腸鳥輾轉不寐ইফেক্টস্বয়ংক্ৰিয়লৈছেটকৰিলেএইফাংছনউপলভ্যက်ရောက်မှုကိုအော်တိုထားချိန်မှာသည်လုပ်ဆောင်ချက်မရနိုင်ပါ။৷ไม่สามารถใช้ฟังก์ชั่นนี้ได้เมื่อตั้งเอฟเฟ";
            string text5 = "SamsungOneUI_700, 14 : 篇海多事多端龍國欟虌钃䶩虋龗齉寤寐不忘輾轉反側九曲肝腸鳥輾轉不寐ইফেক্টস্বয়ংক্ৰিয়লৈছেটকৰিলেএইফাংছনউপলভ্যက်ရောက်မှုကိုအော်တိုထားချိန်မှာသည်လုပ်ဆောင်ချက်မရနိုင်ပါ။৷ไม่สามารถใช้ฟังก์ชั่นนี้ได้เมื่อตั้งเอฟเฟ";
            string text6 = "SamsungOneUI_700, 16 : 篇海多事多端龍國欟虌钃䶩虋龗齉寤寐不忘輾轉反側九曲肝腸鳥輾轉不寐ইফেক্টস্বয়ংক্ৰিয়লৈছেটকৰিলেএইফাংছনউপলভ্যက်ရောက်မှုကိုအော်တိုထားချိန်မှာသည်လုပ်ဆောင်ချက်မရနိုင်ပါ။৷ไม่สามารถใช้ฟังก์ชั่นนี้ได้เมื่อตั้งเอฟเฟ";
            string text7 = "SamsungOneUI_700, 18 : 篇海多事多端龍國欟虌钃䶩虋龗齉寤寐不忘輾轉反側九曲肝腸鳥輾轉不寐ইফেক্টস্বয়ংক্ৰিয়লৈছেটকৰিলেএইফাংছনউপলভ্যက်ရောက်မှုကိုအော်တိုထားချိန်မှာသည်လုပ်ဆောင်ချက်မရနိုင်ပါ။৷ไม่สามารถใช้ฟังก์ชั่นนี้ได้เมื่อตั้งเอฟเฟ";
            string text8 = "SamsungOneUI_700, 20 : 篇海多事多端龍國欟虌钃䶩虋龗齉寤寐不忘輾轉反側九曲肝腸鳥輾轉不寐ইফেক্টস্বয়ংক্ৰিয়লৈছেটকৰিলেএইফাংছনউপলভ্যက်ရောက်မှုကိုအော်တိုထားချိန်မှာသည်လုပ်ဆောင်ချက်မရနိုင်ပါ။৷ไม่สามารถใช้ฟังก์ชั่นนี้ได้เมื่อตั้งเอฟเฟ";

            var label1 = NewTextLabel(text1, "SamsungOneUISCN", 5);
            view.Add(label1);

            var label2 = NewTextLabel(text2, "SamsungOneUISCN", 6);
            view.Add(label2);

            var label3 = NewTextLabel(text3, "SamsungOneUISCN", 7);
            view.Add(label3);

            var label4 = NewTextLabel(text4, "SamsungOneUISCN", 8);
            view.Add(label4);

            var label5 = NewTextLabel(text5, "SamsungOneUISCN", 9);
            view.Add(label5);

            var label6 = NewTextLabel(text6, "SamsungOneUISCN", 10);
            view.Add(label6);

            var label7 = NewTextLabel(text7, "SamsungOneUISCN", 11);
            view.Add(label7);

            var label8 = NewTextLabel(text8, "SamsungOneUISCN", 12);
            view.Add(label8);
        }

        public TextLabel NewTextLabel(string text, string family, float size)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = family,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = size,
                //BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                TextColor = Color.White,
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
