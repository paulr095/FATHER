// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Bhasvic10th.iOS
{
    [Register ("HomeItemDetailedVCz")]
    partial class HomeItemDetailedVCz
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HomeCategoryText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HomeDateText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView HomeDescriptionText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HomeTitleText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (HomeCategoryText != null) {
                HomeCategoryText.Dispose ();
                HomeCategoryText = null;
            }

            if (HomeDateText != null) {
                HomeDateText.Dispose ();
                HomeDateText = null;
            }

            if (HomeDescriptionText != null) {
                HomeDescriptionText.Dispose ();
                HomeDescriptionText = null;
            }

            if (HomeTitleText != null) {
                HomeTitleText.Dispose ();
                HomeTitleText = null;
            }
        }
    }
}