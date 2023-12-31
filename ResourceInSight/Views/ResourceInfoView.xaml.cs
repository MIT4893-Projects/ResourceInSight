﻿using ResourceInSight.Models;
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

    public ResourceType ResourceType { get; set; }

    public ResourceInfoView()
    {
        InitializeComponent();

        DataContext = viewModel;

        Loaded += UserControl_Loaded;
    }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        UpdateCustomProperty();
    }

    private void UpdateCustomProperty()
    {
        viewModel.ResourceType = ResourceType;
    }
}
