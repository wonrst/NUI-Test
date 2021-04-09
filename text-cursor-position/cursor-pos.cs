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
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.Black,
            };

            // Label for title
            TextLabel titleLabel = new TextLabel
            {
                Text = "TextField : ",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                BackgroundColor = Color.CadetBlue,
            };
            view.Add(titleLabel);


            // Field for Test
            bool isFocused = false;;
            TextField field = new TextField
            {
                Text = "Text Field Cursor Test",
                // EnableMarkup = true,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,

                MaxLength = 50,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };

            // field.TextChanged += onTextFieldTextChanged;
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
            TextLabel selectionLabel = new TextLabel
            {
                Text = "Selection Length : " + (int)(field.SelectedTextEnd - field.SelectedTextStart),
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(selectionLabel);


            // Cursor Position
            TextLabel cursorPosLabel = new TextLabel
            {
                Text = "Cursor Position : " + field.PrimaryCursorPosition,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(cursorPosLabel);


            // Is Focused
            TextLabel isFocusedLabel = new TextLabel
            {
                Text = "Is Focused : " + isFocused,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(isFocusedLabel);

            // Selected text label
            TextLabel selectedLabel = new TextLabel
            {
                Text = "Selected Text : " + field.SelectedText,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
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


            // Select 5 characters
            Button selectButton = new Button
            {
                Text = "Select 5 characters",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };
            selectButton.Clicked += (s, e) =>
            {
                field.SelectedTextStart = 5;
                field.SelectedTextEnd = 10;
            };
            view.Add(selectButton);

            // Deselect
            Button deselectButton = new Button
            {
                Text = "Deselect",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };
            deselectButton.Clicked += (s, e) =>
            {
                // How?
            };
            view.Add(deselectButton);

            // Cursor position + 1
            Button cursorButton = new Button
            {
                Text = "Cursor position + 1",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };
            cursorButton.Clicked += (s, e) =>
            {
                field.PrimaryCursorPosition += 1;
            };
            view.Add(cursorButton);

            // Get Selected Text
            Button selectedButton = new Button
            {
                Text = "Get Selected Text",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };
            selectedButton.Clicked += (s, e) =>
            {
                selectedLabel.Text = "Selected Text : " + field.SelectedText;
            };
            view.Add(selectedButton);


            // cursor position + 1 (without focus) : Not supported yet


            // TextField for focus
            TextField focusField = new TextField
            {
                Text = "",
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,

                PlaceholderText = "Check Is Focused",
                PlaceholderTextFocused = "Check Is Focused",
            };
            view.Add(focusField);


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
