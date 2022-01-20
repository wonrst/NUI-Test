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

        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            View view = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            window.Add(view);

            var color1 = Color.Red;
            var color2 = new Color(1.0f, 0.0f, 0.0f, 1.0f); // red
            var color3 = Color.Blue;
            var color4 = new Color(0.0f, 0.0f, 1.0f, 1.0f); // blue

            if (color1 == color2)
                Tizen.Log.Error("NUI", $"color1[{GetColor(color1)}] == color2[{GetColor(color2)}] \n");

            if (color1 != color2)
                Tizen.Log.Error("NUI", $"color1[{GetColor(color1)}] != color2[{GetColor(color2)}] \n");

            if (color1 == color3)
                Tizen.Log.Error("NUI", $"color1[{GetColor(color1)}] == color3[{GetColor(color3)}] \n");

            if (color1 != color3)
                Tizen.Log.Error("NUI", $"color1[{GetColor(color1)}] != color3[{GetColor(color3)}] \n");

            if (color3 == color4)
                Tizen.Log.Error("NUI", $"color3[{GetColor(color3)}] == color4[{GetColor(color4)}] \n");

            if (color3 != color4)
                Tizen.Log.Error("NUI", $"color3[{GetColor(color3)}] != color4[{GetColor(color4)}] \n");

            Tizen.Log.Error("NUI", "color1 GetHashCode " + color1.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "color2 GetHashCode " + color2.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "color3 GetHashCode " + color3.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "color4 GetHashCode " + color4.GetHashCode() + " \n");
        }

        string GetColor(Color color)
        {
            return color.R.ToString() + "," + color.G.ToString() + ","  + color.B.ToString() + ","  + color.A.ToString();
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
