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
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            //string spanUnderlineText = "Before <span u-color='blue' u-type='dashed' u-height='4.0f' u-dash-gap='2.0f' u-dash-width='3.0f'> Hello World</span> after.";
            string spanUnderlineText = "Before <span u-color='blue' u-height='1.0f'> Hello World</span> after.";

            string underlineText = "Before <u color='blue' height='2.0f'> Hello World</u> after.";

            string uText = "<u color='blue' height='2'> Hello World</u>";

            //string mixSpanText = "<span background-color='#ABABAB' font-size='10' font-family='Ubuntu Mono' font-width='condensed' u-color='green' u-height='2' font-slant='italic' text-color='red'>Lorem ipsum dolor sit amet, consectetur adipiscing</span> elit, sed do <span font-size='15' font-family='Dejavu Sans' font-width='light' text-color='blue' u-color='blue' u-type='dashed' u-height='4.0f' u-dash-gap='2.0f' u-dash-width='3.0f' background-color='red'>eiusmod tempor incididunt ut labore</span> et dolore magna aliqua.";

            string mixSpanText = "<span char-space-value='15.0f' background-color='#ABABAB' s-color='blue' s-height='3' font-size='10' font-family='Ubuntu Mono' font-width='condensed' u-color='green' u-height='2' font-slant='italic' text-color='red'>Lorem ipsum dolor sit amet, consectetur adipiscing</span> elit, sed do <span font-size='15' font-family='Dejavu Sans' font-width='light' text-color='blue' u-color='blue' background-color='red' char-space-value='-5.0f'>eiusmod tempor incididunt ut labore</span> et dolore magna aliqua.";

            string testSpan = "<span>hello</span>";

            TextLabel label = NewTextLabel(mixSpanText);
            view.Add(label);

            TextLabel label2 = NewTextLabel(underlineText);
            view.Add(label2);

            TextLabel label3 = NewTextLabel(uText);
            view.Add(label3);

            TextField field = NewTextField(mixSpanText);
            view.Add(field);

            TextEditor editor = NewTextEditor(mixSpanText);
            view.Add(editor);

            TextEditor editor2 = NewTextEditor(testSpan);
            view.Add(editor2);
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = 100,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                EnableMarkup = true,
                MultiLine = true,
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
                MaxLength = 200,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                EnableMarkup = true,
            };
            setHandle(field);
            return field;
        }

        public TextEditor NewTextEditor(string text)
        {
            var editor = new TextEditor
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = 200,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                EnableMarkup = true,
            };
            setHandle(editor);
            return editor;
        }

        public void setHandle(TextField field)
        {
            field.GrabHandleImage = "images/handle_down.png";

            var selectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage();
            selectionHandleImage.LeftImageUrl = "images/handle_downleft.png";
            selectionHandleImage.RightImageUrl = "images/handle_downright.png";
            field.SetSelectionHandleImage(selectionHandleImage);
        }

        public void setHandle(TextEditor editor)
        {
            editor.GrabHandleImage = "images/handle_down.png";

            var selectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage();
            selectionHandleImage.LeftImageUrl = "images/handle_downleft.png";
            selectionHandleImage.RightImageUrl = "images/handle_downright.png";
            editor.SetSelectionHandleImage(selectionHandleImage);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
