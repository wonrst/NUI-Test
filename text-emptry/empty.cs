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


            // Normal label
            TextField label = new TextField
            {
                Text = "Text",
                PointSize = 25.0f,
                BackgroundColor = Color.Red,
            };
            view.Add(label);

            // Normal label
            TextLabel label3 = new TextLabel
            {
                Text = "Label",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.Green,
            };
            view.Add(label3);

            // Normal label
            TextLabel label4 = new TextLabel
            {
                Text = "",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.Yellow,
            };
            view.Add(label4);

            // Normal label
            TextField label2 = new TextField
            {
                BackgroundColor = Color.Blue,
                Text = "test",
                PointSize = 25.0f,
                TextColor = Color.White,

                //Text = "",
            };
            view.Add(label2);

            /*
            PropertyMap fontStyle = new PropertyMap();
            fontStyle.Add("width", new PropertyValue("expanded"));  // width:  condensed, semiCondensed, normal, semiExpanded, expanded
            fontStyle.Add("weight", new PropertyValue("bold"));     // weight: thin, light, normal, regular, medium, bold
            fontStyle.Add("slant", new PropertyValue("italic"));    // slant:  normal, roman, italic, oblique
            label2.FontStyle = fontStyle;
            */

            // Normal label
            TextField label5 = new TextField
            {
                BackgroundColor = Color.Blue,
                Text = "",
                PointSize = 25.0f,
                TextColor = Color.White,
            };
            view.Add(label5);


        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
