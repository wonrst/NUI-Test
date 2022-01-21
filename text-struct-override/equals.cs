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
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);


            Tizen.Log.Error("NUI", "-------------------------------------------------- \n");
            var fs1 = new Tizen.NUI.Text.FontStyle();
            //fs1.Width = FontWidthType.UltraCondensed;
            var fs2 = new Tizen.NUI.Text.FontStyle();
            //fs2.Weight = FontWeightType.Thin;
            var fs3 = new Tizen.NUI.Text.FontStyle();
            fs3.Slant = FontSlantType.Italic;
            Tizen.Log.Error("NUI", "\n\n");

            if (fs1 == fs2)
            {
                Tizen.Log.Error("NUI", "style 1 == 2 \n");
            }

            if (fs1 != fs3)
            {
                Tizen.Log.Error("NUI", "style 1 != 3 \n");
            }

            Tizen.Log.Error("NUI", "fs1 GetHashCode " + fs1.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "fs2 GetHashCode " + fs2.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "fs3 GetHashCode " + fs3.GetHashCode() + " \n");
            

            Tizen.Log.Error("NUI", "-------------------------------------------------- \n");
            var color1 = new Color(1.0f, 1.0f, 0.0f, 1.0f);
            var color2 = new Color(1.0f, 1.0f, 0.0f, 1.0f);
            var color3 = new Color(1.0f, 0.5f, 0.0f, 1.0f);
            if (color1 == color2)
            {
                Tizen.Log.Error("NUI", "color 1 == 2 \n");
            }
            else
            {
                Tizen.Log.Error("NUI", "color 1 != 2 \n");
            }

            if (color1 != color3)
            {
                Tizen.Log.Error("NUI", "color 1 != 3 \n");
            }
            else
            {
                Tizen.Log.Error("NUI", "color 1 == 3 \n");
            }

            Tizen.Log.Error("NUI", "color1 GetHashCode " + color1.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "color2 GetHashCode " + color2.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "color3 GetHashCode " + color3.GetHashCode() + " \n");


            Tizen.Log.Error("NUI", "-------------------------------------------------- \n");
            var underline1 = new Tizen.NUI.Text.Underline();
            var underline2 = new Tizen.NUI.Text.Underline();
            var underline3 = new Tizen.NUI.Text.Underline();

            //underline1.Color = Color.Red;
            //underline2.Color = Color.Blue;
            //underline3.Color = Color.Red;

            //underline1.Height = 3.0f;
            //underline2.Height = 3.0f;
            underline3.Height = 5.0f;

            if (underline1 == underline2)
            {
                Tizen.Log.Error("NUI", "underline 1 == 2 \n");
            }

            if (underline1 != underline3)
            {
                Tizen.Log.Error("NUI", "underline 1 != 3 \n");
            }

            Tizen.Log.Error("NUI", "underline1 GetHashCode " + underline1.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "underline2 GetHashCode " + underline2.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "underline3 GetHashCode " + underline3.GetHashCode() + " \n");


            Tizen.Log.Error("NUI", "-------------------------------------------------- \n");
            var if1 = new Tizen.NUI.Text.InputFilter();
            var if2 = new Tizen.NUI.Text.InputFilter();
            var if3 = new Tizen.NUI.Text.InputFilter();

            if1.Accepted = @"[\d]";
            if2.Accepted = "[\\d]";
            if3.Rejected = @"[\d]";

            if (if1 == if2)
            {
                Tizen.Log.Error("NUI", "InputFilter 1 == 2 \n");
            }

            if (if1 != if3)
            {
                Tizen.Log.Error("NUI", "InputFilter 1 != 3 \n");
            }

            Tizen.Log.Error("NUI", "InputFilter1 GetHashCode " + if1.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "InputFilter2 GetHashCode " + if2.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "InputFilter3 GetHashCode " + if3.GetHashCode() + " \n");


            Tizen.Log.Error("NUI", "-------------------------------------------------- \n");
            var strike1 = new Tizen.NUI.Text.Strikethrough();
            var strike2 = new Tizen.NUI.Text.Strikethrough();
            var strike3 = new Tizen.NUI.Text.Strikethrough();

            strike1.Color = Color.Red;
            strike2.Color = Color.Blue;
            strike3.Color = Color.Red;

            strike1.Height = 3.0f;
            strike2.Height = 3.0f;
            strike3.Height = 5.0f;

            if (strike1 == strike2)
            {
                Tizen.Log.Error("NUI", "Strikethrough 1 == 2 \n");
            }

            if (strike1 != strike3)
            {
                Tizen.Log.Error("NUI", "Strikethrough 1 != 3 \n");
            }

            Tizen.Log.Error("NUI", "Strikethrough1 GetHashCode " + strike1.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "Strikethrough2 GetHashCode " + strike2.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "Strikethrough3 GetHashCode " + strike3.GetHashCode() + " \n");



            Tizen.Log.Error("NUI", "-------------------------------------------------- \n");
            var shadow1 = new Tizen.NUI.Text.Shadow();
            var shadow2 = new Tizen.NUI.Text.Shadow();
            var shadow3 = new Tizen.NUI.Text.Shadow();

            //shadow1.Offset = new Vector2(3, 3);
            //shadow2.Offset = new Vector2(3, 3);
            shadow3.Offset = new Vector2(3, 3);

            //shadow1.Color = Color.Red;
            //shadow2.Color = Color.Blue;
            shadow3.Color = Color.Red;

            shadow1.BlurRadius = 3.0f;
            shadow2.BlurRadius = 3.0f;
            shadow3.BlurRadius = 5.0f;

            if (shadow1 == shadow2)
            {
                Tizen.Log.Error("NUI", "Shadow 1 == 2 \n");
            }

            if (shadow1 != shadow3)
            {
                Tizen.Log.Error("NUI", "Shadow 1 != 3 \n");
            }

            Tizen.Log.Error("NUI", "Shadow1 GetHashCode " + shadow1.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "Shadow2 GetHashCode " + shadow2.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "Shadow3 GetHashCode " + shadow3.GetHashCode() + " \n");



            Tizen.Log.Error("NUI", "-------------------------------------------------- \n");
            var simage1 = new Tizen.NUI.Text.SelectionHandleImage();
            var simage2 = new Tizen.NUI.Text.SelectionHandleImage();
            var simage3 = new Tizen.NUI.Text.SelectionHandleImage();

            simage1.LeftImageUrl = "hello";
            simage2.LeftImageUrl = "hello";
            simage3.RightImageUrl = "hello";

            if (simage1 == simage2)
            {
                Tizen.Log.Error("NUI", "SelectionHandleImage 1 == 2 \n");
            }

            if (simage1 != simage3)
            {
                Tizen.Log.Error("NUI", "SelectionHandleImage 1 != 3 \n");
            }

            Tizen.Log.Error("NUI", "SelectionHandleImage1 GetHashCode " + simage1.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "SelectionHandleImage2 GetHashCode " + simage2.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "SelectionHandleImage3 GetHashCode " + simage3.GetHashCode() + " \n");


            Tizen.Log.Error("NUI", "-------------------------------------------------- \n");
            var hidden1 = new Tizen.NUI.Text.HiddenInput();
            var hidden2 = new Tizen.NUI.Text.HiddenInput();
            var hidden3 = new Tizen.NUI.Text.HiddenInput();

            hidden1.Mode = HiddenInputModeType.ShowLastCharacter;
            hidden2.Mode = HiddenInputModeType.ShowLastCharacter;
            hidden3.Mode = HiddenInputModeType.ShowLastCharacter;

            hidden1.SubstituteCharacter = 'a';
            hidden2.SubstituteCharacter = 'a';
            hidden3.SubstituteCharacter = '*';

            if (hidden1 == hidden2)
            {
                Tizen.Log.Error("NUI", "HiddenInput 1 == 2 \n");
            }

            if (hidden1 != hidden3)
            {
                Tizen.Log.Error("NUI", "HiddenInput 1 != 3 \n");
            }

            Tizen.Log.Error("NUI", "HiddenInput1 GetHashCode " + hidden1.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "HiddenInput2 GetHashCode " + hidden2.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "HiddenInput3 GetHashCode " + hidden3.GetHashCode() + " \n");



            Tizen.Log.Error("NUI", "-------------------------------------------------- \n");
            var place1 = new Tizen.NUI.Text.Placeholder();
            var place2 = new Tizen.NUI.Text.Placeholder();
            var place3 = new Tizen.NUI.Text.Placeholder();


            if (place1 == place2)
            {
                Tizen.Log.Error("NUI", "Placeholder 1 == 2 \n");
            }

            if (place1 != place3)
            {
                Tizen.Log.Error("NUI", "Placeholder 1 != 3 \n");
            }

            Tizen.Log.Error("NUI", "Placeholder1 GetHashCode " + place1.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "Placeholder2 GetHashCode " + place2.GetHashCode() + " \n");
            Tizen.Log.Error("NUI", "Placeholder3 GetHashCode " + place3.GetHashCode() + " \n");





        }


        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
