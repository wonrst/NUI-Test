using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;

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
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,

            };
            window.Add(view);

            float pointSize = 15.0f;
            List<string> textList = new List<string>(new string[] {"Date", "Note On", "update", "Enter your password", "View your current for your viewing"});
            //List<string> textList = new List<string>(new string[] {"Date", "Note On", "Update", "Enter your password"});
            //List<string> textList = new List<string>(new string[] {"Date"});
            //List<string> textList = new List<string>(new string[] {"Note On"});

            List<TextLabel> labelList = new List<TextLabel>();

            for (int i = 0 ; i < textList.Count ; i ++)
            {
                TextLabel label = NewTextLabel(textList[i]);
                view.Add(label);
                labelList.Add(label);
            }


            View control = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,

            };
            view.Add(control);

            var size = NewTextLabel("" + pointSize);
            //var size = NewTextLabel("");
            control.Add(size);

            Button buttonUp = new Button
            {
                //Text = "Size up",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            control.Add(buttonUp);
            buttonUp.Clicked += (s, e) =>
            {
                pointSize ++;
                size.Text = "" + pointSize;
                Tizen.Log.Error("NUI", "PointSize[" + pointSize + "] \n");
                for (int i = 0 ; i < labelList.Count ; i ++)
                {
                    labelList[i].PointSize = pointSize;
                }
            };

            Button buttonDown = new Button
            {
                //Text = "Size down",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            control.Add(buttonDown);
            buttonDown.Clicked += (s, e) =>
            {
                pointSize --;
                size.Text = "" + pointSize;

                Tizen.Log.Error("NUI", "PointSize[" + pointSize + "] \n");
                for (int i = 0 ; i < labelList.Count ; i ++)
                {
                    labelList[i].PointSize = pointSize;
                }
            };


        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                FontFamily = "SamsungOneUI 600",
                //FontFamily = "Dejavu Sans",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            return label;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
