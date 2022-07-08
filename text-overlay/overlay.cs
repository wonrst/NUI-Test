using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.Text;
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

            TextLabel label = newTextLabel(true, true, false);
            view.Add(label);

            TextLabel label2 = newTextLabel(true, false, true);
            view.Add(label2);

            TextLabel label3 = newTextLabel(true, true, true);
            view.Add(label3);

            TextLabel label4 = newTextLabel(false, true, false);
            view.Add(label4);

            TextLabel label5 = newTextLabel(false, false, true);
            view.Add(label5);

            TextLabel label6 = newTextLabel(false, true, true);
            view.Add(label6);
        }

        public TextLabel newTextLabel(bool isMarkup, bool isUnderline, bool isStrikethrough)
        {
            string str = "Text overlay style test";

            if (isMarkup)
            {
                if (isUnderline && isStrikethrough)
                    str = "<background color='yellow'>Text <u height='8' color='red'>overlay <s height='8' color='blue'>style</u> test</s></background>";
                else
                {
                    if (isUnderline)
                        str = "<background color='#BCBCBC'>Text <u height='8' color='red'>overlay style</u> test</background>";

                    if (isStrikethrough)
                        str = "<background color='green'>Text <s height='8' color='blue'>overlay style</s> test</background>";
                }
            }

            var label = new TextLabel
            {
                Text = str,
                EnableMarkup = isMarkup,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 35.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };

            if (!isMarkup)
            {
                if (isUnderline)
                {
                    var underline = new Tizen.NUI.Text.Underline();
                    underline.Enable = true;
                    underline.Color = Color.Red;
                    underline.Height = 8.0f;
                    label.SetUnderline(underline);
                }

                if (isStrikethrough)
                {
                    var strikethrough = new Tizen.NUI.Text.Strikethrough();
                    strikethrough.Enable = true;
                    strikethrough.Color = Color.Blue;
                    strikethrough.Height = 8.0f;
                    label.SetStrikethrough(strikethrough);
                }
            }

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
