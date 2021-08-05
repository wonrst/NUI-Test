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

            Tizen.NUI.Text.InputFilter inputFilter;
            inputFilter.Accepted = new Regex(@"[\d]"); // accept whole digits
            inputFilter.Rejected = new Regex("[0-3]"); // reject 0, 1, 2, 3
            field.SetInputFilter(inputFilter);
            field.InputFiltered += OnInputFiltered;
        }

        public void OnInputFiltered(object sender, InputFilteredEventArgs e)
        {
            if (e.Type == InputFilterType.Accepted)
            {
                Tizen.Log.Fatal("NUI", "[Accepted] Only accepted follow characters " + (sender as TextField).GetInputFilter().Accepted + "\n");
            }
            else if (e.Type == InputFilterType.Rejected)
            {
                Tizen.Log.Fatal("NUI", "[Rejected] Rejected follow characters " + (sender as TextField).GetInputFilter().Rejected + "\n");
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
