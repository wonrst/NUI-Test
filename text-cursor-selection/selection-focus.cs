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
        public Button button7;
        public int index;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
            index = 0;
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

            //field.SelectedTextStart = 2;
            //field.SelectedTextEnd = 12;

            //field.SelectWholeText();

            view.Add(field);
            
            //field.SelectWholeText();

            field.SelectText(100, 1);


            field.FocusGained += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field 1 FOCUS GAINED \n");
            };
            field.FocusLost += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field 1 FOCUS LOST \n");
            };

            // TODO: Set Selection Range at OnInitialize
            //field.SelectedTextStart = 3;
            //field.SelectedTextEnd = 12;


            field2 = newTextField("Text Field Cursor Test This is long long text content because I need very long text.. scrollable text components", 20.0f);
            field2.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };

            //field2.SelectWholeText();

            view.Add(field2);

            //field2.SelectWholeText();

            //field2.SelectedTextStart = 3;
            //field2.SelectedTextEnd = 12;

            field2.SelectText(10, 2);

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

            //field3.SelectedTextStart = 5;
            //field3.SelectedTextEnd = 10;

            view.Add(field3);

            //field3.SelectWholeText();

            //field3.SelectedTextStart = 3;
            //field3.SelectedTextEnd = 12;

            field3.SelectText(3, 12);

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

            //field4.SelectedTextStart = 5;
            //field4.SelectedTextEnd = 30;
            //field4.SelectWholeText();

            view.Add(field4);

            field4.SelectWholeText();

            //field4.SelectedTextStart = 3;
            //field4.SelectedTextEnd = 12;

            //field4.SelectText(0, 5);

            field4.FocusGained += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field 4 FOCUS GAINED \n");
            };
            field4.FocusLost += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field 4 FOCUS LOST \n");
            };


            button = newButton("set/get sel 5-10");
            button.Clicked += (s, e) =>
            {
                switch (index)
                {
                    case 0:
                        field.SelectText(5, 15);
                        //field.SelectWholeText();
                        //field.SelectedTextStart = 5;
                        //field.SelectedTextEnd = 15;
                    break;
                    case 1:
                        field2.SelectText(0, 15);
                        //field2.SelectWholeText();
                        //field2.SelectedTextStart = 5;
                        //field2.SelectedTextEnd = 15;
                    break;
                    case 2:
                         field3.SelectText(5, 10);
                        //field3.SelectWholeText();
                        //field3.SelectedTextStart = 5;
                        //field3.SelectedTextEnd = 15;
                    break;
                    case 3:
                        field4.SelectText(6, 12);
                        //field4.SelectWholeText();
                        //field4.SelectedTextStart = 5;
                        //field4.SelectedTextEnd = 15;
                    break;  
                    default:
                    break;
                }

                // field.SelectWholeText();
                // field.SelectedTextStart = 10;
                // field.SelectedTextEnd = 10;
                Tizen.Log.Error("NUI", "field[" + index + 1 + "] sel [" + field.SelectedTextStart + "][" + field.SelectedTextEnd + "][" + field.SelectedText + "] \n");

                index ++;
                if (index == 4) index = 0;
            };
            view.Add(button);


            button2 = newButton("get sel");
            button2.Clicked += (s, e) =>
            {
                int idx = index - 1;
                if (idx == -1) idx = 3;

                switch (idx)
                {
                    case 0:
                        Tizen.Log.Error("NUI", "field 1 sel [" + field.SelectedTextStart + "][" + field.SelectedTextEnd + "][" + field.SelectedText + "] \n");
                    break;
                    case 1:
                        Tizen.Log.Error("NUI", "field 2 sel [" + field2.SelectedTextStart + "][" + field2.SelectedTextEnd + "][" + field2.SelectedText + "] \n");
                    break;
                    case 2:
                        Tizen.Log.Error("NUI", "field 3 sel [" + field3.SelectedTextStart + "][" + field3.SelectedTextEnd + "][" + field3.SelectedText + "] \n");
                    break;
                    case 3:
                        Tizen.Log.Error("NUI", "field 4 sel [" + field4.SelectedTextStart + "][" + field4.SelectedTextEnd + "][" + field4.SelectedText + "] \n");
                    break;  
                    default:
                    break;
                }
            };
            view.Add(button2);


            button3 = newButton("set sel ALL 0-10");
            button3.Clicked += (s, e) =>
            {

                field.SelectText(0, 15);
                field2.SelectText(1, 14);
                field3.SelectText(2, 13);
                field4.SelectText(5, 12);

                /*
                field.SelectWholeText();
                field2.SelectWholeText();
                field3.SelectWholeText();
                field4.SelectWholeText();
                */

                /*
                field.SelectedTextStart = 0;
                field.SelectedTextEnd = 15;

                field2.SelectedTextStart = 0;
                field2.SelectedTextEnd = 15;

                field3.SelectedTextStart = 0;
                field3.SelectedTextEnd = 15;

                field4.SelectedTextStart = 0;
                field4.SelectedTextEnd = 15;
                */
                


                Tizen.Log.Error("NUI", "field 1 sel [" + field.SelectedTextStart + "][" + field.SelectedTextEnd + "][" + field.SelectedText + "] \n");
                Tizen.Log.Error("NUI", "field 2 sel [" + field2.SelectedTextStart + "][" + field2.SelectedTextEnd + "][" + field2.SelectedText + "] \n");
                Tizen.Log.Error("NUI", "field 3 sel [" + field3.SelectedTextStart + "][" + field3.SelectedTextEnd + "][" + field3.SelectedText + "] \n");
                Tizen.Log.Error("NUI", "field 4 sel [" + field4.SelectedTextStart + "][" + field4.SelectedTextEnd + "][" + field4.SelectedText + "] \n\n");
            };
            view.Add(button3);


            button4 = newButton("get sel ALL");
            button4.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "field 1 sel [" + field.SelectedTextStart + "][" + field.SelectedTextEnd + "][" + field.SelectedText + "] \n");
                Tizen.Log.Error("NUI", "field 2 sel [" + field2.SelectedTextStart + "][" + field2.SelectedTextEnd + "][" + field2.SelectedText + "] \n");
                Tizen.Log.Error("NUI", "field 3 sel [" + field3.SelectedTextStart + "][" + field3.SelectedTextEnd + "][" + field3.SelectedText + "] \n");
                Tizen.Log.Error("NUI", "field 4 sel [" + field4.SelectedTextStart + "][" + field4.SelectedTextEnd + "][" + field4.SelectedText + "] \n\n");
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

                button7.Focusable = true;
                button7.FocusableInTouch = true;
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

                button7.Focusable = false;
                button7.FocusableInTouch = false;
            };
            view.Add(button6);


            button7 = newButton("select none");
            button7.Clicked += (s, e) =>
            {
                field.SelectNone();
                field2.SelectNone();
                field3.SelectNone();
                field4.SelectNone();
            };
            view.Add(button7);

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
                Focusable = false,
                FocusableInTouch = false,
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
