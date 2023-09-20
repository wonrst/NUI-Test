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
            view.LayoutDirection = ViewLayoutDirectionType.RTL;
            window.Add(view);


            // Normal label
            TextLabel label = new TextLabel
            {
                Text = "Lorem ipsum dolor",
                // Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                // EnableMarkup = true,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(label);
            label.InheritLayoutDirection = true;
            label.LayoutDirection = ViewLayoutDirectionType.LTR;



            // Ellipsis label
            TextLabel ellipsisLabel = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                // EnableMarkup = true,
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
            ellipsisLabel.InheritLayoutDirection = true;


            // Normal field
            TextField field = new TextField
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                PlaceholderText = "Placeholder Text",
                //PlaceholderTextColor = Color.Gray,
                PlaceholderTextFocused = "Placeholder Text Focused",

                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
                Ellipsis = true,
            };
            setHandle(field);
            field.PlaceholderTextColor = Color.Red;
            //field.Text = "";
            field.TextColor = Color.Blue;
            field.Text = "";

            // field.TextChanged += onTextFieldTextChanged;
            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };

            view.Add(field);


            // Password field
            TextField passwordField = new TextField
            {
                // Text = "Text Field",
                // EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                
                PlaceholderText = "Password",
                PlaceholderTextFocused = "Input Password",
                Ellipsis = true,
                // InputMethodSettings = (new InputMethod{PanelLayout = InputMethod.PanelLayoutType.Password}).OutputMap,
            };
            setHandle(passwordField);

            var inputMethod = new InputMethod();
            inputMethod.PanelLayout = InputMethod.PanelLayoutType.Password;
            passwordField.InputMethodSettings = inputMethod.OutputMap;

            var hiddenMap = new PropertyMap();
            hiddenMap.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.ShowLastCharacter));
            hiddenMap.Add(HiddenInputProperty.ShowLastCharacterDuration, new PropertyValue(500));
            passwordField.HiddenInputSettings = hiddenMap;

            view.Add(passwordField);


            // Need to implement layout editor
            /*
            TextEditor editor = new TextEditor
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                // Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                EnableMarkup = true,
                WidthSpecification = 100,
                //WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,   // there is no VerticalAlignment in TextEditor
            };
            setHandle(editor);

            // FIXME
            float height = editor.GetHeightForWidth(480);
            editor.Size2D = new Size2D(480, (int)height);

            // editor.TextChanged += onTextEditorTextChanged;
            editor.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor Text Changed[" + e.TextEditor.Text + "] \n");
            };

            view.Add(editor);*/
        }

        public void onTextFieldTextChanged(object sender, TextField.TextChangedEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "Field Text Changed : " + e.TextField.Text + "\n");
        }

        public void onTextEditorTextChanged(object sender, TextEditor.TextChangedEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "Editor Text Changed : " + e.TextEditor.Text + "\n");
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
