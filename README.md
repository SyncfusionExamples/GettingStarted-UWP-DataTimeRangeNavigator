# Getting Started with UWP DateTimeRangeNavigator (SfDateTimeRangeNavigator)

This sample demonstrates how to create and configure the Syncfusion **SfDateTimeRangeNavigator** control in a UWP application.

## Visual Structure

A `SfDateTimeRangeNavigator` is composed of the following elements:

- **Higher level bar** – Displays the timespan format one level higher than the lower level bar (e.g., Year format `yyyy`).
- **Lower level bar** – Displays the timespan format one level lower than the higher level bar (e.g., Month format `MMM`).
- **Content** – Hosts any UI element inside the navigator.
- **Resizable scrollbar** – Used to zoom and scroll the content and label bars.

## Requirements

- Visual Studio 2019 or later
- Windows 10 SDK
- Syncfusion UWP Controls (SyncfusionControls for UWP XAML)

## Adding Assembly Reference

1. Open the **Add Reference** window from your project.
2. Choose **Windows > Extensions > SyncfusionControls for UWP XAML**.

## Namespace

Add the following namespace in your XAML page:

```xml
xmlns:syncfusion="using:Syncfusion.UI.Xaml.Charts"
```

For code-behind, add:

```csharp
using Syncfusion.UI.Xaml.Charts;
```

## Creating a Data Model

Define a `Model` class with the required properties:

```csharp
public class Model
{
    public DateTime Date { get; set; }
    public double High { get; set; }
    public double Low { get; set; }
    public double Open { get; set; }
    public double Close { get; set; }
}
```

## Creating a ViewModel

Define a `ViewModel` class that populates an `ObservableCollection` of `Model` objects:

```csharp
public class ViewModel
{
    public ViewModel()
    {
        this.StockPriceDetails = new ObservableCollection<Model>();
        DateTime date = new DateTime(2015, 1, 1);
        Random rd = new Random();
        for (int i = 0; i < 70; i++)
        {
            this.StockPriceDetails.Add(new Model()
            {
                Date = date.AddDays(i),
                Open = rd.Next(870, 875),
                High = rd.Next(876, 890),
                Low = rd.Next(850, 855),
                Close = rd.Next(856, 860)
            });
        }
    }
    public ObservableCollection<Model> StockPriceDetails { get; set; }
}
```

## Initializing SfDateTimeRangeNavigator

### XAML

Set the `DataContext` and initialize the `SfDateTimeRangeNavigator` with `ItemsSource` and `XBindingPath` in `MainPage.xaml`:

```xml
<Page
    x:Class="GettingStarted.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:GettingStarted"
    xmlns:syncfusion="using:Syncfusion.UI.Xaml.Charts"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <Page.DataContext>
        <local:ViewModel/>
    </Page.DataContext>

    <Grid>
        <syncfusion:SfDateTimeRangeNavigator x:Name="RangeNavigator"
                ItemsSource="{Binding StockPriceDetails}"
                XBindingPath="Date">
        </syncfusion:SfDateTimeRangeNavigator>
    </Grid>
</Page>
```

### Code Behind

```csharp
ViewModel viewModel = new ViewModel();
SfDateTimeRangeNavigator navigator = new SfDateTimeRangeNavigator();
navigator.ItemsSource = viewModel.StockPriceDetails;
navigator.XBindingPath = "Date";
```

## Adding Content

The `Content` property allows you to host any UI element inside the navigator. In this sample, an `SfLineSparkline` is used to display stock price data.

### XAML

```xml
<syncfusion:SfDateTimeRangeNavigator x:Name="RangeNavigator"
        ItemsSource="{Binding StockPriceDetails}"
        XBindingPath="Date">
    <syncfusion:SfDateTimeRangeNavigator.Content>
        <syncfusion:SfLineSparkline ItemsSource="{Binding StockPriceDetails}"
                                    Margin="20"
                                    YBindingPath="High">
        </syncfusion:SfLineSparkline>
    </syncfusion:SfDateTimeRangeNavigator.Content>
</syncfusion:SfDateTimeRangeNavigator>
```

### Code Behind

```csharp
ViewModel viewModel = new ViewModel();

SfLineSparkline sparkline = new SfLineSparkline();
sparkline.ItemsSource = viewModel.StockPriceDetails;
sparkline.YBindingPath = "High";

SfDateTimeRangeNavigator navigator = new SfDateTimeRangeNavigator();
navigator.ItemsSource = viewModel.StockPriceDetails;
navigator.XBindingPath = "Date";
navigator.Content = sparkline;

this.MainGrid.Children.Add(navigator);
```

## Key Properties

| Property | Description |
|---|---|
| `ItemsSource` | Gets or sets an `IEnumerable` source used to render the range. |
| `XBindingPath` | Gets or sets the property path of the x-axis data in `ItemsSource`. |
| `Content` | Gets or sets the UI element hosted inside the navigator. |

## Output

Once the project is run, the `SfDateTimeRangeNavigator` will display a line sparkline chart inside it, along with the higher and lower level label bars showing year and month formats. The resizable scrollbar allows zooming and scrolling through the data.
<img width="1919" height="1008" alt="image" src="https://github.com/user-attachments/assets/a3fc55f8-1505-49e8-890d-5ade6e2b42f2" />

## Reference

- [Syncfusion UWP Range Selector – Getting Started](https://help.syncfusion.com/uwp/range-selector/getting-started)

