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
            window.Add(view);



            TextLabel label = new TextLabel
            {
                Text = "<char-spacing value='5.0f'>Lorem ipsum dolor sit amet,</char-spacing> consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                MultiLine = true,
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 150,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                CharacterSpacing = -3.5f,
            };
            view.Add(label);



            TextField field = new TextField
            {
                Text = "<char-spacing value='-5.0f'>Lorem ipsum dolor sit amet, consectetur adipiscing elit</char-spacing>, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                EnableMarkup = true,

                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                CharacterSpacing = 30.1f,

                Ellipsis = true,
                EllipsisPosition = EllipsisPosition.Middle,
            };
            setHandle(field);
            view.Add(field);



            TextEditor editor = new TextEditor
            {
                Text = "<char-spacing value='-5.0f'>Lorem ipsum dolor sit amet,</char-spacing> consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 150,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                //CharacterSpacing = 20.5f,

                Ellipsis = true,
                EllipsisPosition = EllipsisPosition.Start,
            };
            setHandle(editor);
            view.Add(editor);



            TextEditor editorKOR = new TextEditor
            {
                Text = "<char-spacing value='-5.0f'>컴퓨터에서 인간과 같이 사고하고</char-spacing> 생각하고 학습하고 판단하는 <char-spacing value='-1.0f'>논리적인 방식을 사용하는 인간지능을 본 딴 고급 컴퓨터프로그램</char-spacing>을 말한다. 과거의 인공지능은 확정된 환경에서 유한개의 솔루션을 탐색하는 일이었다. 인공지능은 곧 논리였고, 이에 따른 탐색이었다. 하지만 현실은 환경도 매우 불확정적이고, 솔루션도 미리 유한개로 정해져있지 않은 경우가 많았다. 기계학습은 이런 문제들을 '데이터 중심의 판단'으로 풀어간다.",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 150,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                CharacterSpacing = 15.0f,

                Ellipsis = true,
                EllipsisPosition = EllipsisPosition.Middle,
            };
            setHandle(editorKOR);
            view.Add(editorKOR);



            TextEditor editorRTL = new TextEditor
            {
                Text = " مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم مرحبا بالعالم",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 150,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                CharacterSpacing = 20.0f,

                Ellipsis = true,
                EllipsisPosition = EllipsisPosition.Start,
            };
            setHandle(editorRTL);
            view.Add(editorRTL);
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
