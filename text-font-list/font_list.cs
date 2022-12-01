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
            var window = Window.Instance;
            window.BackgroundColor = Color.White;

            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(5, 5),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            window.Add(view);

            view.Add(NewTextLabel("System font list : ", 15.0f));

            var scroll = new ScrollableBase()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 260,
                BackgroundColor = Color.White,
            };
            view.Add(scroll);

            var listView = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(5, 5),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            scroll.Add(listView);

            var fontName = NewTextLabel("Font Name : ", 15.0f);
            view.Add(fontName);

            var fontFamily = NewTextLabel("Font Family : ", 15.0f);
            view.Add(fontFamily);

            var fontPath = NewTextLabel("Font Path : ", 15.0f);
            view.Add(fontPath);

            var fontStyle = NewTextLabel("Font Style : ", 15.0f);
            view.Add(fontStyle);

            var displayText = NewTextLabel("Lorem ipsum dolor sit amet,\n1234567890-=!@#$%^&*()_+.", 30.0f);
            displayText.HorizontalAlignment = HorizontalAlignment.Center;
            view.Add(displayText);

            // get system font list
            List<Tizen.NUI.Text.FontInfo> fontList = FontClient.Instance.GetSystemFonts();

            foreach(Tizen.NUI.Text.FontInfo fontInfo in fontList)
            {
                Tizen.Log.Info("NUI", $"Font family[{fontInfo.Family}] path[{fontInfo.Path}] width[{fontInfo.Style.Width}] weight[{fontInfo.Style.Weight}] slant[{fontInfo.Style.Slant}] \n");

                string name = System.IO.Path.GetFileNameWithoutExtension(fontInfo.Path);

                Button button = NewButton(name);
                listView.Add(button);

                button.Clicked += (s, e) => {
                    fontName.Text = "FontName : " + name;
                    fontFamily.Text = "FontFamily : " + fontInfo.Family;
                    fontPath.Text = "FontPath : " + fontInfo.Path;
                    fontStyle.Text = $"FontStyle : Width[{fontInfo.Style.Width}] Weight[{fontInfo.Style.Weight}] Slant[{fontInfo.Style.Slant}]";

                    displayText.FontFamily = fontInfo.Family;
                    displayText.SetFontStyle(fontInfo.Style);
                };
            }
        }

        public TextLabel NewTextLabel(string text, float pointSize)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = pointSize,
                BackgroundColor = Color.White,
            };
            return label;
        }

        public Button NewButton(string text)
        {
            var button = new Button
            {
                Text = text,
                PointSize = 15.0f,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 30,
            };
            return button;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
