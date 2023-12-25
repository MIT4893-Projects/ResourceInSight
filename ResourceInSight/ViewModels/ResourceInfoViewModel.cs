using ResourceInSight.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ResourceInSight.ViewModels;

public class ResourceInfoViewModel : INotifyPropertyChanged
{
    private string resourceIcon = string.Empty;
    public string ResourceIcon
    {
        get => resourceIcon;
        set
        {
            resourceIcon = value;
            OnPropertyChanged();
        }
    }

    private ResourceType resourceType;
    public ResourceType ResourceType
    {
        get => resourceType;
        set
        {
            resourceType = value;
            ResourceIcon = resourceType switch
            {
                ResourceType.CPU => "\uf2db",
                ResourceType.Memory => "\uf538",
                ResourceType.Disk => "\uf0a0",
                _ => throw new ArgumentException("Invalid resource type")
            };
        }
    }

    public ResourceInfoViewModel()
    {

    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChangedHandler(PropertyChangedEventArgs e)
    {
        PropertyChangedEventHandler? handler = PropertyChanged;
        handler?.Invoke(this, e);
    }

    protected void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        OnPropertyChanged(e.PropertyName);
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
