using ResourceInSight.Models;
using ResourceInSight.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ResourceInSight.Views;
/// <summary>
/// Interaction logic for ResourceInfoView.xaml
/// </summary>
public partial class ResourceInfoView : UserControl
{
    private readonly ResourceInfoViewModel viewModel = new();

    private string resourceIcon = string.Empty;

    public string ResourceIcon
    {
        get => resourceIcon;
        set
        {
            resourceIcon = value;
            viewModel.ResourceIcon = value;
        }
    }

    public ResourceInfoView()
    {
        InitializeComponent();

        DataContext = viewModel;

        Loaded += UserControl_Loaded;

        new ResourceModel(ResourceType.CPU).GetResourcePercent();
    }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        UpdateCustomProperty();
    }

    private void UpdateCustomProperty()
    {
        viewModel.ResourceIcon = ResourceIcon;
    }
}
