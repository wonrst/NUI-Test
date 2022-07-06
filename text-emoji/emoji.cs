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


            //string new = "\U0001F170\U0000FE0E\U0001F171\U0001F172\U0000FE0E\U0001F173\U0001F174";



            string text1 = "&#x262a;&#xfe0e;이모지อัอัอั&#x262a;&#xfe0f;&#x1F1F0;&#x1F1F7;&#x1F1FA;&#x1F1F8;&#x1F1EC;&#x1F1E7;&#x1F1EB;&#x1F1F7;&#x1F1EE;&#x1F1F9;&#x1F1E8;&#x1F1E6;";
            var label1 = newTextLabel(text1);
            view.Add(label1);



            string text2 = "&#x262a;&#xfe0e;이모지อัอัอั&#x262a;&#xfe0f;&#x1F1F0;&#x1F1F7;&#x1F1FA;&#x1F1F8;&#x1F1EC;&#x1F1E7;&#x1F1EB;&#x1F1F7;&#x1F1EE;&#x1F1F9;&#x1F1E8;&#x1F1E6;";
            var label2 = newTextField(text2);
            view.Add(label2);



            string text3 = "&#x200c;&#x200d;abc&#x1f469;&#x200d;&#x1f52c;def&#x200d;";
            var label3 = newTextField(text3);
            view.Add(label3);



            string text4 = "abc&#x1f469;&#x200d;&#x1f466; &#x1f469;&#x200c;&#x1f466; &#x1f469;&#x200d;&#x1f52c;def";
            var label4 = newTextLabel(text4);
            view.Add(label4);



            string text5 = "&#x200d;abc&#x1f469;&#x200d;&#x1f466; &#x1f469;&#x1f466; &#x1f469;&#x200d;&#x1f52c;def";
            var label5 = newTextField(text5);
            view.Add(label5);



            string text6 = "&#x1f469;&#x200d;&#x1f52c;";
            var label6 = newTextLabel(text6);
            view.Add(label6);



            string text7 = "&#x0030;&#xfe0f;&#x20e3;&#x0031;&#xfe0f;&#x20e3;&#x0032;&#xfe0f;&#x20e3;&#x0033;&#xfe0f;&#x20e3;";
            var label7 = newTextLabel(text7);
            view.Add(label7);



            string text8 = "&#x1f3f3;&#xfe0f;&#x200d;&#x1f308;";
            var label8 = newTextLabel(text8);
            view.Add(label8);



            string text9 = "&#x1f3f3;&#x200d;&#x1f308;";
            var label9 = newTextLabel(text9);
            view.Add(label9);



            string text10 = "0&#xfe0f;&#x20e3;1&#xfe0f;&#x20e3;2&#xfe0f;&#x20e3;3&#xfe0f;&#x20e3;";
            var label10 = newTextLabel(text10);
            view.Add(label10);



            string text11 = "0&#xfe0f;&#x20e3;1&#xfe0f;&#x20e3;2&#xfe0f;&#x20e3;3&#xfe0f;&#x20e3;";
            var label11 = newTextLabel(text11);
            view.Add(label11);



            string text12 = "0&#xfe0e;&#x20e3;1&#xfe0f;&#x20e3;2&#xfe0e;&#x20e3;3&#xfe0f;&#x20e3;";
            var label12 = newTextLabel(text12);
            view.Add(label12);



            string text13 = "&#x262a;&#xfe0f;&#xfe0f;&#xfe0f;&#x262a;&#xfe0f;";
            var label13 = newTextField(text13);
            view.Add(label13);
        }

        public TextLabel newTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            return label;
        }

        public TextField newTextField(string text)
        {
            var field = new TextField
            {
                Text = text,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            setHandle(field);
            return field;
        }

        public void setHandle(TextField field)
        {
            field.GrabHandleImage = "images/handle_down.png";

            PropertyMap imageLeftMap = new PropertyMap();
            imageLeftMap.Add("filename", new PropertyValue("images/handle_downleft.png"));
            field.SelectionHandleImageLeft = imageLeftMap;

            PropertyMap imageRightMap = new PropertyMap();
            imageRightMap.Add("filename", new PropertyValue("images/handle_downright.png"));
            field.SelectionHandleImageRight = imageRightMap;
        }


        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
