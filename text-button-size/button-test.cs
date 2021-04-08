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


            // Note: https://github.sec.samsung.net/dotnet/NUIBackend/issues/17

            var button = new Button
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                //WidthResizePolicy = ResizePolicyType.FitToChildren,
                //HeightResizePolicy = ResizePolicyType.FitToChildren,
                BackgroundColor = Color.CadetBlue,
            };

            button.Text = "Loooooooooooooooooooooooooooong text";
            //button.Icon.ResourceUrl = System.IO.Path.Combine(Application.Current.DirectoryInfo.Resource, "play.png");
            //button.IconRelativeOrientation = Button.IconOrientation.Left;

            view.Add(button);


            // Label for compare
            TextLabel label = new TextLabel
            {
                Text = "Loooooooooooooooooooooooooooong text",
                // Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                // EnableMarkup = true,
                MultiLine = true,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                PointSize = 25.0f,
                BackgroundColor = Color.White,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,   // only single line
            };
            view.Add(label);



            window.Add(view);



            // FillToParent
            var noLayoutBtn1 = new Button
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                BackgroundColor = Color.CadetBlue,
                Position2D = new Position2D(0, 300),
                Text = "FillToParent",
            };
            window.Add(noLayoutBtn1);

            // FillToParent
            var noLayoutBtn2 = new Button
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                BackgroundColor = Color.CadetBlue,
                Position2D = new Position2D(0, 400),
                Text = "FillToParent Loooooooooooooooooooooooooooong text",
            };
            window.Add(noLayoutBtn2);

            // FitToChildren
            var noLayoutBtn3 = new Button
            {
                WidthResizePolicy = ResizePolicyType.FitToChildren,
                HeightResizePolicy = ResizePolicyType.FitToChildren,
                BackgroundColor = Color.CadetBlue,
                Position2D = new Position2D(0, 500),
                Text = "FitToChildren",
            };
            window.Add(noLayoutBtn3);

            // FitToChildren
            var noLayoutBtn4 = new Button
            {
                WidthResizePolicy = ResizePolicyType.FitToChildren,
                HeightResizePolicy = ResizePolicyType.FitToChildren,
                BackgroundColor = Color.CadetBlue,
                Position2D = new Position2D(0, 600),
                Text = "FitToChildren Loooooooooooooooooooooooooooong text",
            };
            window.Add(noLayoutBtn4);
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
