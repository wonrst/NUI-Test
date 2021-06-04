using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace TextComponentsTest
{
    class Example : NUIApplication
    {
        public View mainView;
        public TextEditor textEditor;
        public TextField textField;
        public Window window;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            window = Window.Instance;
            window.BackgroundColor = Color.Gray;

            mainView = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            window.Add(mainView);


            // top view
            var topView = new View
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            mainView.Add(topView);

            var label = new TextLabel
            {
                Text = "Editor Test 1 : ",
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
            };
            topView.Add(label);


            // center view
            var centerView = new View
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Margin = new Extents(20, 20, 20, 0),
            };
            mainView.Add(centerView);

            textEditor = new TextEditor
            {
                Text = "This test is for testing Editor with very long text. This software is the confidential and proprietary information of Samsung Electronics, Inc. You shall not disclose such Confidential Information and shall use it only in accordance with the terms of the license agreement you entered into with Samsung.",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                PointSize = 15.0f,
            };
            centerView.Add(textEditor);


            // bottom view
            var bottomView = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Margin = new Extents(0, 0, 0, 5),
            };
            mainView.Add(bottomView);

            var underline = new View
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 2,
                BackgroundColor = Color.Gray,
                Margin = new Extents(20, 20, 5, 20),
            };
            bottomView.Add(underline);

            var bottomHorView = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            bottomView.Add(bottomHorView);

            var label2 = new TextLabel
            {
                Text = "Editor Test 2 : ",
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                VerticalAlignment = VerticalAlignment.Center,
            };
            bottomHorView.Add(label2);

            var bottomVerView = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Margin = new Extents(0, 10, 0, 0),
            };
            bottomHorView.Add(bottomVerView);
            
            textField = new TextField
            {
                Text = "Please, input any sentence.",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                VerticalAlignment = VerticalAlignment.Center,
                MaxLength = 999,
            };
            bottomVerView.Add(textField);

            var underline2 = new View
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 2,
                BackgroundColor = Color.Gray,
            };
            bottomVerView.Add(underline2);


            textEditor.FocusGained += (s, e) =>
            {
                underline.BackgroundColor = Color.Cyan;
            };

            textEditor.FocusLost += (s, e) =>
            {
                underline.BackgroundColor = Color.Gray;
            };

            textField.FocusGained += (s, e) =>
            {
                underline2.BackgroundColor = Color.Cyan;
            };

            textField.FocusLost += (s, e) =>
            {
                underline2.BackgroundColor = Color.Gray;
            };

            InputMethodContext imeEditor = textEditor.GetInputMethodContext();
            imeEditor.StatusChanged += ImeStatusChanged;
            imeEditor.Resized += ImeResized;

            InputMethodContext imeField = textField.GetInputMethodContext();
            imeField.StatusChanged += ImeStatusChanged;
            imeField.Resized += ImeResized;


            textField.TextChanged += (s, e) =>
            {
                int len = textField.Text.Length;
                if (len % 2 == 0)
                {
                    mainView.HeightSpecification = 400;
                }
                else
                {
                    mainView.HeightSpecification = LayoutParamPolicies.MatchParent;
                }
                textField.DecorationBoundingBox = new Rectangle(mainView.Position2D.X, mainView.Position2D.Y, mainView.Size2D.Width, mainView.Size2D.Height);
                textEditor.DecorationBoundingBox = new Rectangle(mainView.Position2D.X, mainView.Position2D.Y, mainView.Size2D.Width, mainView.Size2D.Height);
                Tizen.Log.Fatal("NUI", "main view size : " + mainView.Size2D.Width + " " + mainView.Size2D.Height + "\n");
            };
        }

        private void ImeStatusChanged(object sender, InputMethodContext.StatusChangedEventArgs e)
        {
            if (e.StatusChanged)
            {
                // When the virtual keyboard (IME) is shown, StatusChanged is true

                Tizen.Log.Fatal("NUI", "Ime Status Changed \n");
            }
        }

        private void ImeResized(object sender, InputMethodContext.ResizedEventArgs e)
        {
            // When the virtual keybaord (IME) is resized, this callback is called.
            // And User can get the changed size by using `GetInputMethodArea()`
            
            var resizedIME = sender as InputMethodContext;
            Rectangle rectangle = resizedIME.GetInputMethodArea();
            Tizen.Log.Fatal("NUI", "ime : " + rectangle.Width + " " + rectangle.Height + "\n");

            int width = window.Size.Width;
            int height = window.Size.Height - rectangle.Height;
            Tizen.Log.Fatal("NUI", "window width height : " + width + " " + height + "\n");
            
            mainView.Size2D = new Size2D(width, height);
            
            textField.DecorationBoundingBox = new Rectangle(mainView.Position2D.X, mainView.Position2D.Y, mainView.Size2D.Width, mainView.Size2D.Height);
            textEditor.DecorationBoundingBox = new Rectangle(mainView.Position2D.X, mainView.Position2D.Y, mainView.Size2D.Width, mainView.Size2D.Height);
            Tizen.Log.Fatal("NUI", "main view size : " + mainView.Size2D.Width + " " + mainView.Size2D.Height + "\n");
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
