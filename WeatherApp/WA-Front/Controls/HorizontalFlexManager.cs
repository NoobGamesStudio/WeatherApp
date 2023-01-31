namespace WA_Front.Controls;

class HorizontalFlexManager : HorizontalStackLayoutManager
{
    HorizontalFlexLayout _layout;

    public HorizontalFlexManager(HorizontalFlexLayout layout) : base(layout)
    {
        _layout = layout;
    }

    public override Size Measure(double widthConstraint, double heightConstraint)
    {
        Thickness padding = _layout.Padding;
        widthConstraint -= padding.HorizontalThickness;

        double currentRowWidth = 0;
        double currentRowHeight = 0;
        double totalWidth = 0;
        double totalHeight = 0;

        foreach (IView child in _layout)
        {
            if (child.Visibility == Visibility.Collapsed)
                continue;

            Size measure = child.Measure(double.PositiveInfinity, heightConstraint);

            if (currentRowWidth + measure.Width > widthConstraint)
            {
                totalWidth = Math.Max(totalWidth, currentRowWidth);
                totalHeight += currentRowHeight + _layout.Spacing;

                currentRowWidth = 0;
                currentRowHeight = measure.Height;
            }
            else
            {
                currentRowHeight = Math.Max(currentRowHeight, measure.Height);
                currentRowWidth += measure.Width + _layout.Spacing;
            }
        }

        // Last row
        currentRowWidth -= _layout.Spacing;
        totalWidth = Math.Max(totalWidth, currentRowWidth) + padding.HorizontalThickness;
        totalHeight += currentRowHeight + padding.VerticalThickness;

        double finalHeight = ResolveConstraints(heightConstraint, Stack.Height, totalHeight, Stack.MinimumHeight, Stack.MaximumHeight);
        double finalWidth = ResolveConstraints(widthConstraint, Stack.Width, totalWidth, Stack.MinimumWidth, Stack.MaximumWidth);

        return new Size(finalWidth, finalHeight);
    }

    public override Size ArrangeChildren(Rect bounds)
    {
        Thickness padding = Stack.Padding;
        double left = padding.Left + bounds.Left;

        double currentTop = padding.Top + bounds.Top;
        double currentLeft = left;
        double currentHeight = 0;

        double maxWidth = currentLeft;

        foreach (IView child in _layout)
        {
            if (child.Visibility == Visibility.Collapsed)
                continue;

            if (currentLeft + child.DesiredSize.Width > bounds.Right)
            {
                maxWidth = Math.Max(maxWidth, currentLeft);

                currentLeft = left;
                currentTop += currentHeight + _layout.Spacing;
                currentHeight = 0;
            }

            Rect destination = new(currentLeft, currentTop, child.DesiredSize.Width, child.DesiredSize.Height);
            child.Arrange(destination);

            currentLeft += destination.Width + _layout.Spacing;
            currentHeight = Math.Max(currentHeight, destination.Height);
        }

        return new Size(maxWidth, currentTop + currentHeight).AdjustForFill(bounds, Stack);
    }
}
