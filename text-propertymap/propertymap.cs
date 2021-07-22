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


            // Normal label
            TextLabel label = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 40,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(label);


            PropertyMap fontStyle = new PropertyMap();
            fontStyle["width"] = new PropertyValue("expanded");
            fontStyle["weight"] = new PropertyValue("bold");
            fontStyle["slant"] = new PropertyValue("italic");
            label.FontStyle = fontStyle;

            label.FontStyle["width"].Get(out string width);
            label.FontStyle["weight"].Get(out string weight);
            label.FontStyle["slant"].Get(out string slant);


            PropertyMap underline = new PropertyMap();
            underline.Add("enable", new PropertyValue(true));
            underline.Add("color", new PropertyValue(Color.Blue));
            underline.Add("height", new PropertyValue(5.0f));
            label.Underline = underline;


            Color underlineColor = new Color();
            label.Underline["enable"].Get(out bool underlineEnabled);
            label.Underline["color"].Get(underlineColor);
            label.Underline["height"].Get(out float underlineHeight);


            PropertyMap shadow = new PropertyMap();
            shadow.Add("color", new PropertyValue(Color.Red));
            shadow.Add("offset", new PropertyValue(new Vector2(5, 5)));
            shadow.Add("blurRadius", new PropertyValue(5.0f));
            label.Shadow = shadow;


            Color shadowColor = new Color();
            Vector2 shadowOffset = new Vector2();
            label.Shadow["color"].Get(shadowColor);
            label.Shadow["offset"].Get(shadowOffset);
            label.Shadow["blurRadius"].Get(out float shadowRadius);


            PropertyMap outline = new PropertyMap();
            outline.Add("color", new PropertyValue(Color.Yellow));
            outline.Add("width", new PropertyValue(2.0f));
            label.Outline = outline;

            Color outlineColor = new Color();
            label.Outline["color"].Get(outlineColor);
            label.Outline["width"].Get(out float outlineWidth);


            // Normal field
            TextField field = new TextField
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            setHandle(field);
            view.Add(field);

            PropertyMap placeholder = new PropertyMap();
            placeholder["text"] = new PropertyValue("placeholder text");
            placeholder["textFocused"] = new PropertyValue("placeholder text focused");
            placeholder["color"] = new PropertyValue(Color.Red);
            placeholder["fontFamily"] = new PropertyValue("Ubuntu Mono");
            placeholder["fontStyle"] = new PropertyValue(fontStyle);
            placeholder["pointSize"] = new PropertyValue(25.0f);
            //placeholder["pixelSize"] = new PropertyValue(10.0f);
            placeholder["ellipsis"] = new PropertyValue(true);
            field.Placeholder = placeholder;

            

            field.Placeholder["text"].Get(out string pText);
            field.Placeholder["textFocused"]?.Get(out string pTextFocused);



            Color pColor = new Color();
            field.Placeholder["color"].Get(pColor);

            field.Placeholder["fontFamily"].Get(out string pfamily);

            PropertyMap pFontStyle = new PropertyMap();
            field.Placeholder["fontStyle"].Get(pFontStyle);

            field.Placeholder["pointSize"].Get(out float pPointSize);

