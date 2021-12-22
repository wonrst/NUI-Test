using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace TextComponentsTest
{
    class Example : NUIApplication
    {
        static int resizeCount = 0;
        static int directionCount = 0;
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

            };
            window.Add(view);


            // Normal field
            TextField field = new TextField
            {
                //Text = "Text Field Text Field Text Field Text Field Text Field Text Field Text Field ",
                Text = "Hello world",
                // EnableMarkup = true,
                //Text = "فصل 3 قسط",
                PlaceholderText = "Place! Holder!",
                PlaceholderTextFocused = "Place! Holder!!",
                Position2D = new Position2D(50, 100),
                Size2D = new Size2D(400, 50),
                PointSize = 25.0f,
                BackgroundColor = Color.Cyan,
                PrimaryCursorColor = Color.Red,
                MaxLength = 9999,

                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            setHandle(field);

            field.TextChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Text Changed[" + e.TextField.Text + "] \n");
            };

            view.Add(field);

            //field.SelectWholeText();
            field.SelectionChanged += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field Selected Text [" + field.SelectedText + "][" + field.SelectedTextStart + ", " + field.SelectedTextEnd + "] \n");
            };
            
            var button = new Button
            {
                Text = "field resize",
                Position2D = new Position2D(50, 200),
                Size2D = new Size2D(400, 50),
            };
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "field resize \n");
                if (resizeCount % 2 == 0)
                {
                    field.Size2D = new Size2D(200, 50);
                    //field.Position2D = new Position2D(250, 100);
                }
                else
                {
                    field.Size2D = new Size2D(400, 50);
                    //field.Position2D = new Position2D(50, 100);
                }
                //field.Text = field.Text;
                resizeCount++;

                //Tizen.Log.Error("NUI", "label size[" + label.Size.Width + ", " + label.Size.Height + "] \n");
                //Tizen.Log.Error("NUI", "label natural size[" + label.NaturalSize.Width + ", " + label.NaturalSize.Height + "] \n");
            };

            var button2 = new Button
            {
                Text = "field direction",
                Position2D = new Position2D(50, 300),
                Size2D = new Size2D(400, 50),
            };
            view.Add(button2);
            button2.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "field direction \n");
                if (directionCount % 2 == 0)
                {
                    field.LayoutDirection = ViewLayoutDirectionType.RTL;
                }
                else
                {
                    field.LayoutDirection = ViewLayoutDirectionType.LTR;
                }
                //field.Text = field.Text;
                directionCount++;

                //Tizen.Log.Error("NUI", "label size[" + label.Size.Width + ", " + label.Size.Height + "] \n");
                //Tizen.Log.Error("NUI", "label natural size[" + label.NaturalSize.Width + ", " + label.NaturalSize.Height + "] \n");
            };

            var button3 = new Button
            {
                Text = "select text",
                Position2D = new Position2D(50, 400),
                Size2D = new Size2D(400, 50),
            };
            view.Add(button3);
            button3.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "select text \n");
                field.Text = "Hello World! first second third fourth fifth sixth!!! end";
                //field.SelectWholeText();

                //Tizen.Log.Error("NUI", "child count " + field.ChildCount + "\n");
            };
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

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
