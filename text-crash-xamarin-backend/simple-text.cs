using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace HelloWorldTest
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

            TextField entry1 = new TextField
            {
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                PlaceholderText = "Placeholder a looooooooooooooooooooooooooooooooooooooooooooooooooong text",
                PlaceholderTextColor = Color.Gray,
                TextColor = Color.Blue,
                PointSize = 12.0f,
                Ellipsis = true,
                MaxLength = 255,
            };
            entry1.FocusGained += (s, e) => Console.WriteLine($"Entry1 focused");
            entry1.FocusLost += (s, e) => Console.WriteLine($"Entry1 focus lost");
            Console.WriteLine($"entry.MaxLength : {entry1.MaxLength}");
            entry1.Position2D = new Position2D(10, 10);

            window.Add(entry1);

            window.Add(new TextField
            {
                PlaceholderText = "Input text",
                PlaceholderTextFocused = "Focused PlaceHolder",
                Position2D = new Position2D(10, 100),
            });

            var inputmethod = new InputMethod
            {
                PanelLayout = InputMethod.PanelLayoutType.Password
            };

            window.Add(new TextField
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                PlaceholderText = "Password",
                InputMethodSettings = (new InputMethod
                {
                    PanelLayout = InputMethod.PanelLayoutType.Password
                }).OutputMap,
                HiddenInputSettings = new PropertyMap().Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.ShowLastCharacter))
                .Add(HiddenInputProperty.ShowLastCharacterDuration, new PropertyValue(500)),
                Position2D = new Position2D(10, 200),
            });

            window.Add(new TextField
            {
                PlaceholderText = "Number",
                InputMethodSettings = (new InputMethod
                {
                    PanelLayout = InputMethod.PanelLayoutType.NumberOnly
                }).OutputMap,
                Position2D = new Position2D(10, 300),
            });


            var textChangedTest = new TextField
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                PlaceholderText = "Red : N > 10",
                MaxLength = 20,
                InputMethodSettings = (new InputMethod
                {
                    PanelLayout = InputMethod.PanelLayoutType.NumberOnly,
                }).OutputMap,
                Position2D = new Position2D(10, 400),
            };

            textChangedTest.TextChanged += (s, e) =>
            {
                if (textChangedTest.Text.Length > 10)
                {
                    textChangedTest.TextColor = Color.Red;
                }
                else
                {
                    textChangedTest.TextColor = Color.Black;
                }
            };
            window.Add(textChangedTest);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
