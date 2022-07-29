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
                    VerticalAlignment = VerticalAlignment.Bottom,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            string shortText = "Lorem ipsum dolor";
            string longText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            string veryLongText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            string rtlText = "لكن لا بد أن أوضح لك أن كل هذه الأفكار المغلوطة حول استنكار  النشوة وتمجيد الألم نشأت بالفعل، وسأعرض لك التفاصيل لتكتشف حقيقة وأساس تلك السعادة البشرية، فلا أحد يرفض أو يكره أو يتجنب الشعور بالسعادة، ولكن بفضل هؤلاء الأشخاص الذين لا يدركون بأن السعادة لا بد أن نستشعرها بصورة أكثر عقلانية ومنطقية فيعرضهم هذا لمواجهة الظروف الأليمة، وأكرر بأنه لا يوجد من يرغب في الحب ونيل المنال ويتلذذ بالآلام، الألم هو الألم ولكن نتيجة لظروف ما قد تكمن السعاده فيما نتحمله من كد وأسي";

            var field = NewTextField(veryLongText);
            field.PointSize = 15.0f;
            view.Add(field);

            var editor = NewTextEditor(veryLongText);
            view.Add(editor);

            var label2 = NewTextLabel(longText);
            label2.PointSize = 15.0f;
            view.Add(label2);

            var label = NewTextLabel(veryLongText);
            view.Add(label);
            label.Ellipsis = false;


            var max = NewButton("get maxlines");
            view.Add(max);
            max.Clicked += (s, e) =>
            {
                max.Text = "MaxLines:" + label.MaxLines;
            };

            var maxPlus = NewButton("maxlines++");
            view.Add(maxPlus);
            maxPlus.Clicked += (s, e) =>
            {
                label.MaxLines = label.MaxLines + 1;
                max.Text = "MaxLines:" + label.MaxLines;
            };

            var maxMinus = NewButton("maxlines--");
            view.Add(maxMinus);
            maxMinus.Clicked += (s, e) =>
            {
                label.MaxLines = label.MaxLines - 1;
                max.Text = "MaxLines:" + label.MaxLines;
            };

            var button = NewButton("label size up");
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                label.HeightSpecification += 10;
            };

            var button2 = NewButton("label size down");
            view.Add(button2);
            button2.Clicked += (s, e) =>
            {
                label.HeightSpecification -= 10;
            };

            var button5 = NewButton("label wrap content");
            view.Add(button5);
            button5.Clicked += (s, e) =>
            {
                label.HeightSpecification = LayoutParamPolicies.WrapContent;
            };

            var button3 = NewButton("point size up");
            view.Add(button3);
            button3.Clicked += (s, e) =>
            {
                label.PointSize += 2;
            };

            var button4 = NewButton("point size down");
            view.Add(button4);
            button4.Clicked += (s, e) =>
            {
                label.PointSize -= 2;
            };

            var button6 = NewButton("wrap mode : " + label.LineWrapMode.ToString());
            view.Add(button6);
            int wrapMode = 0;
            button6.Clicked += (s, e) =>
            {
                wrapMode ++;
                if (wrapMode > 3)
                    wrapMode = 0;

                switch (wrapMode)
                {
                    case 0:
                        label.LineWrapMode = LineWrapMode.Word;
                        break;
                    case 1:
                        label.LineWrapMode = LineWrapMode.Character;
                        break;
                    case 2:
                        label.LineWrapMode = LineWrapMode.Hyphenation;
                        break;
                    case 3:
                        label.LineWrapMode = LineWrapMode.Mixed;
                        break;
                    default:
                        break;
                }
                button6.Text = "wrap mode : " + label.LineWrapMode.ToString();
            };

            var button7 = NewButton("get size, line count");
            view.Add(button7);
            button7.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Size : [" + label.Size.Width + ", " + label.Size.Height + "] Line Count : [" + label.LineCount + "] \n");
            };

            bool ellipsis = false;
            var button8 = NewButton("ellipsis");
            view.Add(button8);
            button8.Clicked += (s, e) =>
            {
                ellipsis = !ellipsis;
                label.Ellipsis = ellipsis;
            };
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                //HeightSpecification = 250,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 24.0f,
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
                MaxLength = 200,
                PointSize = 15.0f,
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
                HeightSpecification = 100,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };
            return editor;
        }

        public Button NewButton(string text)
        {
            var button = new Button
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 30,
                PointSize = 15.0f,
            };
            return button;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
