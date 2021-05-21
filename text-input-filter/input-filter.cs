using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Text.RegularExpressions;

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
            window.Add(view);

            // Normal field
            TextField field = new TextField
            {
                Text = "Field",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 80,

                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(field);

            field.TextChanged += OnTextFieldTextChanged;

            PropertyMap inputFilter = new PropertyMap();
            inputFilter.Add((int)InputFilterType.Accepted, new PropertyValue("[\\d]"));
            inputFilter.Add((int)InputFilterType.Rejected, new PropertyValue("[0-3]"));
            // inputFilter.Add("accepted", new PropertyValue("[\\d]"));
            // inputFilter.Add("rejected", new PropertyValue("[\\d]"));

            field.InputFilter = inputFilter;

            field.InputFiltered += OnTextFieldInputFiltered;

/*
            field.InputFiltered += (s, e) =>
            {
                Tizen.Log.Fatal("NUI", "Field Input Filtered! \n");
            };
*/


            // Normal editor
            TextEditor editor = new TextEditor
            {
                Text = "Editor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 80,

                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(editor);

            editor.TextChanged += OnTextEditorTextChanged;

            PropertyMap inputFilter2 = new PropertyMap();
            inputFilter2.Insert((int)InputFilterType.Accepted, new PropertyValue("[\\D]"));
            inputFilter2.Insert((int)InputFilterType.Rejected, new PropertyValue("[a-gA-G]"));

            editor.InputFilter = inputFilter2;

            editor.InputFiltered += OnTextEditorInputFiltered;


            TextLabel label = new TextLabel
            {
                Text = " ▼ Predefined Filter Test",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 30,
                PointSize = 15.0f,
                BackgroundColor = Color.Gray,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(label);


            Button digitBtn = new Button
            {
                Text = "Digit only",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(digitBtn);
            digitBtn.Clicked += (s, e) =>
            {
                var inputFilter = new PropertyMap();
                inputFilter.Add((int)InputFilterType.Accepted, new PropertyValue(@"[\d]"));
                inputFilter.Add((int)InputFilterType.Rejected, new PropertyValue(""));
                field.InputFilter = inputFilter;
                editor.InputFilter = inputFilter;
            };


            Button wordBtn = new Button
            {
                Text = "Word only",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(wordBtn);
            wordBtn.Clicked += (s, e) =>
            {
                var inputFilter = new PropertyMap();
                inputFilter.Add((int)InputFilterType.Accepted, new PropertyValue(@"[\w]"));
                inputFilter.Add((int)InputFilterType.Rejected, new PropertyValue(""));
                field.InputFilter = inputFilter;
                editor.InputFilter = inputFilter;
            };

            // Need to implenments NULL situation
            Button nofilterBtn = new Button
            {
                Text = "No Filter",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(nofilterBtn);
            nofilterBtn.Clicked += (s, e) =>
            {
                field.InputFilter = null;
                editor.InputFilter = null;
            };


            TextLabel label2 = new TextLabel
            {
                Text = " ▼ Regular Expression Test",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 30,
                PointSize = 15.0f,
                BackgroundColor = Color.Gray,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(label2);


            View horView = new View
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            view.Add(horView);


            TextField acceptedField = new TextField
            {
                Text = "",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                PlaceholderText = "Input Accepted REGEX",
                PlaceholderTextFocused = "Input Accepted REGEX",
                PlaceholderTextColor = Color.White,
                PointSize = 15.0f,

                BackgroundColor = Color.LightGray,
                VerticalAlignment = VerticalAlignment.Center,
            };
            horView.Add(acceptedField);


            TextField rejectedField = new TextField
            {
                Text = "",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                PlaceholderText = "Input Rejected REGEX",
                PlaceholderTextFocused = "Input Rejected REGEX",
                PlaceholderTextColor = Color.White,
                PointSize = 15.0f,

                BackgroundColor = Color.LightGray,
                VerticalAlignment = VerticalAlignment.Center,
            };
            horView.Add(rejectedField);


            Button setBtn = new Button
            {
                Text = "Set InputFilter by REGEX",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(setBtn);
            setBtn.Clicked += (s, e) =>
            {
                var inputFilter = new PropertyMap();
                inputFilter.Add((int)InputFilterType.Accepted, new PropertyValue(acceptedField.Text));
                inputFilter.Add((int)InputFilterType.Rejected, new PropertyValue(rejectedField.Text));
                field.InputFilter = inputFilter;
                editor.InputFilter = inputFilter;
            };


        }

        public void OnTextFieldInputFiltered(object sender, InputFilteredEventArgs e)
        {
            TextField field = sender as TextField;
            string regex;
            if (e.Type == InputFilterType.Accepted)
            {
                field.InputFilter.Find((int)InputFilterType.Accepted).Get(out regex);

                Tizen.Log.Fatal("NUI", "[FIELD][Accepted] Only accepted follow characters " + regex + "\n");
            }
            else if (e.Type == InputFilterType.Rejected)
            {
                field.InputFilter.Find((int)InputFilterType.Rejected).Get(out regex);

                Tizen.Log.Fatal("NUI", "[FIELD][Rejected] Rejected follow characters " + regex + "\n");
            }
        }

        public void OnTextEditorInputFiltered(object sender, InputFilteredEventArgs e)
        {
            TextEditor editor = sender as TextEditor;
            string regex;
            if (e.Type == InputFilterType.Accepted)
            {
                editor.InputFilter.Find((int)InputFilterType.Accepted).Get(out regex);

                Tizen.Log.Fatal("NUI", "[EDITOR][Accepted] Only accepted follow characters " + regex + "\n");
            }
            else if (e.Type == InputFilterType.Rejected)
            {
                editor.InputFilter.Find((int)InputFilterType.Rejected).Get(out regex);

                Tizen.Log.Fatal("NUI", "[EDITOR][Rejected] Rejected follow characters " + regex + "\n");
            }
        }

        public void OnTextFieldTextChanged(object sender, TextField.TextChangedEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "[FIELD] Text Changed : " + e.TextField.Text + "\n");
        }

        public void OnTextEditorTextChanged(object sender, TextEditor.TextChangedEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "[EDITOR] Text Changed : " + e.TextEditor.Text + "\n");
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
