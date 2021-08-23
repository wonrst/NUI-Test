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
            //view.LayoutDirection = ViewLayoutDirectionType.RTL;
            window.Add(view);
            
            // label
            var labelStart = NewTextLabel();
            labelStart.EllipsisPosition = EllipsisPosition.Start;
            view.Add(labelStart);

            var labelMiddle = NewTextLabel();
            labelMiddle.EllipsisPosition = EllipsisPosition.Middle;
            view.Add(labelMiddle);

            var labelEnd = NewTextLabel();
            labelEnd.EllipsisPosition = EllipsisPosition.End;
            view.Add(labelEnd);

            //var labelMiddleRTL = NewTextLabelRTL();
            //labelMiddleRTL.EllipsisPosition = EllipsisPosition.Middle;
            //view.Add(labelMiddleRTL);

            // editor
            var editorStart = NewTextEditor();
            editorStart.EllipsisPosition = EllipsisPosition.Start;
            view.Add(editorStart);

            var editorMiddle = NewTextEditor();
            editorMiddle.EllipsisPosition = EllipsisPosition.Middle;
            view.Add(editorMiddle);

            var editorEnd = NewTextEditor();
            editorEnd.EllipsisPosition = EllipsisPosition.End;
            view.Add(editorEnd);

            //var editorMiddleRTL = NewTextEditorRTL();
            //editorMiddleRTL.EllipsisPosition = EllipsisPosition.Middle;
            //view.Add(editorMiddleRTL);
        }

        public TextLabel NewTextLabel()
        {
            TextLabel label = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = 100,
                MultiLine = true,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                Ellipsis = true,
            };
            return label;
        }

        public TextLabel NewTextLabelRTL()
        {
            TextLabel label = new TextLabel
            {
                Text = " مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم  مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = 100,
                MultiLine = true,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                Ellipsis = true,
            };
            return label;
        }

        public TextEditor NewTextEditor()
        {
            TextEditor editor = new TextEditor
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = 100,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                Ellipsis = true,
            };
            setHandle(editor);

            return editor;
        }

        public TextEditor NewTextEditorRTL()
        {
            TextEditor editor = new TextEditor
            {
                Text = " مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم  مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = 100,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                Ellipsis = true,
            };
            setHandle(editor);

            return editor;
        }

        public void setHandle(TextField field)
        {
            field.GrabHandleImage = "images/handle_down.png";

            PropertyMap imageLeftMap = new PropertyMap();
            imageLeftMap.Add("filename", new PropertyValue("images/handle_downleft.png"));
            field.SelectionHandleImageLeft = imageLeftMap;

            PropertyMap imageRightMap = new PropertyMap();
            imageRightMap.Add("filename", new PropertyValue("images/handle_downright.png"));
            field.SelectionHandleImageRight = imageRightMap;
        }

        public void setHandle(TextEditor editor)
        {
            editor.GrabHandleImage = "images/handle_down.png";

            PropertyMap imageLeftMap = new PropertyMap();
            imageLeftMap.Add("filename", new PropertyValue("images/handle_downleft.png"));
            editor.SelectionHandleImageLeft = imageLeftMap;

            PropertyMap imageRightMap = new PropertyMap();
            imageRightMap.Add("filename", new PropertyValue("images/handle_downright.png"));
            editor.SelectionHandleImageRight = imageRightMap;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
