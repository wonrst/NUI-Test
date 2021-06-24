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
        public bool focus_1;
        public bool focus_2;
        public bool focus_3;
        public bool focus_4;
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
            field.PrimaryCursorPosition = 0;
            view.Add(field);
            field.FocusGained += (s, e) =>
            {
                focus_1 = true;
            };
            field.FocusLost += (s, e) =>
            {
                focus_1 = false;
            };

            // TODO: Set Selection Range at OnInitialize
            // field.SelectedTextStart = 3;
            // field.SelectedTextEnd = 12;


            field2 = newTextField("Text Field Cursor Test This is long long text content because I need very long text.. scrollable text components", 20.0f);
            field2.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };
            field2.PrimaryCursorPosition = 0;
            view.Add(field2);            
            field2.FocusGained += (s, e) =>
            {
                focus_2 = true;
            };
            field2.FocusLost += (s, e) =>
            {
                focus_2 = false;
            };


            field3 = newTextField("Text Field Cursor Test This is long long text content because I need very long text.. scrollable text components", 20.0f);
            field3.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };
            field3.PrimaryCursorPosition = 0;
            view.Add(field3);            
            field3.FocusGained += (s, e) =>
            {
                focus_3 = true;
            };
            field3.FocusLost += (s, e) =>
            {
                focus_3 = false;
            };


            field4 = newTextField("Text Field Cursor Test This is long long text content because I need very long text.. scrollable text components", 20.0f);
            field4.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };
            field4.PrimaryCursorPosition = 0;
            view.Add(field4);
            field4.FocusGained += (s, e) =>
            {
                focus_4 = true;
            };
            field4.FocusLost += (s, e) =>
            {
                focus_4 = false;
            };


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
                HeightSpecification = LayoutParamPolicies.MatchParent,
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
