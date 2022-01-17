extern alias TizenSystemSettings;
using TizenSystemSettings.Tizen.System;

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
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);


            TextLabel label = new TextLabel
            {
                Text = "Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 100,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(label);


            TextField field = new TextField
            {
                Text = "Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 100,
                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(field);
            setHandle(field);


            TextEditor editor = new TextEditor
            {
                Text = "Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 100,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,
            };
            view.Add(editor);
            setHandle(editor);


            //label.FontSizeScale = -1;
            //field.FontSizeScale = -1;
            //editor.FontSizeScale = -1;


            var button0 = new Button
            {
                Text = "system setting",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(button0);
            button0.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "FontSizeScale [" + label.FontSizeScale + "] \n");
                Tizen.Log.Error("NUI", "UseSystemSetting [" + Tizen.NUI.FontSizeScale.UseSystemSetting + "] \n");
                Tizen.Log.Error("NUI", "Enable [" + label.EnableFontSizeScale + "][" + field.EnableFontSizeScale + "][" + editor.EnableFontSizeScale + "] \n");
            };

            
            var button = new Button
            {
                Text = "font size scale 0.5",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                //Tizen.Log.Error("NUI", "SystemSettings.FontSize [" + SystemSettings.FontSize + "] \n");

                //SystemSettings.FontSize = SystemSettingsFontSize.Normal;
                //SystemSettings.FontSize = SystemSettingsFontSize.Small;

                //SystemSettingsFontSize fontSize = SystemSettings.FontSize;

                label.FontSizeScale = 0.5f;
                field.FontSizeScale = 0.5f;
                editor.FontSizeScale = 0.5f;
            };

            var button2 = new Button
            {
                Text = "font size scale 1.0",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(button2);
            button2.Clicked += (s, e) =>
            {
                //SystemSettingsFontSize systemSettingsFontSize = SystemSettingsFontSize.Normal;
                label.FontSizeScale = 1.0f;
                field.FontSizeScale = 1.0f;
                editor.FontSizeScale = 1.0f;
            };

            var button3 = new Button
            {
                Text = "font size scale 1.5",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(button3);
            button3.Clicked += (s, e) =>
            {
                //SystemSettingsFontSize systemSettingsFontSize = SystemSettingsFontSize.Large;
                label.FontSizeScale = 1.5f;
                field.FontSizeScale = 1.5f;
                editor.FontSizeScale = 1.5f;
            };

            var button4 = new Button
            {
                Text = "enable",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(button4);
            button4.Clicked += (s, e) =>
            {
                label.EnableFontSizeScale = true;
                field.EnableFontSizeScale = true;
                editor.EnableFontSizeScale = true;
            };

            var button5 = new Button
            {
                Text = "disable",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(button5);
            button5.Clicked += (s, e) =>
            {
                label.EnableFontSizeScale = false;
                field.EnableFontSizeScale = false;
                editor.EnableFontSizeScale = false;
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

        public void setHandle(TextEditor editor)
        {
            editor.GrabHandleImage = "images/handle_down.png";

            PropertyMap imageLeftMap = new PropertyMap();
            imageLeftMap.Add("filename", new PropertyValue("images/handle_downleft.png"));
            editor.SelectionHandleImageLeft = imageLeftMap;

            PropertyMap imageRightMap = new PropertyMap();
            imageRightMap.Add("filename", new PropertyValue("images/handle_downright.png"));
            editor.SelectionHandleImageRight = imageRightMap;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}



/* test for target

using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Accessibility;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class AccessibilityManagerSample : IExample
    {
        Size2D windowSize;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.White;
            windowSize = window.Size;

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
            window.GetDefaultLayer().Add(view);

            TextLabel label = new TextLabel
            {
                Text = "Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 180,
                
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(label);


            TextField field = new TextField
            {
                Text = "Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 180,
                
                MaxLength = 200,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(field);


            TextEditor editor = new TextEditor
            {
                Text = "Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 180,
                
                PointSize = 15.0f,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,
            };
            view.Add(editor);


            label.FontSizeScale = -1;
            field.FontSizeScale = -1;
            editor.FontSizeScale = -1;


            TextField field1 = new TextField
            {
                Text = "",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                
                MaxLength = 200,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(field1);
            field1.TextChanged += (s, e) =>
            {
                if (field1.Text.Length == 2)
                {
                    StyleManager.Instance.BlockControlStyleChangeSignalConnect = true;
                }
                else if (field1.Text.Length == 3)
                {
                    StyleManager.Instance.BlockControlStyleChangeSignalConnect = false;
                }
                
                Tizen.Log.Error("NUI", "RYU FontSizeScale [" + label.FontSizeScale + "] \n");
                Tizen.Log.Error("NUI", "RYU PointSize [" + label.PointSize + "][" + field.PointSize + "][" + editor.PointSize + "] \n");
                Tizen.Log.Error("NUI", "RYU Enable [" + label.EnableFontSizeScale + "][" + field.EnableFontSizeScale + "][" + editor.EnableFontSizeScale + "] \n");
                Tizen.Log.Error("NUI", "RYU block control [" + StyleManager.Instance.BlockControlStyleChangeSignalConnect + "] \n");
            };

            TextField field2 = new TextField
            {
                Text = "",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                
                MaxLength = 200,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(field2);
            field2.TextChanged += (s, e) =>
            {
                if (field2.Text.Length == 0)
                {
                    label.EnableFontSizeScale = true;
                    field.EnableFontSizeScale = true;
                    editor.EnableFontSizeScale = true;
                }
                else if (field2.Text.Length == 1)
                {
                    label.EnableFontSizeScale = false;
                    field.EnableFontSizeScale = false;
                    editor.EnableFontSizeScale = false;
                }
                
                Tizen.Log.Error("NUI", "RYU FontSizeScale [" + label.FontSizeScale + "] \n");
                Tizen.Log.Error("NUI", "RYU PointSize [" + label.PointSize + "][" + field.PointSize + "][" + editor.PointSize + "] \n");
                Tizen.Log.Error("NUI", "RYU Enable [" + label.EnableFontSizeScale + "][" + field.EnableFontSizeScale + "][" + editor.EnableFontSizeScale + "] \n");
                Tizen.Log.Error("NUI", "RYU block control [" + StyleManager.Instance.BlockControlStyleChangeSignalConnect + "] \n");
            };
        }

        public void Deactivate()
        {
        }
    }
}

*/