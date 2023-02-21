using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp49;

public partial class MainPage : ContentPage
{
	private readonly Model[] _models = Enumerable.Range(0, 7).Select(i => new Model(i)).ToArray();

	public MainPage()
	{
		InitializeComponent();
		_collectionView.ItemsSource = _models;
        _collectionView.Scrolled += Scrolled;
	}

    private void Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
		int first = e.FirstVisibleItemIndex;
		int last = e.LastVisibleItemIndex;

		_label.Text = $"first: {first}, last: {last}";

		for (int i = 0; i < _models.Length; i++)
		{
			_models[i].IsVisible = i >= first && i <= last;
		}
    }
}

public partial class Model : ObservableObject
{
	[ObservableProperty, NotifyPropertyChangedFor(nameof(Color))]
	private bool _isVisible;

    public Model(int index) => Index = index;

    public int Index { get; }
	public Color Color => IsVisible ? Colors.LightGreen : Colors.PaleVioletRed;
}