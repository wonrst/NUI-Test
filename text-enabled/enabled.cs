using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace TextComponentsTest
{
    class Example : NUIApplication
    {
        public TextLabel label;
        public TextField field;
        public TextEditor editor;
        public Button button;
        public Button button2;
        public Button button3;
        public Button button4;
        public Button button5;
        public Button button6;

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

            FocusManager.Instance.EnableDefaultAlgorithm(true);

            string coloredText = "<span font-size='45' font-family='Ubuntu Mono' font-width='condensed' font-slant='italic' text-color='0x55FF0000'>Text Field Cursor</span> Test This is <color value='yellow'>long long text</color> content <color value='#7700FF00'>because I need very long text..</color> scrollable <color value='#FF0000FF'>text components</color>";
            string normalText = "Hello";
            string mixSpanText = "<span char-space-value='15.0f' background-color='#ABABAB' s-color='blue' s-height='3' font-size='10' font-family='Ubuntu Mono' font-width='condensed' u-color='green' u-height='2' font-slant='italic' text-color='red'>Lorem ipsum dolor sit amet, consectetur adipiscing</span> elit, sed do <span font-size='15' font-family='Dejavu Sans' font-width='light' text-color='blue' u-color='blue' background-color='red' char-space-value='-5.0f'>eiusmod tempor incididunt ut labore</span> et dolore magna aliqua.";



            label = newTextLabel(mixSpanText, 20.0f);
            view.Add(label);
            label.Focusable = true;


            field = newTextField(mixSpanText, 20.0f);
            view.Add(field);


            editor = newTextEditor(mixSpanText, 20.0f);
            view.Add(editor);


            button = newButton("enable");
            button.Clicked += (s, e) =>
            {
                label.IsEnabled = true;
                field.IsEnabled = true;
                editor.IsEnabled = true;
            };
            view.Add(button);


            button2 = newButton("disable");
            button2.Clicked += (s, e) =>
            {
                label.IsEnabled = false;
                field.IsEnabled = false;
                editor.IsEnabled = false;
            };
            view.Add(button2);


            button3 = newButton("--");
            button3.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "label text color [" + label.TextColor.A + "] \n");
                Tizen.Log.Error("NUI", "field text color [" + field.TextColor.A + "] \n");
                Tizen.Log.Error("NUI", "editor text color [" + editor.TextColor.A + "] \n");

                Tizen.Log.Error("NUI", "label opacity [" + label.Opacity + "] \n");
                Tizen.Log.Error("NUI", "field opacity [" + field.Opacity + "] \n");
                Tizen.Log.Error("NUI", "editor opacity [" + editor.Opacity + "] \n");
            };
            view.Add(button3);


            button4 = newButton("editing true");
            button4.Clicked += (s, e) =>
            {
                field.EnableEditing = true;
                editor.EnableEditing = true;
            };
            view.Add(button4);


            button5 = newButton("editing false");
            button5.Clicked += (s, e) =>
            {
                field.EnableEditing = false;
                editor.EnableEditing = false;
            };
            view.Add(button5);


            button6 = newButton("get color");
            button6.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "field 1 text color [" + field.TextColor.A + "] \n");
                Tizen.Log.Error("NUI", "editor 1 text color [" + editor.TextColor.A + "] \n");
            };
            view.Add(button6);


        }

        public Button newButton(string text)
        {
            Button button = new Button
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                Focusable = true,
            };
            button.TextLabel.PointSize = 15.0f;
            return button;
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

        public TextField newTextField(string text, float size)
        {
            TextField textField = new TextField
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 150,
                EnableMarkup = true,

                MaxLength = 500,
                PointSize = size,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,

                PlaceholderText = "Placeholder",
                PlaceholderTextFocused = "Placeholder Focused",
            };
            setHandle(textField);

            textField.FocusGained += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field FOCUS GAINED editing [" + textField.EnableEditing + "] IsEnabled[" + textField.IsEnabled + "] \n");
            };
            textField.FocusLost += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field FOCUS LOST \n");
            };
            textField.SelectionCleared += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field SelectionCleared! \n");
            };

            return textField;
        }

        public TextEditor newTextEditor(string text, float size)
        {
            TextEditor textEditor = new TextEditor
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 150,
                EnableMarkup = true,

                PointSize = size,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,

                PlaceholderText = "Placeholder",

                IsEnabled = false,
            };
            setHandle(textEditor);

            textEditor.FocusGained += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor FOCUS GAINED editing [" + textEditor.EnableEditing + "] IsEnabled[" + textEditor.IsEnabled + "] \n");
            };
            textEditor.FocusLost += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor FOCUS LOST \n");
            };
            textEditor.SelectionCleared += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor SelectionCleared! \n");
            };

            return textEditor;
        }

        public TextLabel newTextLabel(string text, float size)
        {
            TextLabel textLabel = new TextLabel
            {                
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 150,
                EnableMarkup = true,
                MultiLine = true,

                PointSize = size,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };

            textLabel.FocusGained += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Label FOCUS GAINED IsEnabled[" + textLabel.IsEnabled + "] \n");
            };
            textLabel.FocusLost += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Label FOCUS LOST \n");
            };

            return textLabel;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
