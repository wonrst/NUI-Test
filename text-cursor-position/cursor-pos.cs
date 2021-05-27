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
            TextLabel titleLabel = newTextLabel("TextField : ", 20.0f);
            titleLabel.BackgroundColor = Color.CadetBlue;
            view.Add(titleLabel);

            // For focus test
            bool isFocused = false;


            // Main TextField
            field = newTextField("Text Field Cursor Test", 25.0f);
            field.HeightSpecification = 80;
            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };
            view.Add(field);


            // Jsut divider
            View divider = new View
            {
                Size2D = new Size2D(480, 3),
                BackgroundColor = Color.CadetBlue,
            };
            view.Add(divider);


            // Selection
            TextLabel selectionLabel = newTextLabel("Selection Length : " + (int)(field.SelectedTextEnd - field.SelectedTextStart), 20.0f);
            view.Add(selectionLabel);

            // Cursor Position
            TextLabel cursorPosLabel = newTextLabel("Cursor Position : " + field.PrimaryCursorPosition, 20.0f);
            view.Add(cursorPosLabel);

            // Is Focused
            TextLabel isFocusedLabel = newTextLabel("Is Focused : " + isFocused, 20.0f);
            view.Add(isFocusedLabel);

            // Selected text label
            TextLabel selectedLabel = newTextLabel("Selected Text : " + field.SelectedText, 20.0f);
            view.Add(selectedLabel);


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


            // Start test
            View HorView = newHorView();
            view.Add(HorView);

            TextField start = newTextField("5", 20.0f);
            HorView.Add(start);

            Button startButton = newButton("Selected Start");
            startButton.Clicked += (s, e) =>
            {
                printLog(false);
                field.SelectedTextStart = Int32.Parse(start.Text);
                printLog(true);
            };
            HorView.Add(startButton);


            // End test
            View HorView2 = newHorView();
            view.Add(HorView2);

            TextField end = newTextField("10", 20.0f);
            HorView2.Add(end);

            Button endButton = newButton("Selected End");
            endButton.Clicked += (s, e) =>
            {
                printLog(false);
                field.SelectedTextEnd = Int32.Parse(end.Text);
                printLog(true);
            };
            HorView2.Add(endButton);


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
                field.SelectedTextStart = Int32.Parse(startSel.Text);
                field.SelectedTextEnd = Int32.Parse(endSel.Text);
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
                field.SelectedTextStart = Int32.Parse(sSel.Text);
                field.SelectedTextEnd = Int32.Parse(eSel.Text);
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
                field.SelectedTextStart = Int32.Parse(sSel2.Text);
                field.SelectedTextEnd = Int32.Parse(eSel2.Text);
                printLog(true);
            };
            HorView6.Add(allButton2);


            // Deselect
            Button deselectButton = newButton("Deselect");
            deselectButton.Clicked += (s, e) =>
            {
                // How?
            };
            view.Add(deselectButton);


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
                selectionLabel.Text = "Selection Length : " + (int)(field.SelectedTextEnd - field.SelectedTextStart);
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

        public TextField newTextField(string text, float size)
        {
            TextField textField = new TextField
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

                MaxLength = 50,
                PointSize = size,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
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
