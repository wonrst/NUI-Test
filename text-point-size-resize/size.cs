/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

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
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.Black,
            };


            // Label PointSize = Field's length of text
            TextLabel label = new TextLabel
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                // EnableMarkup = true,
                MultiLine = true,

                LineWrapMode = LineWrapMode.Word,
                //LineWrapMode = LineWrapMode.Character,

                Size2D = new Size2D(480, 300),
                PointSize = 25.0f,
                BackgroundColor = Color.CadetBlue,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(label);


            // Label for information
            TextLabel dataLabel = new TextLabel
            {
                Text = "PointSize : " + label.PointSize + " Wrap : " + label.LineWrapMode,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(dataLabel);


            // Normal field
            TextField field = new TextField
            {
                // EnableMarkup = true,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,

                MaxLength = 200,
                PointSize = 25.0f,
                BackgroundColor = Color.White,

                PlaceholderText = "Input Length = Label PointSize",
                PlaceholderTextFocused = "Input Length = Label PointSize",

                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };

            field.TextChanged += (s, e) =>
            {
                label.PointSize = (float)field.Text.Length;
                dataLabel.Text = "PointSize : " + label.PointSize + " Wrap : " + label.LineWrapMode;
                Tizen.Log.Error("NUI", "label point size [" + label.PointSize + "] \n");
            };

            view.Add(field);


            // Button Char wrap
            Button charButton = new Button
            {
                Text = "LineWrapMode.Character",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };

            charButton.Clicked += (s, e) =>
            {
                label.LineWrapMode = LineWrapMode.Character;
                dataLabel.Text = "PointSize : " + label.PointSize + " Wrap : " + label.LineWrapMode;
                Tizen.Log.Error("NUI", "label line wrap mode [" + label.LineWrapMode + "] \n");
            };

            view.Add(charButton);


            // Button Word wrap
            Button wordButton = new Button
            {
                Text = "LineWrapMode.Word",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
            };

            wordButton.Clicked += (s, e) =>
            {
                label.LineWrapMode = LineWrapMode.Word;
                dataLabel.Text = "PointSize : " + label.PointSize + " Wrap : " + label.LineWrapMode;
                Tizen.Log.Error("NUI", "label line wrap mode [" + label.LineWrapMode + "] \n");
            };


            view.Add(wordButton);


            window.Add(view);
        }


        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
