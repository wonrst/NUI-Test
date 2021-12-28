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
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);


            var geoH = NewLabel("H");
            view.Add(geoH);

            var geoW = NewLabel("W");
            view.Add(geoW);

            var naturalH = NewLabel("H");
            view.Add(naturalH);

            var naturalW = NewLabel("W");
            view.Add(naturalW);

            var button = new Button
            {
                Text = "get geometry",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "--- TEST --- \n");
                Tizen.Log.Error("NUI", "geoH Text.Length : " + geoH.Text.Length + "\n");
                Tizen.Log.Error("NUI", "geoW Text.Length : " + geoW.Text.Length + "\n");

                PrintNaturalSize(naturalH, "naturalH");
                PrintNaturalSize(naturalW, "naturalW");

                // geometry "H"
                Tizen.Log.Error("NUI", "--- geometry 'H' --- \n");
                PrintTextSize(geoH, "geoH");
                PrintTextPosition(geoH, "geoH");

                // geometry "W"
                Tizen.Log.Error("NUI", "--- geometry 'W' --- \n");
                PrintTextSize(geoW, "geoW");
                PrintTextPosition(geoW, "geoW");
            };

            var geoHello = NewLabel("Hello");
            view.Add(geoHello);

            var geoWorld = NewLabel("World");
            view.Add(geoWorld);

            var naturalHello = NewLabel("Hello");
            view.Add(naturalHello);

            var naturalWorld = NewLabel("World");
            view.Add(naturalWorld);

            var button2 = new Button
            {
                Text = "get geometry",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button2);
            button2.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "--- TEST --- \n");
                Tizen.Log.Error("NUI", "geoHello Text.Length : " + geoHello.Text.Length + "\n");
                Tizen.Log.Error("NUI", "geoWorld Text.Length : " + geoWorld.Text.Length + "\n");

                PrintNaturalSize(naturalHello, "naturalH");
                PrintNaturalSize(naturalWorld, "naturalW");

                // geometry "Hello"
                Tizen.Log.Error("NUI", "--- geometry 'Hello' --- \n");
                PrintTextSize(geoHello, "geoHello");
                PrintTextPosition(geoHello, "geoHello");

                // geometry "World"
                Tizen.Log.Error("NUI", "--- geometry 'World' --- \n");
                PrintTextSize(geoWorld, "geoWorld");
                PrintTextPosition(geoWorld, "geoWorld");
            };
        }

        public void PrintNaturalSize(TextLabel label, string title)
        {
            Tizen.Log.Error("NUI", title + " natural size[" + label.NaturalSize.Width + ", " + label.NaturalSize.Height + "] \n");
        }

        public void PrintTextSize(TextLabel label, string title)
        {
            List<Size2D> sizeList = TextGeometry.GetTextSize(label, 0, label.Text.Length - 1);

            Tizen.Log.Error("NUI", title + " sizeList count[" + sizeList.Count + "] \n");
            for (int i = 0 ; i < sizeList.Count ; i ++)
            {
                Tizen.Log.Error("NUI", title + " item[" + i + "] width[" + sizeList[i].Width + "] height[" + sizeList[i].Height + "] \n");
            }
        }

        public void PrintTextPosition(TextLabel label, string title)
        {
            List<Position2D> positionList = TextGeometry.GetTextPosition(label, 0, label.Text.Length - 1);

            Tizen.Log.Error("NUI", title + " positionList count[" + positionList.Count + "] \n");
            for (int i = 0 ; i < positionList.Count ; i ++)
            {
                Tizen.Log.Error("NUI", title + " item[" + i + "] X[" + positionList[i].X + "] Y[" + positionList[i].Y + "] \n");
            }
        }

        public TextLabel NewLabel(string text)
        {
            TextLabel label = new TextLabel
            {
                Text = text,
                EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = 100,
                HeightSpecification = 50,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                Ellipsis = true,
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
