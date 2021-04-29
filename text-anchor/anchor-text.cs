using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace HelloWorldTest
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
            window.BackgroundColor = Color.Black;

            TextLabel label = new TextLabel("hello <a href='https://www.naver.com'>naver</a>thisisisi<b>kknd</b>Hello hihi <a href='https://google.com'>google</a>hihi <b>wonrst..</b>!!! <a href='www.tizen.org'>tizen</a> !!!");
            label.Position2D = new Position2D(10, 50);
            label.Size2D = new Size2D(400, 60);
            label.EnableMarkup = true;

            label.PointSize = 25.0f;
            label.BackgroundColor = Color.White;

            label.AnchorClicked += textLabelAnchorClicked;
/*
            label.AnchorClicked += (sender, e) =>
            {
                Tizen.Log.Info("NUI", (sender as TextLabel).Text + "\n");
                Tizen.Log.Info("NUI", e.Href + "\n");
                Tizen.Log.Info("NUI", e.Href.Length + "\n");
            };

*/
            window.Add(label);



            TextField field = new TextField();
            field.Text = "<a href='https://www.google.com'>google</a>";
            field.Position2D = new Position2D(10, 200);
            field.Size2D = new Size2D(400, 60);
            field.EnableMarkup = true;
            field.MaxLength = 100;

            field.PointSize = 25.0f;
            field.BackgroundColor = Color.White;

            field.AnchorClicked += textFieldAnchorClicked;

            window.Add(field);



            TextEditor editor = new TextEditor();
            //editor.Text = "<a href='https://www.google.com'>google</a>";
            editor.Text = "hello <a href='https://www.naver.com'>naver</a>thisisisi<b>kknd</b>Hello hihi <a href='https://google.com'>google</a>hihi <b>wonrst..</b>!!! <a href='www.tizen.org'>tizen</a> 2312329183210 wewkmkewmekwqmekwqmf wqemkqwemkwm <a>TEST</a> hell.... <a href='wonrst.com'>wonrst</a> qwerdf";
            editor.Position2D = new Position2D(10, 350);
            editor.Size2D = new Size2D(400, 300);
            editor.EnableMarkup = true;

            editor.PointSize = 25.0f;
            editor.BackgroundColor = Color.White;

            editor.AnchorClicked += textEditorAnchorClicked;
            
            window.Add(editor);
        }

        private void textLabelAnchorClicked(object sender, AnchorClickedEventArgs e)
        {
            Tizen.Log.Error("NUI", "LABEL Anchor TEXT[" + (sender as TextLabel).Text + "] \n");
            Tizen.Log.Error("NUI", "LABEL Anchor HREF[" + e.Href + "] \n");
            Tizen.Log.Error("NUI", "LABEL Anchor HREF Len[" + e.Href.Length + "] \n");
        }

        private void textFieldAnchorClicked(object sender, AnchorClickedEventArgs e)
        {
            Tizen.Log.Error("NUI", "FIELD Anchor TEXT[" + (sender as TextField).Text + "] \n");
            Tizen.Log.Error("NUI", "FIELD Anchor HREF[" + e.Href + "] \n");
            Tizen.Log.Error("NUI", "FIELD Anchor HREF Len[" + e.Href.Length + "] \n");
        }

        private void textEditorAnchorClicked(object sender, AnchorClickedEventArgs e)
        {
            Tizen.Log.Error("NUI", "EDITOR Anchor TEXT[" + (sender as TextEditor).Text + "] \n");
            Tizen.Log.Error("NUI", "EDITOR Anchor HREF[" + e.Href + "] \n");
            Tizen.Log.Error("NUI", "EDITOR Anchor HREF Len[" + e.Href.Length + "] \n");
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
