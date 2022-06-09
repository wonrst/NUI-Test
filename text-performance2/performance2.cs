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
                Layout = new AbsoluteLayout(),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            window.Add(view);

            Tizen.Log.Error("NUI", "RYU - START [" + DateTime.Now.ToString("HH:mm:ss") + "] \n");

            var scroll = new ScrollableBase()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            view.Add(scroll);
            scroll.ContentContainer.Layout = new LinearLayout
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            };

            for (int i = 0; i < 10; i++)
            {
                var label = new TextLabel
                {
                    PointSize = 20,
                    MultiLine = true,
                    LineWrapMode = LineWrapMode.Word,
                    Ellipsis = false,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Top,
                    Text = "In the meantime the cat slowly recovered. The socket of the lost eye presented, it is true, a frightful appearance, but he no longer appeared to suffer any pain. He went about the house as usual, but, as might be expected, fled in extreme terror at my approach. I had so much of my old heart left, as to be at first grieved by this evident dislike on the part of a creature which had once so loved me. But this feeling soon gave place to irritation. And then came, as if to my final and irrevocable overthrow, the spirit of PERVERSENESS. Of this spirit philosophy takes no account. Yet I am not more sure that my soul lives, than I am that perverseness is one of the primitive impulses of the human heart -- one of the indivisible primary faculties, or sentiments, which give direction to the character of Man. Who has not, a hundred times, found himself committing a vile or a silly action, for no other reason than because he knows he should not? Have we not a perpetual inclination, in the teeth of our best judgment, to violate that which is Law, merely because we understand it to be such? This spirit of perverseness, I say, came to my final overthrow. It was this unfathomable longing of the soul to vex itself -- to offer violence to its own nature -- to do wrong for the wrong's sake only -- that urged me to continue and finally to consummate the injury I had inflicted upon the unoffending brute. One morning, in cool blood, I slipped a noose about its neck and hung it to the limb of a tree; -- hung it with the tears streaming from my eyes, and with the bitterest remorse at my heart; -- hung it because I knew that it had loved me, and because I felt it had given me no reason of offence; -- hung it because I knew that in so doing I was committing a sin -- a deadly sin that would so jeopardize my immortal soul as to place it -- if such a thing were possible -- even beyond the reach of the infinite mercy of the Most Merciful and Most Terrible God.In the meantime the cat slowly recovered. The socket of the lost eye presented, it is true, a frightful appearance, but he no longer appeared to suffer any pain. He went about the house as usual, but, as might be expected, fled in extreme terror at my approach. I had so much of my old heart left, as to be at first grieved by this evident dislike on the part of a creature which had once so loved me. But this feeling soon gave place to irritation. And then came, as if to my final and irrevocable overthrow, the spirit of PERVERSENESS. Of this spirit philosophy takes no account. Yet I am not more sure that my soul lives, than I am that perverseness is one of the primitive impulses of the human heart -- one of the indivisible primary faculties, or sentiments, which give direction to the character of Man. Who has not, a hundred times, found himself committing a vile or a silly action, for no other reason than because he knows he should not? Have we not a perpetual inclination, in the teeth of our best judgment, to violate that which is Law, merely because we understand it to be such? This spirit of perverseness, I say, came to my final overthrow. It was this unfathomable longing of the soul to vex itself -- to offer violence to its own nature -- to do wrong for the wrong's sake only -- that urged me to continue and finally to consummate the injury I had inflicted upon the unoffending brute. One morning, in cool blood, I slipped a noose about its neck and hung it to the limb of a tree; -- hung it with the tears streaming from my eyes, and with the bitterest remorse at my heart; -- hung it because I knew that it had loved me, and because I felt it had given me no reason of offence; -- hung it because I knew that in so doing I was committing a sin -- a deadly sin that would so jeopardize my immortal soul as to place it -- if such a thing were possible -- even beyond the reach of the infinite mercy of the Most Merciful and Most Terrible God.In the meantime the cat slowly recovered. The socket of the lost eye presented, it is true, a frightful appearance, but he no longer appeared to suffer any pain. He went about the house as usual, but, as might be expected, fled in extreme terror at my approach. I had so much of my old heart left, as to be at first grieved by this evident dislike on the part of a creature which had once so loved me. But this feeling soon gave place to irritation. And then came, as if to my final and irrevocable overthrow, the spirit of PERVERSENESS. Of this spirit philosophy takes no account. Yet I am not more sure that my soul lives, than I am that perverseness is one of the primitive impulses of the human heart -- one of the indivisible primary faculties, or sentiments, which give direction to the character of Man. Who has not, a hundred times, found himself committing a vile or a silly action, for no other reason than because he knows he should not? Have we not a perpetual inclination, in the teeth of our best judgment, to violate that which is Law, merely because we understand it to be such? This spirit of perverseness, I say, came to my final overthrow. It was this unfathomable longing of the soul to vex itself -- to offer violence to its own nature -- to do wrong for the wrong's sake only -- that urged me to continue and finally to consummate the injury I had inflicted upon the unoffending brute. One morning, in cool blood, I slipped a noose about its neck and hung it to the limb of a tree; -- hung it with the tears streaming from my eyes, and with the bitterest remorse at my heart; -- hung it because I knew that it had loved me, and because I felt it had given me no reason of offence; -- hung it because I knew that in so doing I was committing a sin -- a deadly sin that would so jeopardize my immortal soul as to place it -- if such a thing were possible -- even beyond the reach of the infinite mercy of the Most Merciful and Most Terrible God.",
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                    HeightSpecification = LayoutParamPolicies.WrapContent
                };
                scroll.ContentContainer.Add(label);
            }

            Tizen.Log.Error("NUI", "RYU - End [" + DateTime.Now.ToString("HH:mm:ss") + "] \n");
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
