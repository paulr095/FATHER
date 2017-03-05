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
    [Register ("HomeVC")]
    partial class HomeVC
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CatLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CatLabel != null) {
                CatLabel.Dispose ();
                CatLabel = null;
            }
        }
    }
}