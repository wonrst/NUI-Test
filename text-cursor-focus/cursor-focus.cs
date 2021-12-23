using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace TextComponentsTest
{
    class Example : NUIApplication
    {
        public TextField field;
        public TextField field2;
        public TextField field3;
        public TextField field4;
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

            // Label for title
            TextLabel titleLabel = newTextLabel("TextField : ", 15.0f);
            titleLabel.BackgroundColor = Color.CadetBlue;
            view.Add(titleLabel);


            // Main TextField
            field = newTextField("Text Field Cursor Test This is long long text content because I need very long text.. scrollable text components", 20.0f);
            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };
            field.PrimaryCursorPosition = 999;
            view.Add(field);
            field.FocusGained += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field 1 FOCUS GAINED \n");
            };
            field.FocusLost += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field 1 FOCUS LOST \n");
            };

            // TODO: Set Selection Range at OnInitialize
            // field.SelectedTextStart = 3;
            // field.SelectedTextEnd = 12;


            field2 = newTextField("Text Field Cursor Test This is long long text content because I need very long text.. scrollable text components", 20.0f);
            field2.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };
            //field2.PrimaryCursorPosition = 0;
            view.Add(field2);            
            field2.FocusGained += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field 2 FOCUS GAINED \n");
            };
            field2.FocusLost += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field 2 FOCUS LOST \n");
            };


            field3 = newTextField("Text Field Cursor Test This is long long text content because I need very long text.. scrollable text components", 20.0f);
            field3.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };
            //field3.PrimaryCursorPosition = 0;
            view.Add(field3);            
            field3.FocusGained += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field 3 FOCUS GAINED \n");
            };
            field3.FocusLost += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field 3 FOCUS LOST \n");
            };


            field4 = newTextField("Text Field Cursor Test This is long long text content because I need very long text.. scrollable text components", 20.0f);
            field4.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };
            //field4.PrimaryCursorPosition = 0;
            view.Add(field4);
            field4.FocusGained += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field 4 FOCUS GAINED \n");
            };
            field4.FocusLost += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field 4 FOCUS LOST \n");
            };


            button = newButton("set/get cursor pos 5");
            button.Clicked += (s, e) =>
            {
                field.PrimaryCursorPosition = 5;
                Tizen.Log.Error("NUI", "field 1 cursor pos [" + field.PrimaryCursorPosition + "] \n");
            };
            view.Add(button);


            button2 = newButton("get cursor pos");
            button2.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "field 1 cursor pos [" + field.PrimaryCursorPosition + "] \n");
            };
            view.Add(button2);


            button3 = newButton("set pos ALL 3");
            button3.Clicked += (s, e) =>
            {
                field.PrimaryCursorPosition = 300;
                field2.PrimaryCursorPosition = 30;
                field3.PrimaryCursorPosition = 300;
                field4.PrimaryCursorPosition = 30;

                Tizen.Log.Error("NUI", "field 1 cursor pos [" + field.PrimaryCursorPosition + "] \n");
                Tizen.Log.Error("NUI", "field 2 cursor pos [" + field2.PrimaryCursorPosition + "] \n");
                Tizen.Log.Error("NUI", "field 3 cursor pos [" + field3.PrimaryCursorPosition + "] \n");
                Tizen.Log.Error("NUI", "field 4 cursor pos [" + field4.PrimaryCursorPosition + "] \n\n");
            };
            view.Add(button3);


            button4 = newButton("get pos ALL");
            button4.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "field 1 cursor pos [" + field.PrimaryCursorPosition + "] \n");
                Tizen.Log.Error("NUI", "field 2 cursor pos [" + field2.PrimaryCursorPosition + "] \n");
                Tizen.Log.Error("NUI", "field 3 cursor pos [" + field3.PrimaryCursorPosition + "] \n");
                Tizen.Log.Error("NUI", "field 4 cursor pos [" + field4.PrimaryCursorPosition + "] \n\n");
            };
            view.Add(button4);


            button5 = newButton("focusable true");
            button5.Clicked += (s, e) =>
            {
                button.Focusable = true;
                button.FocusableInTouch = true;

                button2.Focusable = true;
                button2.FocusableInTouch = true;

                button3.Focusable = true;
                button3.FocusableInTouch = true;

                button4.Focusable = true;
                button4.FocusableInTouch = true;

                button5.Focusable = true;
                button5.FocusableInTouch = true;

                button6.Focusable = true;
                button6.FocusableInTouch = true;
            };
            view.Add(button5);


            button6 = newButton("focusable false");
            button6.Clicked += (s, e) =>
            {
                button.Focusable = false;
                button.FocusableInTouch = false;

                button2.Focusable = false;
                button2.FocusableInTouch = false;

                button3.Focusable = false;
                button3.FocusableInTouch = false;

                button4.Focusable = false;
                button4.FocusableInTouch = false;

                button5.Focusable = false;
                button5.FocusableInTouch = false;

                button6.Focusable = false;
                button6.FocusableInTouch = false;
            };
            view.Add(button6);


        }

        public void printLog(bool after)
        {
            if (after)
                Tizen.Log.Fatal("NUI", "after cur[" + field.PrimaryCursorPosition + "] start[" + field.SelectedTextStart + "] end[" + field.SelectedTextEnd + "] \n");
            else
                Tizen.Log.Fatal("NUI", "before cur[" + field.PrimaryCursorPosition + "] start[" + field.SelectedTextStart + "] end[" + field.SelectedTextEnd + "] \n");
        }

        public Button newButton(string text)
        {
            Button button = new Button
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                Focusable = true,
                FocusableInTouch = true,
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

        public TextField newTextField(string text, float size)
        {
            TextField textField = new TextField
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,

                MaxLength = 500,
                PointSize = size,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,

                Focusable = true,
                FocusableInTouch = true,
            };
            setHandle(textField);

            return textField;
        }

        public TextLabel newTextLabel(string text, float size)
        {
            TextLabel textLabel = new TextLabel
            {                
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = size,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            return textLabel;
        }

        public View newHorView()
        {
            View view = new View
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 40,
                BackgroundColor = Color.Black,
            };
            return view;
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
