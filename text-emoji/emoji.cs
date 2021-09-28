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

/*
            // Normal label
            TextLabel label = new TextLabel
            {
                FontFamily = "SamsungColorEmoji",
                Text = "&#x262a;&#xfe0e;이모지อัอัอั&#x262a;&#xfe0f;&#x1F1F0;&#x1F1F7;&#x1F1FA;&#x1F1F8;&#x1F1EC;&#x1F1E7;&#x1F1EB;&#x1F1F7;&#x1F1EE;&#x1F1F9;&#x1F1E8;&#x1F1E6;",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(label);

            // Normal field
            TextField field = new TextField
            {
                FontFamily = "SamsungColorEmoji",
                Text = "&#x262a;&#xfe0e;이모지อัอัอั&#x262a;&#xfe0f;&#x1F1F0;&#x1F1F7;&#x1F1FA;&#x1F1F8;&#x1F1EC;&#x1F1E7;&#x1F1EB;&#x1F1F7;&#x1F1EE;&#x1F1F9;&#x1F1E8;&#x1F1E6;",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(field);
            setHandle(field);


            // Normal field
            TextField field2 = new TextField
            {
                FontFamily = "SamsungColorEmoji",
                Text = "&#x1f938;&#x200d;&#x2642;&#xfe0f;",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(field2);
            setHandle(field2);


*/
            // Normal label
            TextLabel label2 = new TextLabel
            {
                FontFamily = "SamsungColorEmoji",
                //Text = "&#x1f469;&#x200d;&#x1f466; &#x1f469;&#x1f466; &#x1f469;&#x200d;&#x1f52c;",
                Text = "123&#x1f469;&#x200d;&#x1f52c;456",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(label2);

/*
            // Normal field
            TextField field3 = new TextField
            {
                FontFamily = "SamsungColorEmoji",
                //Text = "&#x1f469;&#x200d;&#x1f466; &#x1f469;&#x1f466; &#x1f469;&#x200d;&#x1f52c;",
                //Text = "123 &#x1f469;&#x200d;&#x1f52c; 456",
                Text = "123&#x1f469;&#x200d;&#x1f52c;456",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(field3);
            setHandle(field3);*/

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

        public void setHandle(TextEditor editor)
        {
            editor.GrabHandleImage = "images/handle_down.png";

            PropertyMap imageLeftMap = new PropertyMap();
            imageLeftMap.Add("filename", new PropertyValue("images/handle_downleft.png"));
            editor.SelectionHandleImageLeft = imageLeftMap;

            PropertyMap imageRightMap = new PropertyMap();
            imageRightMap.Add("filename", new PropertyValue("images/handle_downright.png"));
            editor.SelectionHandleImageRight = imageRightMap;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
