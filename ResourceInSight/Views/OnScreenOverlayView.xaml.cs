using System.Windows;

namespace ResourceInSight.Views;

/// <summary>
/// Interaction logic for OnScreenOverlayView.xaml
/// </summary>
public partial class OnScreenOverlayView : Window
{
    public OnScreenOverlayView()
    {
        this.InitializeComponent();
    }

    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        Helpers.OverlayClickThroughHelper.SetWindowExTransparent(this);
    }
}
