namespace WA_Front.Controls;

class HorizontalFlexLayout : HorizontalStackLayout
{
    protected override ILayoutManager CreateLayoutManager()
    {
        return new HorizontalFlexManager(this);
    }
}
