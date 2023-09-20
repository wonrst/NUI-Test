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
        public bool textChanged = false;

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
                BackgroundColor = Color.White,
            };
            window.Add(view);

            TextLabel label = new TextLabel
            {
                Text = "Hello, world",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontFamily = "SamsungOneUI",
            };
            view.Add(label);

            TextLabel label2 = new TextLabel
            {
                Text = "Hello, world",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.Black,
                TextColor = Color.White,
            };
            view.Add(label2);

/*
            TextLabel label = new TextLabel
            {
                Text = "&#x200f;اسم الجهاز : &#x200e;Galaxy Buds Pro (36C4)&#x200f;",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.Gray,
                LayoutDirection = ViewLayoutDirectionType.RTL,
            };
            view.Add(label);

            TextLabel label2 = new TextLabel
            {
                Text = "&#x200f;اسم الجهاز : &#x200e;Galaxy Buds Pro (36C4)&#x200f;",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.Gray,
                LayoutDirection = ViewLayoutDirectionType.LTR,
            };
            view.Add(label2);


            TextLabel label3 = new TextLabel
            {
                Text = "&#x200f;اسم الجهاز : &#x200e;Galaxy Buds Pro (36C4)&#x200e;",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.Gray,
                LayoutDirection = ViewLayoutDirectionType.RTL,
            };
            view.Add(label3);

            TextLabel label4 = new TextLabel
            {
                Text = "&#x200f;اسم الجهاز : &#x200e;Galaxy Buds Pro (36C4)&#x200e;",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.Gray,
                LayoutDirection = ViewLayoutDirectionType.LTR,
            };
            view.Add(label4);
*/

            TextLabel label7 = new TextLabel
            {
                Text = "اسم الجهاز : Galaxy Buds Pro (36C4)",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.Gray,
                LayoutDirection = ViewLayoutDirectionType.RTL,
            };
            view.Add(label7);


            string test = "Hello world demo\nhello world\nhello world (مرحبا بالعالم שלום) עולם\nשלום مرحبا بالعالم עולם (hello) مرحبا بالعالم world" +
                          " مرحبا بالعالم שלום עולם hello world hello world\nبالعالم שלום (hello) world demo (עולם)\nשלום (مرحبا بالعالم עולם) (hello)";
     

            TextLabel label5 = new TextLabel
            {
                Text = test,
                //Text = "שלום עולם\n(مرحبا بالعالم)",
                //Text = "اسم الجهاز : Galaxy Buds Pro (36C4",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.Gray,
                LayoutDirection = ViewLayoutDirectionType.LTR,
            };
            view.Add(label5);

            TextLabel label6 = new TextLabel
            {
                Text = "اسم الجهاز : Galaxy Buds Pro 36C4)",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.Gray,
                LayoutDirection = ViewLayoutDirectionType.RTL,
            };
            view.Add(label6);


            TextLabel label8 = new TextLabel
            {
                Text = "اسم الجهاز : Galaxy Buds Pro (36C4)(",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.Gray,
                LayoutDirection = ViewLayoutDirectionType.RTL,
            };
            view.Add(label8);


            TextLabel label0 = new TextLabel
            {
                Text = "اسم الجهاز : Galaxy Buds Pro (36C4)()[[]](}",
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.Gray,
                LayoutDirection = ViewLayoutDirectionType.RTL,
            };
            view.Add(label0);





            int width = 480;

            var button = new Button
            {
                //Text = "+",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            button.Clicked += (s, e) =>
            {
                width += 10;
                ///abel5.WidthSpecification = width;
                //label6.WidthSpecification = width;
                //label.WidthSpecification = width;
                //label2.WidthSpecification = width;
                label7.WidthSpecification = width;
            };
            view.Add(button);

            var button2 = new Button
            {
                //Text = "-",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            button2.Clicked += (s, e) =>
            {
                width -= 10;
                //label5.WidthSpecification = width;
                //label6.WidthSpecification = width;
                //label.WidthSpecification = width;
                //label2.WidthSpecification = width;
                label7.WidthSpecification = width;
            };
            view.Add(button2);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
