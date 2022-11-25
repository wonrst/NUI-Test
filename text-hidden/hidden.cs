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
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);



            var hiddenInput = new Tizen.NUI.Text.HiddenInput();
            hiddenInput.Mode = HiddenInputModeType.ShowLastCharacter;

            TextField field = NewTextField("");
            view.Add(field);

            TextField field1 = NewTextField("");
            view.Add(field1);
            field1.SetHiddenInput(NewHiddenInput());

            TextField field2 = NewTextField("placeholder text");
            view.Add(field2);
            field2.SetHiddenInput(NewHiddenInput());

            TextField field3 = NewTextField("");
            view.Add(field3);
            field3.SetHiddenInput(NewHiddenInput());
            field3.SetPlaceholder(NewPlaceholder());

            TextField field4 = NewTextField("HideNone");
            view.Add(field4);
            field4.SetHiddenInput(new Tizen.NUI.Text.HiddenInput()
            {
                Mode = HiddenInputModeType.HideNone,
            });

            TextField field5 = NewTextField("HideAll");
            view.Add(field5);
            field5.SetHiddenInput(new Tizen.NUI.Text.HiddenInput()
            {
                Mode = HiddenInputModeType.HideAll,
            });

            TextField field6 = NewTextField("HideCount 5");
            view.Add(field6);
            field6.SetHiddenInput(new Tizen.NUI.Text.HiddenInput()
            {
                Mode = HiddenInputModeType.HideCount,
                SubstituteCount = 5,
            });

            TextField field7= NewTextField("ShowCount 5");
            view.Add(field7);
            field7.SetHiddenInput(new Tizen.NUI.Text.HiddenInput()
            {
                Mode = HiddenInputModeType.ShowCount,
                SubstituteCount = 5,
            });

        }

        public TextField NewTextField(string placeholderText)
        {
            TextField field = new TextField
            {
                PlaceholderText = placeholderText,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };
            return field;
        }

        public Tizen.NUI.Text.Placeholder NewPlaceholder()
        {
            var placeholder = new Tizen.NUI.Text.Placeholder();
            placeholder.Text = "placeholder text";
            placeholder.TextFocused = "placeholder TextFocused";
            placeholder.Color = new Color("#45B39D");
            placeholder.FontFamily = "BreezeSans";
            placeholder.FontStyle = new Tizen.NUI.Text.FontStyle()
            {
                Width = FontWidthType.Expanded,
                Weight = FontWeightType.ExtraLight,
                Slant = FontSlantType.Italic,
            };
            placeholder.PointSize = 15.0f;
            placeholder.Ellipsis = true;

            return placeholder;
        }

        public Tizen.NUI.Text.HiddenInput NewHiddenInput()
        {
            var hiddenInput = new Tizen.NUI.Text.HiddenInput();
            hiddenInput.Mode = HiddenInputModeType.ShowLastCharacter;
            return hiddenInput;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