//            field.Placeholder["pixelSize"].Get(out float pPixelSize);
            field.Placeholder["ellipsis"].Get(out bool pEllipsis);


            InputMethod inputMethod = new InputMethod();
            inputMethod.PanelLayout = InputMethod.PanelLayoutType.Password;
            field.InputMethodSettings = inputMethod.OutputMap;

            InputMethod.PanelLayoutType panelEnumType;
            field.InputMethodSettings["PANEL_LAYOUT"].Get(out int panelType);
            panelEnumType = (InputMethod.PanelLayoutType)panelType;


            PropertyMap hiddenMap = new PropertyMap();
            hiddenMap[HiddenInputProperty.Mode] = new PropertyValue((int)HiddenInputModeType.ShowLastCharacter);
            hiddenMap[HiddenInputProperty.ShowLastCharacterDuration] = new PropertyValue(500);
            field.HiddenInputSettings = hiddenMap;

            HiddenInputModeType hiddenEnumType;
            field.HiddenInputSettings[HiddenInputProperty.Mode].Get(out int hiddenType);
            field.HiddenInputSettings[HiddenInputProperty.ShowLastCharacterDuration].Get(out int hiddenDuration);
            hiddenEnumType = (HiddenInputModeType)hiddenType;


            PropertyMap selLeft = new PropertyMap();
            selLeft["filename"] = new PropertyValue("selection left");
            field.SelectionHandleImageLeft = selLeft;

            PropertyMap selRight = new PropertyMap();
            selRight["filename"] = new PropertyValue("selection right");
            field.SelectionHandleImageRight = selRight;

            field.SelectionHandleImageLeft["filename"].Get(out string handleLeft);
            field.SelectionHandleImageRight["filename"].Get(out string handleRight);



            // Need to implement layout editor
            TextEditor editor = new TextEditor
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                // Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                EnableMarkup = true,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                HorizontalAlignment = HorizontalAlignment.Begin,   // there is no VerticalAlignment in TextEditor
            };
            setHandle(editor);

            view.Add(editor);

            PropertyMap eplaceholder = new PropertyMap();
            eplaceholder["text"] = new PropertyValue("placeholder text");
            eplaceholder["textFocused"] = new PropertyValue("placeholder text focused");
            eplaceholder["color"] = new PropertyValue(Color.Red);
            eplaceholder["fontFamily"] = new PropertyValue("Ubuntu Mono");
            eplaceholder["fontStyle"] = new PropertyValue(fontStyle);
            eplaceholder["pointSize"] = new PropertyValue(25.0f);
            //placeholder["pixelSize"] = new PropertyValue(10.0f);
            eplaceholder["ellipsis"] = new PropertyValue(true);
            editor.Placeholder = eplaceholder;



            editor.Placeholder["text"].Get(out string epText);
            editor.Placeholder["textFocused"].Get(out string epTextFocused);

            Color epColor = new Color();
            editor.Placeholder["color"].Get(epColor);

            editor.Placeholder["fontFamily"].Get(out string epfamily);

            PropertyMap epFontStyle = new PropertyMap();
            editor.Placeholder["fontStyle"].Get(epFontStyle);

            editor.Placeholder["pointSize"].Get(out float epPointSize);
            //editor.Placeholder["pixelSize"].Get(out float epPixelSize);
            editor.Placeholder["ellipsis"].Get(out bool epEllipsis);

            epFontStyle["width"].Get(out string epWidth);
            epFontStyle["weight"].Get(out string epWeight);
            epFontStyle["slant"].Get(out string epSlant);


            InputMethod einputMethod = new InputMethod();
            einputMethod.PanelLayout = InputMethod.PanelLayoutType.Password;
            editor.InputMethodSettings = einputMethod.OutputMap;

            InputMethod.PanelLayoutType epanelEnumType;
            editor.InputMethodSettings["PANEL_LAYOUT"].Get(out int epanelType);
            epanelEnumType = (InputMethod.PanelLayoutType)epanelType;


            PropertyMap eselLeft = new PropertyMap();
            eselLeft["filename"] = new PropertyValue("selection left");
            editor.SelectionHandleImageLeft = eselLeft;

            PropertyMap eselRight = new PropertyMap();
            eselRight["filename"] = new PropertyValue("selection right");
            editor.SelectionHandleImageRight = eselRight;

            editor.SelectionHandleImageLeft["filename"].Get(out string ehandleLeft);
            editor.SelectionHandleImageRight["filename"].Get(out string ehandleRight);


            Button button = new Button
            {
                Text = "label",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Label Font Style : " + width + " " + weight + " " + slant + " \n");

                Tizen.Log.Error("NUI", "Label Underline : " + underlineEnabled + " " + underlineColor.R + underlineColor.G + underlineColor.B + " " + underlineHeight + " \n");
                
                Tizen.Log.Error("NUI", "Label Shadow : " + shadowColor.R + shadowColor.G + shadowColor.B + " " + shadowOffset.X + shadowOffset.Y + " " + shadowRadius + " \n");

                Tizen.Log.Error("NUI", "Label Outline : " + outlineColor.R + outlineColor.G + outlineColor.B + " " + outlineWidth + " \n");
            };

            Button button2 = new Button
            {
                Text = "field",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(button2);
            button2.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Field text : " + pText + " \n");
                
                Tizen.Log.Error("NUI", "Field textFocused : " + pTextFocused + " \n");
                Tizen.Log.Error("NUI", "Field color : " + pColor.R + "," + pColor.G + "," + pColor.B + " \n");
                
                Tizen.Log.Error("NUI", "Field fontFamily : " + pfamily + " \n");
                Tizen.Log.Error("NUI", "Field fontStyle : " + pWidth + " " + pWeight + " " + pSlant + " \n");
                Tizen.Log.Error("NUI", "Field pointSize : " + pPointSize + " \n");
                //Tizen.Log.Error("NUI", "Field pixelSize : " + pPixelSize + " \n");
                Tizen.Log.Error("NUI", "Field ellipsis : " + pEllipsis + " \n");


                Tizen.Log.Error("NUI", "Field inputMethod panel type " + panelEnumType + " \n");


                Tizen.Log.Error("NUI", "Field hiddenInput mode " + hiddenEnumType + " \n");
                Tizen.Log.Error("NUI", "Field hiddenInput ShowLastCharacterDuration " + hiddenDuration + " \n");


                Tizen.Log.Error("NUI", "Field handle left " + handleLeft + " \n");
                Tizen.Log.Error("NUI", "Field handle right " + handleRight + " \n");
            };

            Button button3 = new Button
            {
                Text = "editor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
            };
            view.Add(button3);
            button3.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Editor text : " + epText + " \n");
                Tizen.Log.Error("NUI", "Editor textFocused : " + epTextFocused + " \n");
                Tizen.Log.Error("NUI", "Editor color : " + epColor.R + "," + epColor.G + "," + epColor.B + " \n");
                Tizen.Log.Error("NUI", "Editor fontFamily : " + epfamily + " \n");
                Tizen.Log.Error("NUI", "Editor fontStyle : " + epWidth + " " + epWeight + " " + epSlant + " \n");
                Tizen.Log.Error("NUI", "Editor pointSize : " + epPointSize + " \n");
                //Tizen.Log.Error("NUI", "Editor pixelSize : " + epPixelSize + " \n");
                Tizen.Log.Error("NUI", "Editor ellipsis : " + epEllipsis + " \n");


                Tizen.Log.Error("NUI", "Editor inputMethod panel type " + epanelEnumType + " \n");


                Tizen.Log.Error("NUI", "Editor handle left " + ehandleLeft + " \n");
                Tizen.Log.Error("NUI", "Editor handle right " + ehandleRight + " \n");
            };
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
