namespace WA_Front.Controls;

public enum Orientation
{
	Left, Right, Bottom, Top
}

public class Expander : ContentView
{
	public static readonly BindableProperty OrientationProperty = BindableProperty.Create(nameof(Orientation), typeof(Orientation), typeof(Expander), Orientation.Bottom, propertyChanged: OnOrientationPropertyChanged);

	public static readonly BindableProperty HeaderContentProperty = BindableProperty.Create(nameof(HeaderContent), typeof(VisualElement), typeof(Expander), new ContentView(), propertyChanged: OnHeaderContentChanged);

    public static readonly BindableProperty MainContentProperty = BindableProperty.Create(nameof(MainContent), typeof(VisualElement), typeof(Expander), new ContentView(), propertyChanged: OnMainContentChanged);

    public static readonly BindableProperty IsExpandedProperty = BindableProperty.Create(nameof(IsExpanded), typeof(bool), typeof(Expander), false, BindingMode.TwoWay);

    public Orientation Orientation 
    {
        get => (Orientation)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    public VisualElement HeaderContent
    {
        get => (VisualElement)GetValue(HeaderContentProperty);
        set => SetValue(HeaderContentProperty, value);
    }

    public VisualElement MainContent
    {
        get => (VisualElement)GetValue(MainContentProperty);
        set => SetValue(MainContentProperty, value);
    }

    public bool IsExpanded
    {
        get => (bool)GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    protected Grid Grid
    {
        get => Content as Grid;
        set => Content = value;
    }

    public Expander()
    {
        Content = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Auto },
            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = GridLength.Auto },
                new ColumnDefinition { Width = GridLength.Auto },
            }
        };
        OnOrientationPropertyChanged(this, Orientation, Orientation);
    }

    static void OnOrientationPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        Expander expander = bindable as Expander;
        Orientation orientation = (Orientation)newValue;
        Grid grid = expander.Grid;

        (int row, int column) = (
            orientation == Orientation.Bottom ? 1 : 0, 
            orientation == Orientation.Right ? 1 : 0);

        grid.SetRow(expander.MainContent, row);
        grid.SetColumn(expander.MainContent, column);
        grid.SetRow(expander.HeaderContent, orientation == Orientation.Top ? 1 : 0);
        grid.SetColumn(expander.HeaderContent, orientation == Orientation.Left ? 1 : 0);

        foreach(var rdef in expander.Grid.RowDefinitions)
            rdef.Height = GridLength.Auto;

        foreach (var rcol in expander.Grid.ColumnDefinitions)
            rcol.Width = GridLength.Auto;

        grid.RowDefinitions[row].Height= GridLength.Star;
        grid.ColumnDefinitions[column].Width= GridLength.Star;
    }

    static void OnContentChanged(BindableObject bindable, object oldValue, object newValue)
    {
        Expander expander = bindable as Expander;
        VisualElement oldElement = oldValue as VisualElement;
        VisualElement newElement = newValue as VisualElement;
        Grid grid = expander.Grid;

        grid.Add(newElement);
        grid.SetRow(newElement, expander.Grid.GetRow(oldElement));
        grid.SetColumn(newElement, expander.Grid.GetColumn(oldElement));
        grid.Remove(oldElement);
    }

    static void OnHeaderContentChanged(BindableObject bindable, object oldValue, object newValue)
    {
        OnContentChanged(bindable, oldValue, newValue);
    }

    static void OnMainContentChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (newValue as VisualElement).SetBinding(IsVisibleProperty, new Binding(nameof(IsExpanded), source: bindable));

        OnContentChanged(bindable, oldValue, newValue);
    }
}