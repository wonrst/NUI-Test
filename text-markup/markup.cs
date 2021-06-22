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


            // Normal label
            TextLabel label = new TextLabel
            {
                Text = "<span font-size='45' font-family='Ubuntu Mono' font-width='condensed' font-slant='italic' text-color='red'>Lorem ipsum dolor</background> <u>sit amet,</u> consectetur adipiscing</span> <u>elit, <u>sed do <span font-size='15' font-family='Dejavu Sans' font-width='light' text-color='blue'>eiusmod tempor</u> incididunt ut labore</u></span> et dolore magna aliqua.",
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
/*
            PropertyMap map = new PropertyMap();
            map.Add("enable", new PropertyValue("true"));
            map.Add("color", new PropertyValue(Color.Green));
            map.Add("height", new PropertyValue(3.0f));
            label.Underline = map;
*/

            // Ellipsis label
            TextLabel ellipsisLabel = new TextLabel
            {
                Text = "<span font-size='15' font-family='Ubuntu Mono' font-width='condensed' font-slant='italic' text-color='red'><background color='yellow'><u>Lorem ipsum dolor sit amet,</u></background></span> consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                EnableMarkup = true,
                MultiLine = false,
                Ellipsis = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(ellipsisLabel);


            // Normal field
            TextField field = new TextField
            {
                Text = "<span font-size='15' font-family='Ubuntu Mono' font-width='condensed' font-slant='italic' text-color='red'><background color=blue>Lorem</span> ipsum dolor sit amet,</background> <u>Underline text filed</u>",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = 100,

                PointSize = 40.0f,
                BackgroundColor = Color.White,
/*
                PlaceholderText = "Placeholder Text",
                PlaceholderTextColor = Color.Gray,
                PlaceholderTextFocused = "Placeholder Text Focused",
*/
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Top,   // only single line
            };

            PropertyMap map = new PropertyMap();
            map.Add("text", new PropertyValue("Placeholder Text"));
            map.Add("textFocused", new PropertyValue("Placeholder Text Focused"));
            map.Add("pointSize", new PropertyValue(30.0f));
            field.Placeholder = map;




/*
            PropertyMap underline = new PropertyMap();
            underline.Add("enable", new PropertyValue("true"));
            underline.Add("color", new PropertyValue(Color.Green));
            underline.Add("height", new PropertyValue(2.0f));
            field.Underline = underline;
*/
            // field.TextChanged += onTextFieldTextChanged;
            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };

            view.Add(field);

//field.Text = "<background color=blue>Lorem ipsum dolor sit amet,</background> <u>Underline text filed</u>";

            // Password field
            TextField passwordField = new TextField
            {
                // Text = "Text Field",
                // EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 100,

                MaxLength = 20,
                PointSize = 15.0f,
                BackgroundColor = Color.White,

                VerticalAlignment = VerticalAlignment.Bottom,
                
                //PlaceholderText = "Password",
                //PlaceholderTextFocused = "Input Password",
                // InputMethodSettings = (new InputMethod{PanelLayout = InputMethod.PanelLayoutType.Password}).OutputMap,
            };
            passwordField.Placeholder = map;

            var inputMethod = new InputMethod();
            inputMethod.PanelLayout = InputMethod.PanelLayoutType.Password;
            passwordField.InputMethodSettings = inputMethod.OutputMap;

            var hiddenMap = new PropertyMap();
            hiddenMap.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.ShowLastCharacter));
            hiddenMap.Add(HiddenInputProperty.ShowLastCharacterDuration, new PropertyValue(500));
            passwordField.HiddenInputSettings = hiddenMap;

            view.Add(passwordField);


            // Need to implement layout editor
            TextEditor editor = new TextEditor
            {
                Text = "<span font-size='15' font-family='Ubuntu Mono' font-width='condensed' font-slant='italic' text-color='red'><background color='red'>Lorem ipsum dolor sit amet,</background></span> <u>consectetur adipiscing elit, sed do eiusmod tempor</u> <span font-size='15' font-family='Ubuntu Mono' font-width='condensed' font-slant='italic' text-color='red'>incididunt ut labore et dolore <u>magna</u> aliqua.</span>",
                // Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,   // there is no VerticalAlignment in TextEditor
            };
            //editor.Underline = map;

            // FIXME
            float height = editor.GetHeightForWidth(480);
            editor.Size2D = new Size2D(480, (int)height);

            // editor.TextChanged += onTextEditorTextChanged;
            editor.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor Text Changed[" + e.TextEditor.Text + "] \n");
            };

            view.Add(editor);


            window.Add(view);
        }

        public void onTextFieldTextChanged(object sender, TextField.TextChangedEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "Field Text Changed : " + e.TextField.Text + "\n");
        }

        public void onTextEditorTextChanged(object sender, TextEditor.TextChangedEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "Editor Text Changed : " + e.TextEditor.Text + "\n");
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
