using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace TextComponentsTest
{
    class Example : NUIApplication
    {
        public string[] strArray =
        {
            "こんにちは", // 일본어  
            "Bonjour", // 프랑스어  
            "Hola", // 스페인어  
            "Ciao", // 이탈리아어  
            "Guten Tag", // 독일어  
            "Hello", // 영어  
            "你好", // 중국어  
            "Привет", // 러시아어  
            "Γεια σου", // 그리스어  
            "Selamat siang", // 인도네시아어  
            "Merhaba", // 터키어  
            "Hej", // 스웨덴어  
            "Hallo", // 네덜란드어  
            "Ahoj", // 체코어  
            "Hejsa", // 덴마크어  
            "Szia", // 헝가리어  
            "Buna ziua", // 루마니아어  
            "Dobrý den", // 슬로바키아어  
            "Labdien", // 라트비아어  
            "Laba diena", // 리투아니아어  
            "Sveiki", // 리투아니아어  
            "Moi", // 노르웨이어  
            "Hei", // 핀란드어  
            "Tere", // 에스토니아어  
            "Labas", // 벨라루스어  
            "Zdravím", // 슬로베니아어  
            "Pozdrav", // 크로아티아어  
            "İyi günler", // 터키어  
            "Dobar dan", // 세르비아어  
            "Bună ziua", // 몰도바어  
            "Добрый день", // 우크라이나어  
            "Здравейте", // 불가리아어  
            "Здраво", // 마케도니아어  
            "Привет", // 몬테네그로어  
            "Здравствуйте", // 타지크어  
            "سلام", // 페르시아어
            "こんにちは、世界！", // 일본어  
            "Bonjour le monde!", // 프랑스어  
            "¡Hola mundo!", // 스페인어  
            "Ciao mondo!", // 이탈리아어  
            "Guten Tag Welt!", // 독일어  
            "Hello world!", // 영어  
            "你好，世界！", // 중국어  
            "Привет мир!", // 러시아어  
            "Γεια σου κόσμος!", // 그리스어  
            "Selamat siang dunia!", // 인도네시아어  
            "Merhaba dünya!", // 터키어  
            "Hej världen!", // 스웨덴어  
            "Hallo wereld!", // 네덜란드어  
            "Ahoj světe!", // 체코어  
            "Hejsa verden!", // 덴마크어  
            "Szia világ!", // 헝가리어  
            "Buna ziua lume!", // 루마니아어  
            "Dobrý den svety!", // 슬로바키아어  
            "Labdien pasaule!", // 라트비아어  
            "Laba diena pasaulē!", // 리투아니아어  
            "Sveiki pasauly!", // 리투아니아어  
            "Moi maailma!", // 노르웨이어  
            "Hei maailma!", // 핀란드어  
            "Tere maailm!", // 에스토니아어  
            "Labas pasauls!", // 벨라루스어  
            "Zdravím svet!", // 슬로베니아어  
            "Pozdrav svijetu!", // 크로아티아어  
            "İyi günler dünya!", // 터키어  
            "Dobar dan svijetu!", // 세르비아어  
            "Bună ziua lumine!", // 몰도바어  
            "Добрый день мир!", // 우크라이나어  
            "Здравейте свят!", // 불가리아어  
            "Здраво свету!", // 마케도니아어  
            "Привет свет!", // 몬테네그로어  
            "Здравствуйте мир!", // 타지크어  
            "سلام دنیا", // 페르시아어  
            "こんにちは、素晴らしい世界！", // 일본어  
            "Bonjour, magnifique monde!", // 프랑스어  
            "¡Hola maravilloso mundo!", // 스페인어  
            "Ciao meraviglioso mondo!", // 이탈리아어  
            "Guten Tag wunderbare Welt!", // 독일어  
            "Hello wonderful world!", // 영어  
            "你好，美丽的世界！", // 중국어  
            "Привет замечательный мир!", // 러시아어  
            "Γεια σου θαυμάσιε μέρη!", // 그리스어  
            "Selamat siang indah dunia!", // 인도네시아어  
            "Merhaba harika dünya!", // 터키어  
            "Hej underbar värld!", // 스웨덴어  
            "Hallo prachtige wereld!", // 네덜란드어  
            "Ahoj úžasný svět!", // 체코어  
            "Hejsa vidunderlige verden!", // 덴마크어  
            "Szia csodálatos világ!", // 헝가리어  
            "Buna ziua minunat lume!", // 루마니아어  
            "Dobrý den nádherný svet!", // 슬로바키아어  
            "Labdien brīnišķīga pasaule!", // 라트비아어  
            "Laba diena brīnišķīgs pasaulē!", // 리투아니아어  
            "Sveiki nuostabus pasauly!", // 리투아니아어  
            "Moi kaunis maailma!", // 노르웨이어  
            "Hei fantastisk verden!", // 핀란드어  
            "Tere imelik maailm!", // 에스토니아어  
            "Labas brīnišķīgi pasauls!", // 벨라루스어  
            "Zdravím nádherný svet!", // 슬로베니아어  
            "Pozdrav prekrasan svijetu!", // 크로아티아어  
            "İyi günler harika dünya!", // 터키어  
            "Dobar dan divan svijetu!", // 세르비아어  
            "Bună ziua minunată lumine!", // 몰도바어  
            "Добрый день прекрасный мир!", // 우크라이나어  
            "Здравейте великолепен свят!", // 불가리아어  
            "Здраво диван свету!", // 마케도니아어  
            "Привет чудесный мир!", // 몬테네그로어  
            "Здравствуйте великий мир!", // 타지크어  
            "سلام زیبایی دنیا", // 페르시아어  
        };

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
                    CellPadding = new Size2D(5, 5),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);

            Button button = new Button
            {
                Text = "Calc Natural Size",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(button);

            var widthLabel = NewTextLabel("max width");
            view.Add(widthLabel);

            button.Clicked += (s, e) =>
            {
                var watch = new Stopwatch();
                watch.Start();

                var calcLabel = NewTextLabel("");

                float max = 0.0f;
                for (int i = 0 ; i < strArray.Length ; i ++)
                {
                    calcLabel.Text = strArray[i];
                    float width = calcLabel.NaturalSize.Width;
                    Tizen.Log.Error("NUI", $"RYU - Width:{width}, Text:{(calcLabel.Text)} \n");

                    max = width > max ? width : max;
                }
                
                watch.Stop();

                widthLabel.Text = "" + max;
                Tizen.Log.Error("NUI", $"RYU - Lang count:{strArray.Length}, Max width:{max}, Time:{watch.ElapsedMilliseconds}ms \n");
            };


            Button clear = new Button
            {
                Text = "Clear",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(clear);
            clear.Clicked += (s, e) =>
            {
                widthLabel.Text = "";
            };


            Button buttonLabel = new Button
            {
                Text = "Add label",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            view.Add(buttonLabel);

            buttonLabel.Clicked += (s, e) =>
            {
                var watch = new Stopwatch();
                watch.Start();

                float max = 0.0f;
                for (int i = 0 ; i < strArray.Length ; i ++)
                {
                    var label = NewTextLabel(strArray[i]);
                    view.Add(label);
                    float width = label.NaturalSize.Width;
                    Tizen.Log.Error("NUI", $"RYU - Width:{width}, Text:{(label.Text)} \n");

                    max = width > max ? width : max;
                }
                
                watch.Stop();

                widthLabel.Text = "" + max;
                Tizen.Log.Error("NUI", $"RYU - Lang count:{strArray.Length}, Max width:{max}, Time:{watch.ElapsedMilliseconds}ms \n");
            };
        }

        public TextLabel NewTextLabel(string text)
        {
            TextLabel label = new TextLabel
            {
                Text = text,
                PointSize = 20.0f,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.White,
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
