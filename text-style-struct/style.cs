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

            // Label title
            TextLabel titleLabel = new TextLabel
            {
                Text = " /* Text Label PropertyMap Test */ ",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 12.0f,
                BackgroundColor = Color.CadetBlue,
            };
            view.Add(titleLabel);



            // FontStyle
            TextLabel fontStyleLabel = new TextLabel
            {
                Text = "FontStyle Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };

            fontStyleLabel.FontFamily = "BreezeSans";
            view.Add(fontStyleLabel);

            var fontStyle = new Tizen.NUI.Text.FontStyle();
            fontStyle.Width = FontWidthType.Condensed;
            fontStyle.Weight = FontWeightType.Light;
            fontStyle.Slant = FontSlantType.Italic;
            fontStyleLabel.SetFontStyle(fontStyle);

            Tizen.Log.Error("NUI", "width : " + fontStyle.Width + "\n");
            Tizen.Log.Error("NUI", "weight : " + fontStyle.Weight + "\n");
            Tizen.Log.Error("NUI", "slant : " + fontStyle.Slant + "\n");

            Tizen.NUI.Text.FontStyle getStyle = fontStyleLabel.GetFontStyle();
            Tizen.Log.Error("NUI", "get width : " + getStyle.Width + "\n");
            Tizen.Log.Error("NUI", "get weight : " + getStyle.Weight + "\n");
            Tizen.Log.Error("NUI", "get slant : " + getStyle.Slant + "\n");


            TextField fontStyleField = new TextField
            {
                Text = "FontStyle TextField",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };

            fontStyleField.FontFamily = "BreezeSans";
            view.Add(fontStyleField);

            fontStyleField.SetFontStyle(fontStyle);

            getStyle = fontStyleField.GetFontStyle();
            Tizen.Log.Error("NUI", "get field width : " + getStyle.Width + "\n");
            Tizen.Log.Error("NUI", "get field weight : " + getStyle.Weight + "\n");
            Tizen.Log.Error("NUI", "get field slant : " + getStyle.Slant + "\n");

            
            TextEditor fontStyleEditor = new TextEditor
            {
                Text = "FontStyle TextEditor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };

            fontStyleEditor.FontFamily = "BreezeSans";
            view.Add(fontStyleEditor);

            fontStyleEditor.SetFontStyle(fontStyle);

            getStyle = fontStyleEditor.GetFontStyle();
            Tizen.Log.Error("NUI", "get editor width : " + getStyle.Width + "\n");
            Tizen.Log.Error("NUI", "get editor weight : " + getStyle.Weight + "\n");
            Tizen.Log.Error("NUI", "get editor slant : " + getStyle.Slant + "\n");


            var button = new Button
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 15,
            };
            view.Add(button);

            var style = new Tizen.NUI.Text.FontStyle();
            style.Width = FontWidthType.Expanded;
            style.Weight = FontWeightType.ExtraBold;
            style.Slant = FontSlantType.Normal;

            button.Clicked += (s, e) =>
            {
                fontStyleLabel.SetFontStyle(style);
                fontStyleField.SetFontStyle(style);
                fontStyleEditor.SetFontStyle(style);
                
                Tizen.Log.Error("NUI", "set width : " + fontStyleLabel.GetFontStyle().Width + "\n");
                Tizen.Log.Error("NUI", "set weight : " + fontStyleField.GetFontStyle().Weight + "\n");
                Tizen.Log.Error("NUI", "set slant : " + fontStyleEditor.GetFontStyle().Slant + "\n");
            };

            fontStyleField.TextChanged += (s, e) =>
            {
                var inputStyle = new Tizen.NUI.Text.FontStyle();
                inputStyle.Width = FontWidthType.Expanded;
                inputStyle.Weight = FontWeightType.Bold;
                inputStyle.Slant = FontSlantType.None;
                fontStyleField.SetInputFontStyle(inputStyle);

                Tizen.Log.Error("NUI", "set input field width : " + fontStyleField.GetInputFontStyle().Width + "\n");
                Tizen.Log.Error("NUI", "set input field width : " + fontStyleField.GetInputFontStyle().Weight + "\n");
                Tizen.Log.Error("NUI", "set input field width : " + fontStyleField.GetInputFontStyle().Slant + "\n");
            };

            fontStyleEditor.TextChanged += (s, e) =>
            {
                var inputStyle = new Tizen.NUI.Text.FontStyle();
                inputStyle.Width = FontWidthType.Expanded;
                inputStyle.Weight = FontWeightType.Bold;
                inputStyle.Slant = FontSlantType.None;
                fontStyleEditor.SetInputFontStyle(inputStyle);

                Tizen.Log.Error("NUI", "set input editor width : " + fontStyleEditor.GetInputFontStyle().Width + "\n");
                Tizen.Log.Error("NUI", "set input editor width : " + fontStyleEditor.GetInputFontStyle().Weight + "\n");
                Tizen.Log.Error("NUI", "set input editor width : " + fontStyleEditor.GetInputFontStyle().Slant + "\n");
            };


            // Underline
            TextLabel underlineLabel = new TextLabel
            {
                Text = "Underline Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };

            view.Add(underlineLabel);

            var underline = new Tizen.NUI.Text.Underline();
            underline.Enable = true;
            //underline.Color = new Color("#3498DB");
            //underline.Height = 5.0f;

            Tizen.Log.Error("NUI", "struct enable : " + underline.Enable + "\n");
            Tizen.Log.Error("NUI", "struct height : " + underline.Height + "\n");
            underlineLabel.SetUnderline(underline);

            Tizen.Log.Error("NUI", "get struct enable : " + underlineLabel.GetUnderline().Enable + "\n");
            Tizen.Log.Error("NUI", "get struct color : " + underlineLabel.GetUnderline().Color.R + ", " + underlineLabel.GetUnderline().Color.G + ", " + underlineLabel.GetUnderline().Color.B + ", " + underlineLabel.GetUnderline().Color.A + "\n");
            Tizen.Log.Error("NUI", "get struct height : " + underlineLabel.GetUnderline().Height + "\n");


            // Underline
            TextField underlineField = new TextField
            {
                Text = "Underline Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(underlineField);

            underlineField.SetUnderline(underline);

            Tizen.Log.Error("NUI", "get field enable : " + underlineField.GetUnderline().Enable + "\n");
            Tizen.Log.Error("NUI", "get field color : " + underlineField.GetUnderline().Color.R + ", " + underlineField.GetUnderline().Color.G + ", " + underlineField.GetUnderline().Color.B + ", " + underlineField.GetUnderline().Color.A + "\n");
            Tizen.Log.Error("NUI", "get field height : " + underlineField.GetUnderline().Height + "\n");

            // Underline
            TextEditor underlineEditor = new TextEditor
            {
                Text = "Underline Editor ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };
            view.Add(underlineEditor);

            underlineEditor.SetUnderline(underline);

            Tizen.Log.Error("NUI", "get editor enable : " + underlineEditor.GetUnderline().Enable + "\n");
            Tizen.Log.Error("NUI", "get editor color : " + underlineEditor.GetUnderline().Color.R + ", " + underlineEditor.GetUnderline().Color.G + ", " + underlineEditor.GetUnderline().Color.B + ", " + underlineEditor.GetUnderline().Color.A + "\n");
            Tizen.Log.Error("NUI", "get editor height : " + underlineEditor.GetUnderline().Height + "\n");


            // Shadow
            TextLabel shadowLabel = new TextLabel
            {
                Text = "Shadow Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(shadowLabel);

            var shadowStruct = new Tizen.NUI.Text.Shadow();
            shadowStruct.BlurRadius = 5.0f;
            shadowStruct.Color = Color.Red;
            shadowStruct.Offset = new Vector2(3, 3);
            shadowLabel.SetShadow(shadowStruct);

            Tizen.Log.Error("NUI", "get shadow label color : " + shadowLabel.GetShadow().Color.R + ", " + shadowLabel.GetShadow().Color.G + ", " + shadowLabel.GetShadow().Color.B + ", " + shadowLabel.GetShadow().Color.A + "\n");
            Tizen.Log.Error("NUI", "get shadow label offset : " + shadowLabel.GetShadow().Offset.X + ", " + shadowLabel.GetShadow().Offset.Y + "\n");
            Tizen.Log.Error("NUI", "get shadow label blurRadius : " + shadowLabel.GetShadow().BlurRadius + "\n");

            // Shadow
            TextField shadowField = new TextField
            {
                Text = "Shadow Field ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };
            view.Add(shadowField);
            shadowField.SetShadow(shadowStruct);

            Tizen.Log.Error("NUI", "get shadow field color : " + shadowField.GetShadow().Color.R + ", " + shadowField.GetShadow().Color.G + ", " + shadowField.GetShadow().Color.B + ", " + shadowField.GetShadow().Color.A + "\n");
            Tizen.Log.Error("NUI", "get shadow field offset : " + shadowField.GetShadow().Offset.X + ", " + shadowField.GetShadow().Offset.Y + "\n");
            Tizen.Log.Error("NUI", "get shadow field blurRadius : " + shadowField.GetShadow().BlurRadius + "\n");

            // Shadow
            TextEditor shadowEditor = new TextEditor
            {
                Text = "Shadow Editor ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };
            view.Add(shadowEditor);
            shadowEditor.SetShadow(shadowStruct);

            Tizen.Log.Error("NUI", "get shadow editor color : " + shadowEditor.GetShadow().Color.R + ", " + shadowEditor.GetShadow().Color.G + ", " + shadowEditor.GetShadow().Color.B + ", " + shadowEditor.GetShadow().Color.A + "\n");
            Tizen.Log.Error("NUI", "get shadow editor offset : " + shadowEditor.GetShadow().Offset.X + ", " + shadowEditor.GetShadow().Offset.Y + "\n");
            Tizen.Log.Error("NUI", "get shadow editor blurRadius : " + shadowEditor.GetShadow().BlurRadius + "\n");


            // Outline
            TextLabel outlineLabel = new TextLabel
            {
                Text = "Outline Lorem ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            view.Add(outlineLabel);

            var outline = new Tizen.NUI.Text.Outline();
            outline.Width = 2.0f;
            outline.Color = new Color("#45B39D");
            outlineLabel.SetOutline(outline);
            
            Tizen.Log.Error("NUI", "out color : " + outlineLabel.GetOutline().Color.R + ", " + outlineLabel.GetOutline().Color.G + ", " + outlineLabel.GetOutline().Color.B + ", " + outlineLabel.GetOutline().Color.A + "\n");
            Tizen.Log.Error("NUI", "out width : " + outlineLabel.GetOutline().Width + "\n");

            // Outline
            TextField outlineField = new TextField
            {
                Text = "Outline Field ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };
            view.Add(outlineField);
            outlineField.SetOutline(outline);

            Tizen.Log.Error("NUI", "out field color : " + outlineField.GetOutline().Color.R + ", " + outlineField.GetOutline().Color.G + ", " + outlineField.GetOutline().Color.B + ", " + outlineField.GetOutline().Color.A + "\n");
            Tizen.Log.Error("NUI", "out field width : " + outlineField.GetOutline().Width + "\n");

            // Outline
            TextEditor outlineEditor = new TextEditor
            {
                Text = "Outline Editor ipsum dolor",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };
            view.Add(outlineEditor);
            outlineEditor.SetOutline(outline);

            Tizen.Log.Error("NUI", "out field color : " + outlineEditor.GetOutline().Color.R + ", " + outlineEditor.GetOutline().Color.G + ", " + outlineEditor.GetOutline().Color.B + ", " + outlineEditor.GetOutline().Color.A + "\n");
            Tizen.Log.Error("NUI", "out field width : " + outlineEditor.GetOutline().Width + "\n");


            // textFitLabel
            TextLabel textFitLabel = new TextLabel
            {
                Text = "Text Fit Label...!!",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                //HeightSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = 50,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };
            view.Add(textFitLabel);

            var textFit = new Tizen.NUI.Text.TextFit();
            textFit.Enable = true;
            textFit.MinSize = 30.0f;
            //textFit.MaxSize = 200.0f;
            //textFit.StepSize = 20.0f;
            //textFit.FontSizeType = FontSizeType.PixelSize;
            textFitLabel.SetTextFit(textFit);

            Tizen.Log.Error("NUI", "fit struct enable : " + textFit.Enable + "\n");
            Tizen.Log.Error("NUI", "fit struct minSize : " + textFit.MinSize + "\n");
            Tizen.Log.Error("NUI", "fit struct maxSize : " + textFit.MaxSize + "\n");
            Tizen.Log.Error("NUI", "fit struct stepSize : " + textFit.StepSize + "\n");
            Tizen.Log.Error("NUI", "fit struct fontSizeType : " + textFit.FontSizeType + "\n");

            Tizen.Log.Error("NUI", "fit get enable : " + textFitLabel.GetTextFit().Enable + "\n");
            Tizen.Log.Error("NUI", "fit get minSize : " + textFitLabel.GetTextFit().MinSize + "\n");
            Tizen.Log.Error("NUI", "fit get maxSize : " + textFitLabel.GetTextFit().MaxSize + "\n");
            Tizen.Log.Error("NUI", "fit get stepSize : " + textFitLabel.GetTextFit().StepSize + "\n");
            Tizen.Log.Error("NUI", "fit get fontSizeType : " + textFitLabel.GetTextFit().FontSizeType + "\n");



            // placeholder
            TextField placeholderField = new TextField
            {
                //PlaceholderText = "Hello..!!",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                PlaceholderText = "This is placeholder",
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                FontFamily = "Serif",
            };
            view.Add(placeholderField);
            placeholderField.SetFontStyle(new Tizen.NUI.Text.FontStyle()
            {
                Width = FontWidthType.Expanded,
                Weight = FontWeightType.ExtraLight,
                Slant = FontSlantType.Italic,
            });

            placeholderField.Placeholder = new PropertyMap();

            Tizen.Log.Error("NUI", "1 Placeholder Text : " + placeholderField.PlaceholderText + "\n");

            placeholderField.PlaceholderText = "hello place holder";

            var placeholder = new Tizen.NUI.Text.Placeholder();
            placeholder.Text = "placeholder text";
            placeholder.TextFocused = "placeholder TextFocused";
            placeholder.Color = new Color("#45B39D");
            placeholder.FontFamily = "BreezeSans";
            placeholder.FontStyle = new Tizen.NUI.Text.FontStyle()
            {
                Width = FontWidthType.Expanded,
                Weight = FontWeightType.ExtraLight,
                Slant = FontSlantType.Italic,
            };
            placeholder.PointSize = 15.0f;
            //placeholder.PixelSize = 50.0f;
            placeholder.Ellipsis = true;
            placeholderField.SetPlaceholder(placeholder);

            placeholderField.PlaceholderText = "HI place";
            

            Tizen.Log.Error("NUI", "Text " + placeholderField.GetPlaceholder().Text + "\n");
            Tizen.Log.Error("NUI", "TextFocused " + placeholderField.GetPlaceholder().TextFocused + "\n");
            Tizen.Log.Error("NUI", "Color " + placeholderField.GetPlaceholder().Color.R + ", " + placeholderField.GetPlaceholder().Color.G + ", " + placeholderField.GetPlaceholder().Color.B + ", " + placeholderField.GetPlaceholder().Color.A + "\n");
            Tizen.Log.Error("NUI", "FontFamily " + placeholderField.GetPlaceholder().FontFamily + "\n");
            Tizen.Log.Error("NUI", "FontStyle " + placeholderField.GetPlaceholder().FontStyle?.Width + " " + placeholderField.GetPlaceholder().FontStyle?.Weight + " " + placeholderField.GetPlaceholder().FontStyle?.Slant + "\n");
            Tizen.Log.Error("NUI", "PointSize " + placeholderField.GetPlaceholder().PointSize + "\n");
            Tizen.Log.Error("NUI", "PixelSize " + placeholderField.GetPlaceholder().PixelSize + "\n");
            Tizen.Log.Error("NUI", "Ellipsis " + placeholderField.GetPlaceholder().Ellipsis + "\n");

            Tizen.Log.Error("NUI", "2 Placeholder Text : " + placeholderField.PlaceholderText + "\n");
            Tizen.Log.Error("NUI", "3 Placeholder Text : " + placeholderField.PlaceholderText + "\n");
            Tizen.Log.Error("NUI", "4 Placeholder Text : " + placeholderField.PlaceholderText + "\n");
            Tizen.Log.Error("NUI", "5 Placeholder Text : " + placeholderField.PlaceholderText + "\n");

            Tizen.Log.Error("NUI", "LAST Placeholder Text : " + placeholderField.PlaceholderText + "\n");
            Tizen.Log.Error("NUI", "LAST Struct Text " + placeholderField.GetPlaceholder().Text + "\n");


            var btnPlace = new Button
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 15,
            };
            btnPlace.Clicked += (s, e) =>
            {
                Tizen.Log.Error("NUI", "Placeholder Text : " + placeholderField.PlaceholderText + "\n");
                Tizen.Log.Error("NUI", "Placeholder Struct Text " + placeholderField.GetPlaceholder().Text + "\n");

                PropertyMap map = placeholderField.Placeholder;
            };
            view.Add(btnPlace);

            
            // placeholder text editor
            TextEditor placeholderEditor = new TextEditor
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 50,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
                FontFamily = "Ubuntu Mono",
            };
            view.Add(placeholderEditor);

            placeholderEditor.SetPlaceholder(placeholder);

            Tizen.Log.Error("NUI", "edit Text " + placeholderEditor.GetPlaceholder().Text + "\n");
            Tizen.Log.Error("NUI", "edit TextFocused " + placeholderEditor.GetPlaceholder().TextFocused + "\n");
            Tizen.Log.Error("NUI", "edit Color " + placeholderEditor.GetPlaceholder().Color.R + ", " + placeholderEditor.GetPlaceholder().Color.G + ", " + placeholderEditor.GetPlaceholder().Color.B + ", " + placeholderEditor.GetPlaceholder().Color.A + "\n");
            Tizen.Log.Error("NUI", "edit FontFamily " + placeholderEditor.GetPlaceholder().FontFamily + "\n");
            Tizen.Log.Error("NUI", "edit FontStyle " + placeholderEditor.GetPlaceholder().FontStyle?.Width + " " + placeholderEditor.GetPlaceholder().FontStyle?.Weight + " " + placeholderEditor.GetPlaceholder().FontStyle?.Slant + "\n");
            Tizen.Log.Error("NUI", "edit PointSize " + placeholderEditor.GetPlaceholder().PointSize + "\n");
            Tizen.Log.Error("NUI", "edit PixelSize " + placeholderEditor.GetPlaceholder().PixelSize + "\n");
            Tizen.Log.Error("NUI", "edit Ellipsis " + placeholderEditor.GetPlaceholder().Ellipsis + "\n");


            // Hidden Input
            TextField hiddenInputField = new TextField
            {
                PlaceholderText = "Password",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 15.0f,
                BackgroundColor = Color.White,
            };
            view.Add(hiddenInputField);

            var hiddenInput = new Tizen.NUI.Text.HiddenInput();
            hiddenInput.Mode = HiddenInputModeType.ShowLastCharacter;
            //hiddenInput.SubstituteCharacter = '★';
            //hiddenInput.SubstituteCount = 0;
            //hiddenInput.ShowLastCharacterDuration = 1000;

            hiddenInputField.SetHiddenInput(hiddenInput);

            Tizen.Log.Error("NUI", "struct hiddenInput mode " + hiddenInputField.GetHiddenInput().Mode + "\n");
            Tizen.Log.Error("NUI", "struct hiddenInput char " + hiddenInputField.GetHiddenInput().SubstituteCharacter + "\n");
            Tizen.Log.Error("NUI", "struct hiddenInput cnt " + hiddenInputField.GetHiddenInput().SubstituteCount + "\n");
            Tizen.Log.Error("NUI", "struct hiddenInput dur " + hiddenInputField.GetHiddenInput().ShowLastCharacterDuration + "\n");

            View horView = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 15,
            };
            view.Add(horView);

            var btnShow = new Button
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            btnShow.Clicked += (s, e) =>
            {
                var hiddenNone = new Tizen.NUI.Text.HiddenInput();
                hiddenInput.Mode = HiddenInputModeType.HideNone;
                hiddenInputField.SetHiddenInput(hiddenNone);
                hiddenInputField.Text = hiddenInputField.Text;
            };
            horView.Add(btnShow);

            var btnHide = new Button
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            btnHide.Clicked += (s, e) =>
            {
                var hiddenHide = new Tizen.NUI.Text.HiddenInput();
                hiddenHide.Mode = HiddenInputModeType.ShowLastCharacter;
                hiddenInputField.SetHiddenInput(hiddenHide);
                hiddenInputField.Text = hiddenInputField.Text;
            };
            horView.Add(btnHide);

            // SelectionHandleImage
            TextField selectionHandleField = new TextField
            {
                Text = "Selection Handle Image L, R",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                PointSize = 15.0f,
                BackgroundColor = Color.White,

                GrabHandleImage = "handle_down.png",
            };
            view.Add(selectionHandleField);


            var selectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage();
            selectionHandleImage.LeftImageUrl = "handle_downleft.png";
            selectionHandleImage.RightImageUrl = "handle_downright.png";
            selectionHandleField.SetSelectionHandleImage(selectionHandleImage);

            var selectionHandlePressedImage = new Tizen.NUI.Text.SelectionHandleImage();
            selectionHandlePressedImage.LeftImageUrl = "handle_downleft_pressed.png";
            selectionHandlePressedImage.RightImageUrl = "handle_downright_pressed.png";
            selectionHandleField.SetSelectionHandlePressedImage(selectionHandlePressedImage);

            var selectionHandleMarkerImage = new Tizen.NUI.Text.SelectionHandleImage();
            selectionHandleMarkerImage.LeftImageUrl = "handle_marker.png";
            selectionHandleMarkerImage.RightImageUrl = "handle_marker.png";
            selectionHandleField.SetSelectionHandleMarkerImage(selectionHandleMarkerImage);

            Tizen.Log.Error("NUI", "get struct sel left " + selectionHandleField.GetSelectionHandleImage().LeftImageUrl + "\n");
            Tizen.Log.Error("NUI", "get struct sel right " + selectionHandleField.GetSelectionHandleImage().RightImageUrl + "\n");

            Tizen.Log.Error("NUI", "get struct pressed left " + selectionHandleField.GetSelectionHandlePressedImage().LeftImageUrl + "\n");
            Tizen.Log.Error("NUI", "get struct pressed right " + selectionHandleField.GetSelectionHandlePressedImage().RightImageUrl + "\n");

            Tizen.Log.Error("NUI", "get struct marker left " + selectionHandleField.GetSelectionHandleMarkerImage().LeftImageUrl + "\n");
            Tizen.Log.Error("NUI", "get struct marker right " + selectionHandleField.GetSelectionHandleMarkerImage().RightImageUrl + "\n");


            // SelectionHandleImage
            TextEditor selectionHandleEditor = new TextEditor
            {
                Text = "Selection Handle Editor L, R",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,

                PointSize = 15.0f,
                BackgroundColor = Color.White,

                GrabHandleImage = "handle_down.png",
            };
            view.Add(selectionHandleEditor);

            selectionHandleEditor.SetSelectionHandleImage(selectionHandlePressedImage);
            selectionHandleEditor.SetSelectionHandlePressedImage(selectionHandleImage);
            selectionHandleEditor.SetSelectionHandleMarkerImage(selectionHandleMarkerImage);

            Tizen.Log.Error("NUI", "get editor struct sel left " + selectionHandleEditor.GetSelectionHandleImage().LeftImageUrl + "\n");
            Tizen.Log.Error("NUI", "get editor struct sel right " + selectionHandleEditor.GetSelectionHandleImage().RightImageUrl + "\n");

            Tizen.Log.Error("NUI", "get editor struct pressed left " + selectionHandleEditor.GetSelectionHandlePressedImage().LeftImageUrl + "\n");
            Tizen.Log.Error("NUI", "get editor struct pressed right " + selectionHandleEditor.GetSelectionHandlePressedImage().RightImageUrl + "\n");

            Tizen.Log.Error("NUI", "get editor struct marker left " + selectionHandleEditor.GetSelectionHandleMarkerImage().LeftImageUrl + "\n");
            Tizen.Log.Error("NUI", "get editor struct marker right " + selectionHandleEditor.GetSelectionHandleMarkerImage().RightImageUrl + "\n");

        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
