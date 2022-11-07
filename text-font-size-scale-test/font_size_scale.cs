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

            for (int i = 0 ; i < 5 ; i ++)
                view.Add(NewTextLabel("Lorem ipsum dolor [" + i + "]"));
            
            TextLabel fitLabel = NewTextLabel("TextFit");
            fitLabel.HeightSpecification = 100;
            SetTextFit(fitLabel, 5, 45, 4);
            view.Add(fitLabel);

            view.Add(NewTextField("Lorem ipsum dolor TextField"));
            view.Add(NewTextEditor("Lorem ipsum dolor TextEditor"));

        }

        public void SetTextFit(TextLabel label, int min, int max, int step)
        {
            var textFit = new Tizen.NUI.Text.TextFit();
            textFit.Enable = true;
            textFit.MinSize = min;
            textFit.MaxSize = max;
            textFit.StepSize = step;
            label.SetTextFit(textFit);
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return label;
        }

        public TextField NewTextField(string text)
        {
            var field = new TextField
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return field;
        }

        public TextEditor NewTextEditor(string text)
        {
            var editor = new TextEditor
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return editor;
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