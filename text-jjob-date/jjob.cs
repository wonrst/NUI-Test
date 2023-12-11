using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace TextComponentsTest
{
    class Example : NUIApplication
    {
        public TapGestureDetector tapDetector;

        public TextField fieldYear;
        public TextField fieldMonth;
        public TextField fieldDay;

        public int WIDTH = 100;
        public int HEIGHT = 40;

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
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);


            // year
            fieldYear = NewTextField("2022");
            view.Add(fieldYear);
            fieldYear.TextChanged += (s, e) =>
            {
                if (IsValidYear(fieldYear.Text))
                {
                    fieldMonth.SelectWholeText();
                }
            };


            // month
            fieldMonth = NewTextField("2");
            view.Add(fieldMonth);
            fieldMonth.TextChanged += (s, e) =>
            {
                if (IsValidMonth(fieldMonth.Text))
                {
                    fieldDay.SelectWholeText();
                }
                else
                {
                    fieldMonth.Text = FixInvalidDate(fieldMonth.Text, 12);
                    if (IsValidDay(fieldMonth.Text))
                    {
                        fieldDay.SelectWholeText();
                    }
                }
            };


            // day
            fieldDay = NewTextField("10");
            view.Add(fieldDay);
            fieldDay.TextChanged += (s, e) =>
            {
                if (IsValidDay(fieldDay.Text))
                {
                    fieldDay.SelectWholeText();
                }
                else
                {
                    fieldDay.Text = FixInvalidDate(fieldDay.Text, 31);
                    if (IsValidDay(fieldDay.Text))
                    {
                        fieldDay.SelectWholeText();
                    }
                }
            };


            // tap
            tapDetector = new TapGestureDetector();
            tapDetector.Detected += (s, e) =>
            {
                (e.View as TextField).SelectWholeText();
            };
            tapDetector.Attach(fieldYear);
            tapDetector.Attach(fieldMonth);
            tapDetector.Attach(fieldDay);
        }

        public bool IsValidYear(string text)
        {
            return text.Length == 4;
        }

        public bool IsValidMonth(string text)
        {
            int month;
            return int.TryParse(text, out month) && (text.Length <= 2 && (month >= 2 && month <= 12));
        }

        public bool IsValidDay(string text)
        {
            int day;
            return int.TryParse(text, out day) && (text.Length <= 2 && (day >= 4 && day <= 31));
        }

        public string FixInvalidDate(string text, int max)
        {
            int value;
            int.TryParse(text, out value);

            if (text.Length > 1 && value == 0 || text.Length > 2)
            {
                text = text.Remove(0, 1);
            }

            if (value > max)
            {
                text = text.Substring(text.Length - 1, 1);
            }

            return text;
        }

        public TextField NewTextField(string text)
        {
            var field = new TextField
            {
                Text = text,
                WidthSpecification = WIDTH,
                HeightSpecification = HEIGHT,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,

                EnableGrabHandle = false,
                EnableGrabHandlePopup = false,
                CursorWidth = 0,
            };
            field.SetInputFilter(new Tizen.NUI.Text.InputFilter
            {
                Accepted = @"[\d]",
            });

            return field;
        }

        public View NewTapView()
        {
            View view = new View()
            {
                Size2D = new Size2D(WIDTH, HEIGHT),
                BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.0f),
            };
            return view;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
