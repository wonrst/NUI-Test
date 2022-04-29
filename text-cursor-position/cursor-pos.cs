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

            // Label for title
            TextLabel titleLabel = newTextLabel("TextField : ", 15.0f);
            titleLabel.BackgroundColor = Color.CadetBlue;
            view.Add(titleLabel);

            // For focus test
            bool isFocused = false;


            // Main TextField
            field = newTextField("Text Field Cursor Test This is long long text content because I need very long text.. scrollable text components", 25.0f);
            field.Text = "Text Field Cursor Test";
            field.HeightSpecification = 80;
            field.HorizontalAlignment = HorizontalAlignment.Center;
            //field.EnableSelection = false;
            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };
            view.Add(field);

            // TODO: Set Selection Range at OnInitialize
            // field.SelectedTextStart = 3;
            // field.SelectedTextEnd = 12;

            // Just divider
            View divider = new View
            {
                Size2D = new Size2D(480, 3),
                BackgroundColor = Color.CadetBlue,
            };
            view.Add(divider);


            // Selection
            TextLabel selectionLabel = newTextLabel("Selection Length : " + field.SelectedText.Length, 15.0f);
            view.Add(selectionLabel);

            // Cursor Position
            TextLabel cursorPosLabel = newTextLabel("Cursor Position : " + field.PrimaryCursorPosition, 15.0f);
            view.Add(cursorPosLabel);

            // Is Focused
            TextLabel isFocusedLabel = newTextLabel("Is Focused : " + isFocused, 15.0f);
            view.Add(isFocusedLabel);

            // Selected text label
            TextLabel selectedLabel = newTextLabel("Selected Text : " + field.SelectedText, 15.0f);
            view.Add(selectedLabel);


            field.CursorPositionChanged += (s, e) =>
            {
                cursorPosLabel.Text = "Cursor Position : " + field.PrimaryCursorPosition;

                Tizen.Log.Error("NUI", "CursorPositionChanged \n");
                printLog(true);
            };

            field.SelectionChanged += (s, e) =>
            {
                selectionLabel.Text = "Selection Length : " + field.SelectedText.Length;
                cursorPosLabel.Text = "Cursor Position : " + field.PrimaryCursorPosition;
                selectedLabel.Text = "Selected Text : " + field.SelectedText + " [" + field.SelectedTextStart + ", " + field.SelectedTextEnd + "]";

                Tizen.Log.Error("NUI", "SelectionChanged \n");
                printLog(true);
            };

            field.SelectionCleared += (s, e) =>
            {
                selectionLabel.Text = "Selection Length : " + field.SelectedText.Length;
                cursorPosLabel.Text = "Cursor Position : " + field.PrimaryCursorPosition;
                selectedLabel.Text = "Selected Text : " + field.SelectedText + " [" + field.SelectedTextStart + ", " + field.SelectedTextEnd + "]";

                Tizen.Log.Error("NUI", "SelectionCleared \n");
                printLog(true);
            };

            // Focus callback of main field
            field.FocusGained += (s, e) =>
            {
                isFocused = true;
                isFocusedLabel.Text = "Is Focused : " + isFocused;
            };

            field.FocusLost += (s, e) =>
            {
                isFocused = false;
                isFocusedLabel.Text = "Is Focused : " + isFocused;
            };


            // Select Range test
            View HorView3 = newHorView();
            view.Add(HorView3);

            TextField startSel = newTextField("10", 20.0f);
            HorView3.Add(startSel);

            TextField endSel = newTextField("15", 20.0f);
            HorView3.Add(endSel);

            Button selButton = newButton("Selected");
            selButton.Clicked += (s, e) =>
            {
                printLog(false);
                field.SelectText(Int32.Parse(startSel.Text), Int32.Parse(endSel.Text));
                printLog(true);
            };
            HorView3.Add(selButton);


            // Cursor test
            View HorView4 = newHorView();
            view.Add(HorView4);

            TextField cursor = newTextField("3", 20.0f);
            HorView4.Add(cursor);

            Button curButton = newButton("Cursor");
            curButton.Clicked += (s, e) =>
            {
                printLog(false);
                field.PrimaryCursorPosition = Int32.Parse(cursor.Text);
                printLog(true);
            };
            HorView4.Add(curButton);


            // All test, cursor, start, end
            View HorView5 = newHorView();
            view.Add(HorView5);

            TextField cSel = newTextField("5", 20.0f);
            HorView5.Add(cSel);

            TextField sSel = newTextField("10", 20.0f);
            HorView5.Add(sSel);

            TextField eSel = newTextField("15", 20.0f);
            HorView5.Add(eSel);

            Button allButton = newButton("All");
            allButton.Clicked += (s, e) =>
            {
                printLog(false);
                field.PrimaryCursorPosition = Int32.Parse(cSel.Text);
                field.SelectText(Int32.Parse(sSel.Text), Int32.Parse(eSel.Text));
                printLog(true);
            };
            HorView5.Add(allButton);


            // All test 2 for compare with All test 1
            View HorView6 = newHorView();
            view.Add(HorView6);

            TextField cSel2 = newTextField("6", 20.0f);
            HorView6.Add(cSel2);

            TextField sSel2 = newTextField("15", 20.0f);
            HorView6.Add(sSel2);

            TextField eSel2 = newTextField("20", 20.0f);
            HorView6.Add(eSel2);

            Button allButton2 = newButton("All 2");
            allButton2.Clicked += (s, e) =>
            {
                printLog(false);
                field.PrimaryCursorPosition = Int32.Parse(cSel2.Text);
                field.SelectText(Int32.Parse(sSel2.Text), Int32.Parse(eSel2.Text));
                printLog(true);
            };
            HorView6.Add(allButton2);


            // Whole Select
            Button wholeSelectButton = newButton("Select Whole");
            wholeSelectButton.Clicked += (s, e) =>
            {
                field.SelectWholeText();
            };
            view.Add(wholeSelectButton);


            // Deselect
            Button noneSelectButton = newButton("Select None");
            noneSelectButton.Clicked += (s, e) =>
            {
                field.SelectNone();
            };
            view.Add(noneSelectButton);


            // Cursor position + 1
            Button cursorButton = newButton("Cursor position + 1");
            cursorButton.Clicked += (s, e) =>
            {
                field.PrimaryCursorPosition += 1;
            };
            view.Add(cursorButton);


            // Get Selected Text
            Button selectedButton = newButton("Get Data");
            selectedButton.Clicked += (s, e) =>
            {                
                selectionLabel.Text = "Selection Length : " + field.SelectedText.Length;
                cursorPosLabel.Text = "Cursor Position : " + field.PrimaryCursorPosition;
                isFocusedLabel.Text = "Is Focused : " + isFocused;
                selectedLabel.Text = "Selected Text : " + field.SelectedText;
            };
            view.Add(selectedButton);


            // cursor position + 1 (without focus) : Not supported yet


            // TextField for focus
            TextField focusField = newTextField("", 20.0f);
            focusField.PlaceholderText = "Check Is Focused";
            focusField.PlaceholderTextFocused = "Check Is Focused";
            view.Add(focusField);

            window.Add(view);
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
                HeightSpecification = LayoutParamPolicies.MatchParent,

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
