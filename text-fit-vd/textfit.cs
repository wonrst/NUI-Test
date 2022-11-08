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

        TextLabel textLabel;

        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            var myView = new View
            {
                Size2D = new Size2D(1920, 1080),
                BackgroundColor = Color.White
            };

            Window.Instance.GetDefaultLayer().Add(myView);
            myView.Focusable = true;
            myView.KeyEvent += OnKeyPressed;
            FocusManager.Instance.SetCurrentFocusView(myView);

            textLabel = new TextLabel();
            textLabel.Position2D = new Position2D(0, 100);
            textLabel.Size2D = new Size2D(480, 144);
            textLabel.BackgroundColor = Color.Cyan;
            textLabel.VerticalAlignment = VerticalAlignment.Center;
            textLabel.FontFamily = "SamsungOneUI_400";
            textLabel.PointSize = 32;
            textLabel.MultiLine = true;
            textLabel.MinLineSize = 56;
            textLabel.Text = "பொறுப்புத் துறப்பு: உங்கள் Gaming Hub அனுபவமானது உங்கள் Samsung சாதனத்தின் மாடலைப் பொறுத்து மாறுபடக்கூடும்.";
            myView.Add(textLabel);

            textLabel.TextFitChanged += TextLable_TextFitChanged;
/*
            PropertyMap fit = new PropertyMap();
            fit.Add("enable", new PropertyValue(true));
            fit.Add("minSize", new PropertyValue(5.0f));
            fit.Add("maxSize", new PropertyValue(32.0f));
            fit.Add("stepSize", new PropertyValue(4.0f));
            textLabel.TextFit = fit;
*/

            var textFit = new Tizen.NUI.Text.TextFit();
            textFit.Enable = true;
            textFit.MinSize = 5;
            textFit.MaxSize = 32;
            textFit.StepSize = 4;
            textLabel.SetTextFit(textFit);

        }

        private void TextLable_TextFitChanged(object sender, global::System.EventArgs e)
        {
            Tizen.NUI.Text.TextFit fit = textLabel.GetTextFit();
            Tizen.Log.Error("NUI", "fontSize: " + fit.FontSize + "\n");

            if (fit.FontSize > 9)
            {
                textLabel.MinLineSize = 56;
            }
            else
            {
                textLabel.MinLineSize = 30;
            }

/*
            if (fit.FontSize > 28)
            {
                textLabel.MinLineSize = 56;
            }
            else
            {
                textLabel.MinLineSize = 48;
            }
*/
            Tizen.Log.Error("NUI", "MinLineSize: " + textLabel.MinLineSize + "\n");
        }

        private bool OnKeyPressed(object source, View.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "1")
                {
                    textLabel.Text = "பொறுப்புத் துறப்பு: உங்கள் Gaming Hub அனுபவமானது உங்கள் Samsung சாதனத்தின் மாடலைப் பொறுத்து மாறுபடக்கூடும்.";
                    Tizen.Log.Error("NUI", "KeyPressedName: " + e.Key.KeyPressedName + "\n");
                }
            }

            return false;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
