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


            TextLabel label = new TextLabel
            {
                //FontFamily = "SamsungColorEmoji",
                Text = "&#x262a;&#xfe0e;이모지อัอัอั&#x262a;&#xfe0f;&#x1F1F0;&#x1F1F7;&#x1F1FA;&#x1F1F8;&#x1F1EC;&#x1F1E7;&#x1F1EB;&#x1F1F7;&#x1F1EE;&#x1F1F9;&#x1F1E8;&#x1F1E6;",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label);


            TextField field = new TextField
            {
                FontFamily = "SamsungColorEmoji",
                Text = "&#x262a;&#xfe0e;이모지อัอัอั&#x262a;&#xfe0f;&#x1F1F0;&#x1F1F7;&#x1F1FA;&#x1F1F8;&#x1F1EC;&#x1F1E7;&#x1F1EB;&#x1F1F7;&#x1F1EE;&#x1F1F9;&#x1F1E8;&#x1F1E6;",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(field);
            setHandle(field);


            TextField field2 = new TextField
            {
                //FontFamily = "SamsungColorEmoji",
                Text = "&#x200c;&#x200d;abc&#x1f469;&#x200d;&#x1f52c;def&#x200d;",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(field2);
            setHandle(field2);


            TextLabel label2 = new TextLabel
            {
                FontFamily = "SamsungColorEmoji",
                Text = "abc&#x1f469;&#x200d;&#x1f466; &#x1f469;&#x200c;&#x1f466; &#x1f469;&#x200d;&#x1f52c;def",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label2);


            // Normal field
            TextField field3 = new TextField
            {
                //FontFamily = "SamsungColorEmoji",
                Text = "&#x200d;abc&#x1f469;&#x200d;&#x1f466; &#x1f469;&#x1f466; &#x1f469;&#x200d;&#x1f52c;def",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(field3);
            setHandle(field3);


            TextLabel label3 = new TextLabel
            {
                //FontFamily = "SamsungColorEmoji",
                Text = "&#x1f469;&#x200d;&#x1f52c;",
                //Text = "&#x0030;&#xfe0f;&#x20e3;&#x0031;&#xfe0f;&#x20e3;&#x0032;&#xfe0f;&#x20e3;&#x0033;&#xfe0f;&#x20e3;",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label3);


            TextLabel label4 = new TextLabel
            {
                //FontFamily = "SamsungColorEmoji",
                Text = "&#x0030;&#xfe0f;&#x20e3;&#x0031;&#xfe0f;&#x20e3;&#x0032;&#xfe0f;&#x20e3;&#x0033;&#xfe0f;&#x20e3;",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label4);


            TextLabel label5 = new TextLabel
            {
                FontFamily = "SamsungColorEmoji",
                Text = "&#x1f3f3;&#xfe0f;&#x200d;&#x1f308;",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label5);


            TextLabel label6 = new TextLabel
            {
                //FontFamily = "SamsungColorEmoji",
                Text = "&#x1f3f3;&#x200d;&#x1f308;",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label6);


            TextLabel label7 = new TextLabel
            {
                //FontFamily = "SamsungColorEmoji",
                Text = "0&#xfe0f;&#x20e3;1&#xfe0f;&#x20e3;2&#xfe0f;&#x20e3;3&#xfe0f;&#x20e3;",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label7);


            TextLabel label8 = new TextLabel
            {
                //FontFamily = "SamsungColorEmoji",
                Text = "0&#xfe0e;&#x20e3;1&#xfe0f;&#x20e3;2&#xfe0e;&#x20e3;3&#xfe0f;&#x20e3;",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label8);

            TextField label9 = new TextField
            {
                //FontFamily = "SamsungColorEmoji",
                Text = "&#x262a;&#xfe0f;&#xfe0f;&#xfe0f;&#x262a;&#xfe0f;",
                EnableMarkup = true,
                //MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(label9);

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
