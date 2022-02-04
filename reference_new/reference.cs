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

            string shortText = "Lorem ipsum dolor";
            string longText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            // Normal label
            TextLabel label = NewTextLabel(shortText);
            view.Add(label);

            // Style label
            TextLabel styleLabel = NewTextLabel(longText);
            styleLabel.Ellipsis = true;
            view.Add(styleLabel);

            var fontStyle = new Tizen.NUI.Text.FontStyle()
            {
                Width = FontWidthType.Condensed,
                Weight = FontWeightType.Light,
                Slant = FontSlantType.Italic,
            };
            styleLabel.SetFontStyle(fontStyle);


            // Markup label
            string markupText = "<b>Lorem</b> <u>ipsum dolor sit amet,</u> consectetur <span font-size='25' font-family='Ubuntu Mono' font-width='condensed' font-slant='italic' text-color='red'>adipiscing elit,</span> sed do <a href='www.hello.world'>eiusmod tempor</a> <background color='green'>incididunt ut</background> <s color='red'>labore et dolore magna aliqua.</s>";
            //string markupText = "<s color='red'><b>Lorem</b> <u>ipsum dolor sit amet,</u> consectetur <span font-size='25' font-family='Ubuntu Mono' font-width='condensed' font-slant='italic' text-color='red'>adipiscing elit,</span> sed do <a href='www.hello.world'>eiusmod tempor</a> <background color='green'>incididunt ut</background> labore et dolore magna aliqua.</s>";


            TextLabel markupLabel = NewTextLabel(markupText);
            markupLabel.MultiLine = true;
            markupLabel.EnableMarkup = true;
            view.Add(markupLabel);

            markupLabel.AnchorClicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"Label Anchor clicked[{e.Href}] \n");
            };


            // Normal field
            TextField field = NewTextField("");
            view.Add(field);

            var placeholder = new Tizen.NUI.Text.Placeholder()
            {
                Text = "Placeholder Text",
                TextFocused = "Placeholder Text Focused",
                Color = Color.Gray,
            };
            field.SetPlaceholder(placeholder);

            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"Field Text Changed[{(s as TextField).Text}] \n");
            };


            // Password field
            TextField pwdField = NewTextField("");
            view.Add(pwdField);
            pwdField.PlaceholderText = "Password";
            pwdField.PlaceholderTextFocused = "Input Password";

            var hiddenInput = new Tizen.NUI.Text.HiddenInput()
            {
                Mode = HiddenInputModeType.ShowLastCharacter,
                SubstituteCharacter = '★',
                SubstituteCount = 0,
                ShowLastCharacterDuration = 1000,
            };
            pwdField.SetHiddenInput(hiddenInput);

            var inputMethod = new InputMethod()
            {
                PanelLayout = InputMethod.PanelLayoutType.Password,
            };
            pwdField.InputMethodSettings = inputMethod.OutputMap;


            // Normal editor
            TextEditor editor = NewTextEditor(longText);
            view.Add(editor);

            editor.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"Editor Text Changed[{(s as TextEditor).Text}] \n");
            };


            // Markup Field
            TextField markupField = NewTextField(markupText);
            view.Add(markupField);
            markupField.EnableMarkup = true;

            // Markup Editor
            TextEditor markupEditor = NewTextEditor(markupText);
            view.Add(markupEditor);
            markupEditor.EnableMarkup = true;
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return label;
        }

        public TextField NewTextField(string text)
        {
            var field = new TextField
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                MaxLength = 200,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            setHandle(field);
            return field;
        }

        public TextEditor NewTextEditor(string text)
        {
            var editor = new TextEditor
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 100,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };
            setHandle(editor);
            return editor;
        }

        public void setHandle(TextField field)
        {
            field.GrabHandleImage = "images/handle_down.png";

            var selectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage();
            selectionHandleImage.LeftImageUrl = "images/handle_downleft.png";
            selectionHandleImage.RightImageUrl = "images/handle_downright.png";
            field.SetSelectionHandleImage(selectionHandleImage);
        }

        public void setHandle(TextEditor editor)
        {
            editor.GrabHandleImage = "images/handle_down.png";

            var selectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage();
            selectionHandleImage.LeftImageUrl = "images/handle_downleft.png";
            selectionHandleImage.RightImageUrl = "images/handle_downright.png";
            editor.SetSelectionHandleImage(selectionHandleImage);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
