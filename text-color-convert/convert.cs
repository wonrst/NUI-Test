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


            string text = "<b>Terms of Service For Product</b>\nEffective Date: [2016.11.09]\nCorporation Co., Ltd. together with its Affiliates (\"Corporation\", \"we\", \"us\", or \"our\") is pleased to offer you Product, an application for the Corporation Smart Refrigerator and other mobile devices that allows you to access content, information and application by Corporation, its licensors, and/or its third party contractors (\"Service\"). This Agreement (\"Agreement\") is a binding contract between you and Corporation which governs the use of the Service. The Service is only for your own personal use. You may not use the Service for any commercial purpose or in any way not expressly permitted by this Agreement. PLEASE READ THIS AGREEMENT CAREFULLY BEFORE ACCESSING OR USING THE SERVICE BECAUSE IT CONSTITUTES A BINDING LEGAL AGREEMENT BETWEEN YOU AND CORPORATION.\nBY ACCESSING OR USING THE SERVICE, YOU ACKNOWLEDGE THAT YOU HAVE READ AND UNDERSTOOD THIS AGREEMENT, AND YOU AGREE TO COMPLY WITH AND BE BOUND BY ITS TERMS.  IF YOU ARE NOT WILLING TO BE BOUND BY THE TERMS OF THIS AGREEMENT, YOU MAY NOT ACCESS OR USE THE SERVICE. This Agreement incorporates the Corporation Account Terms and Conditions, located at https://account.corporation.com/membership/terms, that you may have already agreed to for your single sign-on user account with Corporation. If there is any conflict between this Agreement and the Corporation Account Terms and Conditions, this Agreement will prevail as specifically related to the Service, but only to the extent of actual conflict. Your use of the Service is subject to Corporation's privacy policy, located at http://www.corporation.com/us/common/privacy.html (\"Privacy Policy\"), which is hereby incorporated by this reference, and other policies that Corporation may adopt from time to time. Corporation may modify this Agreement from time to time. If we change this Agreement, we will update the Effective Date listed above. If you continue to access or use the Service after such modification, you will be deemed to have read, understood and unconditionally agreed to such changes.\nTHE SERVICE IS NOT INTENDED FOR USE BY ANYONE UNDER THE AGE OF 13. IF YOU ARE UNDER THE AGE OF 13, YOU MAY NOT USE THE SERVICE OR PROVIDE CORPORATION WITH ANY PERSONALLY IDENTIFIABLE INFORMATION. If you are 13 or older but under the age of 18, you represent that you have reviewed these terms and conditions with your parent or legal guardian and that you and your parent or guardian understand and consent to these terms and conditions. If you are a parent or guardian permitting a person under the age of 18 (\"Minor\") to use the Service, you agree to: (i) supervise the Minor's use of the Service; (ii) assume all risks associated with the Minor's use of the Service, including the transmission of content to and from third parties via the Internet; (iii) assume any liability resulting from the Minor's use of the Service; (iv) ensure the accuracy and truthfulness of all information submitted by the Minor; and (v) assume responsibility and are bound by this Agreement for the Minor's access and use of the Service.\n1. The Services\n1.1 The Services are provided to you by Corporation and in some cases, by Corporation's Affiliates (as defined hereunder) on behalf of Corporation. You agree that Corporation's Affiliates are each entitled to provide the Services to you under this Agreement.\n1.2 When you access the Service, you may be asked to create an account and provide certain information including, without limitation, a valid email address. You acknowledge and agree that you are solely responsible for the form, content and accuracy of any content placed by you on the Service. Use of the Service will require your devices to have access or connection via mobile network or Internet (fees may apply), and may require updates or upgrades from time to time. You agree that Corporation may automatically download and install updates onto your device from time to time. Because use of the Service involves hardware, software, and Internet access, your ability to use the Service may be affected by the reliability and performance of such system requirements. You acknowledge and agree that such system requirements, which may be changed from time to time, are your responsibility. You also acknowledge that the Service will not be available in all countries or on all devices, and may be subject to restrictions imposed by your network carrier or Internet provider. You are solely responsible for any charges incurred from your network provider related to the use of the Service.\n1.3 The Services are provided only for your personal, noncommercial use. Subject to the terms and conditions of this Agreement,  Corporation hereby grants you, and you accept, a limited, personal, nonexclusive, nontransferable and revocable right to use the  Service only as authorized in this Agreement and in any applicable separate terms from Corporation. Access to the Services is  licensed, not sold to you. All references to the Services include all related content, such as video, music, text, pictures,  graphics, user interfaces, scripts and software used to implement and provide access to the Services, and any updates, upgrades,  enhancements, modifications, revisions or additions to the Services made available by Corporation. However, Corporation is under  no obligation to provide any updates, upgrades, enhancements, modifications, revisions or additions to the Services.";
            //string shortText = "Hello world";

            var label = new TextLabel
            {
                PointSize = 30,
                MultiLine = true,
                LineWrapMode = LineWrapMode.Word,
                Ellipsis = false,
                Text = text,
                EnableMarkup = true,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            scroll.ContentContainer.Add(label);
            

/*
            var editor = new TextEditor
            {
                PointSize = 20,
                LineWrapMode = LineWrapMode.Word,
                Ellipsis = false,
                Text = text,
                EnableMarkup
                
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            view.Add(editor);
*/

        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
