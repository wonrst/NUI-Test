using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;

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
            
            int count = 0;

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

            var field = NewTextField("text..");
            view.Add(field);

            var label = NewTextLabel("");
            view.Add(label);
            //label.SetBinding(TextLabel.TextProperty, new Binding("Text", mode: BindingMode.TwoWay, source: field));

            field.TextChanged += (s, e) =>
            {
                label.Text = field.Text;
            };

            var field2 = NewTextField("");
            view.Add(field2);

            var label2 = NewTextLabel("literal value on label");
            view.Add(label2);
            field2.SetBinding(TextField.TextProperty, new Binding("Text", mode: BindingMode.TwoWay, source: label2));

            var btn = new Button { Text = $"Set text to bug-{count}" };
            btn.Clicked += (s, e) =>
            {
                label2.Text = $"bug-{count}";
                count++;
                btn.Text = $"Set text to bug-{count}";
            };
            view.Add(btn);
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                Ellipsis = true,
                //SizeWidth = 500,
                //WidthSpecification = LayoutParamPolicies.WrapContent,
            };
            return label;
        }

        public TextField NewTextField(string text)
        {
            var field = new TextField
            {
                Text = text,
                MaxLength = 200,
                PointSize = 15.0f,
                BackgroundColor = Color.Gray,
                SizeWidth = 500,
            };
            setHandle(field);
            return field;
        }

        public void setHandle(TextField field)
        {
            field.GrabHandleImage = "images/handle_down.png";

            var selectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage();
            selectionHandleImage.LeftImageUrl = "images/handle_downleft.png";
            selectionHandleImage.RightImageUrl = "images/handle_downright.png";
            field.SetSelectionHandleImage(selectionHandleImage);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
