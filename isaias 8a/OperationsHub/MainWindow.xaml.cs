using System;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace OperationsHub;

// MainWindow is a class. Put fields and methods inside these outer braces.
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Bind the view to this window instance so Items is visible to XAML
        DataContext = this;
        // Seed with a sample entry (matches the default txtEntry text)
        Items.Add(txtEntry.Text);
    }

    // Collection bound to the ListBox. Use ObservableCollection so the UI updates automatically.
    // Seed with some starter items so the ListBox shows content at startup.
    public ObservableCollection<string> Items { get; } = new()
    {
        "Grilled Chicken",
        "Chips",
        "Fries",
        "Cookies",
        "Water",
        "Arizona",
        "Coffee",
    };

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        var text = txtEntry.Text?.Trim();
        if (string.IsNullOrWhiteSpace(text))
        {
            txtStatus.Text = "Enter a non-empty item before adding.";
            return;
        }

        // Find an existing item ignoring case. If found, move the original-cased item to the top.
        int existingIndex = -1;
        for (int i = 0; i < Items.Count; i++)
        {
            if (string.Equals(Items[i], text, StringComparison.OrdinalIgnoreCase))
            {
                existingIndex = i;
                break;
            }
        }

        if (existingIndex >= 0)
        {
            var existing = Items[existingIndex];
            Items.RemoveAt(existingIndex);
            Items.Insert(0, existing);
            txtStatus.Text = $"Moved to top: {existing}";
        }
        else
        {
            Items.Insert(0, text);
            txtStatus.Text = $"Added to top: {text}";
        }

        // Select the moved/added item and clear the entry box for the next input.
        lstItems.SelectedIndex = 0;
        txtEntry.Clear();
        txtEntry.Focus();
    }

    private void Remove_Click(object sender, RoutedEventArgs e)
    {
        if (lstItems.SelectedItem is string s)
        {
            Items.Remove(s);
            txtStatus.Text = $"Removed: {s}";
        }
        else
        {
            txtStatus.Text = "Select an item to remove.";
        }
    }

    private void Timer_Click(object sender, RoutedEventArgs e)
    {
        // TODO (Timer chapter): Implement Timer in the matching tutorial chapter.
        // Replace this placeholder with the handler shown in that chapter.
        txtStatus.Text = "Timer_Click: behavior still to build.";
    }

    private void Reset_Click(object sender, RoutedEventArgs e)
    {
        // TODO (Timer chapter): Implement Reset in the matching tutorial chapter.
        // Replace this placeholder with the handler shown in that chapter.
        txtStatus.Text = "Reset_Click: behavior still to build.";
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        // TODO (Text files chapter): Implement Save in the matching tutorial chapter.
        // Replace this placeholder with the handler shown in that chapter.
        txtStatus.Text = "Save_Click: behavior still to build.";
    }

    private void Open_Click(object sender, RoutedEventArgs e)
    {
        // TODO (Text files chapter): Implement Open in the matching tutorial chapter.
        // Replace this placeholder with the handler shown in that chapter.
        txtStatus.Text = "Open_Click: behavior still to build.";
    }

    private void Image_Click(object sender, RoutedEventArgs e)
    {
        // TODO (Artwork chapter): Implement Image in the matching tutorial chapter.
        // Replace this placeholder with the handler shown in that chapter.
        txtStatus.Text = "Image_Click: behavior still to build.";
    }

    private void txtDocument_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {

    }

    private void lstItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {

    }

    private void Order_Click(object sender, RoutedEventArgs e)
    {
        // Sort the collection alphabetically (case-insensitive) while preserving original casing.
        var sorted = new System.Collections.Generic.List<string>(Items);
        sorted.Sort((a, b) => string.Compare(a, b, StringComparison.OrdinalIgnoreCase));
        Items.Clear();
        foreach (var s in sorted)
            Items.Add(s);
        txtStatus.Text = "Ordered list alphabetically.";
    }
}
