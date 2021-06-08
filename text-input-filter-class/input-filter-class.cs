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
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
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


            InputFilter inputFilter = new InputFilter();
            //inputFilter.Accepted = new Regex("[\\d]");
            inputFilter.Rejected = new Regex("[\\d]");

            field.InputFilter = inputFilter.OutputMap;

            field.InputFiltered += OnTextFieldInputFiltered;


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


            Button nullBtn = new Button
            {
                Text = "InputFilter NULL",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(nullBtn);
            nullBtn.Clicked += (s, e) =>
            {
                field.InputFilter = null;
                /*
                InputFilter inputFilter = new InputFilter();
                inputFilter.Accepted = null;
                inputFilter.Rejected = null;
                field.InputFilter = inputFilter.OutputMap;
                */
            };


            Button rejBtn = new Button
            {
                Text = "Rejected NULL",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(rejBtn);
            rejBtn.Clicked += (s, e) =>
            {
                InputFilter inputFilter = new InputFilter();
                inputFilter.Accepted = new Regex("[\\w]");
                //inputFilter.Rejected = null;
                field.InputFilter = inputFilter.OutputMap;
            };
        }

        public void OnTextFieldInputFiltered(object sender, InputFilteredEventArgs e)
        {
            TextField field = sender as TextField;
            InputFilter inputFilter = new InputFilter();
            inputFilter.InputMap = field.InputFilter;

            if (e.Type == InputFilter.Type.Accepted)
            {
                Tizen.Log.Fatal("NUI", "[FIELD][Accepted] Only accepted follow characters " + inputFilter.Accepted + "\n");
            }
            else if (e.Type == InputFilter.Type.Rejected)
            {
                Tizen.Log.Fatal("NUI", "[FIELD][Rejected] Rejected follow characters " + inputFilter.Rejected + "\n");
            }

            Tizen.Log.Fatal("NUI", "[FIELD][Accepted] test " + inputFilter.Accepted + "\n");
            Tizen.Log.Fatal("NUI", "[FIELD][Rejected] test " + inputFilter.Rejected + "\n");
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
