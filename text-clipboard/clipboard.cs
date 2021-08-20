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


            // TextField
            TextField field = new TextField
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(field);


            // TextEditor
            TextEditor editor = new TextEditor
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.\n",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
            };
            view.Add(editor);


            var copy = new Button
            {
                Text = "copy",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(copy);

            copy.Clicked += (s, e) =>
            {
                string copiedStr = TextUtils.CopyToClipboard(field);
                Tizen.Log.Error("NUI", "copy field " + copiedStr + "\n");

                copiedStr = TextUtils.CopyToClipboard(editor);
                Tizen.Log.Error("NUI", "copy editor " + copiedStr + "\n");
            };

            var cut = new Button
            {
                Text = "cut",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(cut);

            cut.Clicked += (s, e) =>
            {
                string cutStr = TextUtils.CutToClipboard(field);
                Tizen.Log.Error("NUI", "copy field " + cutStr + "\n");

                cutStr = TextUtils.CutToClipboard(editor);
                Tizen.Log.Error("NUI", "copy editor " + cutStr + "\n");
            };

            var paste = new Button
            {
                Text = "paste",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(paste);

            paste.Clicked += (s, e) =>
            {
                TextUtils.PasteTo(field);
                Tizen.Log.Error("NUI", "paste field \n");

                TextUtils.PasteTo(editor);
                Tizen.Log.Error("NUI", "paste editor \n");
            };
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
