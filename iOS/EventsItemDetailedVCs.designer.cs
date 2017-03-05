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
    [Register ("EventsItemDetailedVCs")]
    partial class EventsItemDetailedVCs
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EventsCategoryText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EventsDateText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView EventsDescriptionText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EventsTitleText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (EventsCategoryText != null) {
                EventsCategoryText.Dispose ();
                EventsCategoryText = null;
            }

            if (EventsDateText != null) {
                EventsDateText.Dispose ();
                EventsDateText = null;
            }

            if (EventsDescriptionText != null) {
                EventsDescriptionText.Dispose ();
                EventsDescriptionText = null;
            }

            if (EventsTitleText != null) {
                EventsTitleText.Dispose ();
                EventsTitleText = null;
            }
        }
    }
}