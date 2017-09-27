using System;

using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ActOut.Interfaces;
using ActOut.UWP.NativeServices;
using Xamarin.Forms;
using Frame = Windows.UI.Xaml.Controls.Frame;


[assembly: Dependency(typeof(Sketch))]

namespace ActOut.UWP.NativeServices
{
    public class Sketch : IWindowsInk
    {
        public async void OpenSketchWindow()
        {
            var currentAV = ApplicationView.GetForCurrentView();
            var newAV = CoreApplication.CreateNewView();
            await newAV.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                async () =>
                {
                    var newWindow = Window.Current;
                    var newAppView = ApplicationView.GetForCurrentView();
                    newAppView.Title = "Sketch Window";

                    var frame = new Frame();
                    frame.Navigate(typeof(InkCanvasPage), null);
                    newWindow.Content = frame;
                    newWindow.Activate();

                    await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
                        newAppView.Id,
                        ViewSizePreference.UseMinimum,
                        currentAV.Id,
                        ViewSizePreference.UseMinimum);
                });
        }
    }
}
