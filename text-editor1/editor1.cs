using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

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
            window.BackgroundColor = Color.Gray;

            // test for main view size
            var ruler = new View
            {
                Size2D = new Size2D(10, 500),
                Position2D = new Position2D(420, 0),
                BackgroundColor = Color.Green,
            };
            window.Add(ruler);


            var mainView = new View
            {
                Layout = new RelativeLayout{},
                WidthSpecification = -1,
                HeightSpecification = -1,
                BackgroundColor = Color.Black,
                Size2D = new Size2D(400, 500),
            };
            window.Add(mainView);

            // top view
            var topView = new View
            {
                WidthSpecification = -1,
                HeightSpecification = -2,
                BackgroundColor = Color.Purple,
            };
            mainView.Add(topView);

            var label = new TextLabel
            {
                Text = "Editor Test 1 : ",
                WidthSpecification = -2,
                HeightSpecification = -2,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };
            topView.Add(label);

            // center view
            /*
            var centerView = new View
            {
                WidthSpecification = -1,
                BackgroundColor = Color.Orange,
                Margin = new Extents(20, 20, 20, 0),
            };
            mainView.Add(centerView);
*/
            var centerView = new TextEditor
            {
                Text = "This test is for testing Editor with very long text. This software is the confidential and proprietary information of Samsung Electronics, Inc. You shall not disclose such Confidential Information and shall use it only in accordance with the terms of the license agreement you entered into with Samsung.",
                WidthSpecification = -1,
                BackgroundColor = Color.Orange,
                Margin = new Extents(20, 20, 20, 0),
                PointSize = 15.0f,
            };
            mainView.Add(centerView);
            
            // bottom view
            var bottomView = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthSpecification = -1,
                HeightSpecification = -2,
                BackgroundColor = Color.Red,
            };
            mainView.Add(bottomView);

            var underline = new View
            {
                WidthSpecification = -1,
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
                WidthSpecification = -1,
                HeightSpecification = -2,
                BackgroundColor = Color.Yellow,
            };
            bottomView.Add(bottomHorView);

            var label2 = new TextLabel
            {
                Text = "Editor Test 2 : ",
                WidthSpecification = -2,
                HeightSpecification = -1,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                VerticalAlignment = VerticalAlignment.Center,
            };
            bottomHorView.Add(label2);

            var bottomVerView = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthSpecification = -2,
                HeightSpecification = -2,
                BackgroundColor = Color.Green,
            };
            bottomHorView.Add(bottomVerView);
            
            var field = new TextField
            {
                Text = "Please, input any sentence.",
                WidthSpecification = -1,
                HeightSpecification = -2,
                BackgroundColor = Color.White,
                PointSize = 15.0f,
                VerticalAlignment = VerticalAlignment.Center,
                MaxLength = 999,
            };
            bottomVerView.Add(field);

            var underline2 = new View
            {
                WidthSpecification = -1,
                HeightSpecification = 2,
                BackgroundColor = Color.Gray,
                Margin = new Extents(0, 0, 0, 5),
            };
            bottomVerView.Add(underline2);



            // Relative Bottom View
            //RelativeLayout.SetTopTarget(bottomView, mainView);
            //RelativeLayout.SetBottomTarget(bottomView, mainView);
            //RelativeLayout.SetLeftTarget(bottomView, mainView);
            //RelativeLayout.SetRightTarget(bottomView, mainView);

            RelativeLayout.SetTopRelativeOffset(bottomView, 1.0f);
            RelativeLayout.SetBottomRelativeOffset(bottomView, 1.0f);
            RelativeLayout.SetVerticalAlignment(bottomView, RelativeLayout.Alignment.End);


            // Relative Center View
            RelativeLayout.SetTopTarget(centerView, topView);
            RelativeLayout.SetBottomTarget(centerView, bottomView);
            RelativeLayout.SetTopRelativeOffset(centerView, 1.0f);
            RelativeLayout.SetBottomRelativeOffset(centerView, 0.0f);

            //RelativeLayout.SetVerticalAlignment(centerView, RelativeLayout.Alignment.Start);
            RelativeLayout.SetFillVertical(centerView, true);



            field.TextChanged += (s, e) =>
            {
                //Tizen.Log.Fatal("NUI", "editor view size : " + editor.Size2D.Width + " " + editor.Size2D.Height + "\n");
                Tizen.Log.Fatal("NUI", "center view size : " + centerView.Size2D.Width + " " + centerView.Size2D.Height + "\n");
                
                int width = mainView.Size2D.Width;

                mainView.Size2D = new Size2D(width, field.Text.Length * 10);

                int wid = window.Size.Width;
                Tizen.Log.Fatal("NUI", "window : " + window.Size.Width + " " + window.Size.Height + "\n");

                // Relative Center View
                RelativeLayout.SetTopTarget(centerView, topView);
                RelativeLayout.SetBottomTarget(centerView, bottomView);
                RelativeLayout.SetTopRelativeOffset(centerView, 1.0f);
                RelativeLayout.SetBottomRelativeOffset(centerView, 0.0f);

                //RelativeLayout.SetVerticalAlignment(centerView, RelativeLayout.Alignment.Start);
                RelativeLayout.SetFillVertical(centerView, true);
            };
            
            centerView.FocusGained += (s, e) =>
            {
                underline.BackgroundColor = Color.Cyan;
            };

            centerView.FocusLost += (s, e) =>
            {
                underline.BackgroundColor = Color.Gray;
            };

            field.FocusGained += (s, e) =>
            {
                underline2.BackgroundColor = Color.Cyan;
            };

            field.FocusLost += (s, e) =>
            {
                underline2.BackgroundColor = Color.Gray;
            };

            InputMethodContext ime = centerView.GetInputMethodContext();
            ime.StatusChanged += Ime_StatusChanged;
            ime.Resized += (s, e) =>
            {
                var resizedIME = s as InputMethodContext;
                Rectangle rectangle = resizedIME.GetInputMethodArea();

                Tizen.Log.Fatal("NUI", "ime : " + rectangle.Width + " " + rectangle.Height + "\n");

                int width = window.Size.Width;
                int height = window.Size.Height - rectangle.Height;

                Tizen.Log.Fatal("NUI", "window width height : " + width + " " + height + "\n");

                mainView.Size2D = new Size2D(width, height);

                Tizen.Log.Fatal("NUI", "main view size : " + mainView.Size2D.Width + " " + mainView.Size2D.Height + "\n");

            };


        }

        private void Ime_StatusChanged(object sender, InputMethodContext.StatusChangedEventArgs e)
        {
            if (e.StatusChanged)
            {
                // When the virtual keyboard (IME) is shown, StatusChanged is true
            }
        }

        private void Ime_Resized(object sender, InputMethodContext.ResizedEventArgs e)
        {
            // When the virtual keybaord (IME) is resized, this callback is called.
            // And User can get the changed size by using `GetInputMethodArea()`

            var resizedIME = sender as InputMethodContext;
            Rectangle rectangle = resizedIME.GetInputMethodArea();
            //  position -> rectangle.X  and rectangle.Y 
            //  size      -> rectangle.Width and rectangle.Height
        }

        public void onTextFieldTextChanged(object sender, TextField.TextChangedEventArgs e)
        {
            //Tizen.Log.Fatal("NUI", "editor view size : " + editor.Size2D.Width + " " + editor.Size2D.Height + "\n");
            //Tizen.Log.Fatal("NUI", "center view size : " + centerView.Size2D.Width + " " + centerView.Size2D.Height + "\n");
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
