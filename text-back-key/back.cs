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
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            FocusManager.Instance.EnableDefaultAlgorithm(true);

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
                BackgroundColor = Color.White,
                Name = "View",
            };
            window.Add(view);

            view.Focusable = true;


            var field = new TextField()
            {
                Focusable = true,
                Name = "TextField",
                BackgroundColor = Color.Gray,
            };
            field.SizeWidth = 500;
            field.SizeHeight = 50;
            view.Add(field);

            field.FocusGained += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field FocusGained \n");
            };

            field.FocusLost += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field FocusLost \n");
            };

            var focusButton = new Button()
            {
                Name = "Button",
                Text = "Get Focus",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            view.Add(focusButton);

            focusButton.Clicked += (s, e) => FocusManager.Instance.SetCurrentFocusView(focusButton);

            var focusButton2 = new Button()
            {
                Name = "Button2",
                Text = "Get Focus to view",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            view.Add(focusButton2);

            focusButton2.Clicked += (s, e) => FocusManager.Instance.SetCurrentFocusView(view);


            var isConsume = true;
            var propagate = new Button()
            {
                Text = $"Consume event ? {isConsume}",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            view.Add(propagate);

            propagate.Clicked += (s, e) =>
            {
                isConsume = !isConsume;
                propagate.Text = $"Consume event ? {isConsume}";
            };

            var currentFocus = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(currentFocus);

            var log = new LogOutput
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(log);

            view.KeyEvent += (s, e) =>
            {
                log.AddLog($"KeyEvent : {e.Key.State} : {e.Key.KeyPressedName} : {e.Key.KeyCode}");
                return isConsume;
            };

            FocusManager.Instance.FocusChanged += focusChanged;

            void focusChanged(object s, FocusManager.FocusChangedEventArgs e)
            {
                Tizen.Log.Error("NUI", "FocusManager focusChanged [" + e.NextView?.Name + "] \n");
                //currentFocus.Text = $"Current Focus : {e.NextView.Name}";
            };

        }

        class LogOutput : ScrollableBase
        {
            public LogOutput()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent;
                HeightSpecification = LayoutParamPolicies.WrapContent;
                HideScrollbar = false;

                ContentContainer.Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Top,
                };
            }

            public void AddLog(string log)
            {
                var txt = new TextLabel
                {
                    Text = log
                };
                Console.WriteLine(log);
                ContentContainer.Add(txt);
                if (ContentContainer.Children.Count > 30)
                {
                    var remove = ContentContainer.Children.GetRange(0, 10);
                    foreach (var child in remove)
                    {
                        ContentContainer.Remove(child);
                    }
                }
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
