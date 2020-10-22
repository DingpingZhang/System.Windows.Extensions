using Prism.Mvvm;
using System.Globalization;
using System.Windows.Input;
using WpfExtensions.Infrastructure.Commands;
using WpfExtensions.Xaml;
using BindableBase = WpfExtensions.Infrastructure.Mvvm.BindableBase;

namespace WpfApp.Net462.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private static readonly CultureInfo En = new CultureInfo("en");
        private static readonly CultureInfo ZhCn = new CultureInfo("zh-CN");

        private bool _isLoading;
        private string _inputText;
        private string _width;
        private string _height;

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public string InputText
        {
            get => _inputText;
            set => SetProperty(ref _inputText, value);
        }

        public string Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        public string Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        public double ComputedResult => Computed(() => double.Parse(Width) * double.Parse(Height), fallback: double.NaN);

        public ICommand LoadCommand { get; }

        public ICommand SwitchCultureCommand { get; }

        public ICommand NavigateCommand { get; }

        public MainWindowViewModel()
        {
            I18nManager.Instance.CurrentUICulture = ZhCn;

            LoadCommand = new RelayCommand(() => IsLoading = !IsLoading);
            SwitchCultureCommand = new RelayCommand(() =>
            {
                I18nManager.Instance.CurrentUICulture = I18nManager.Instance.CurrentUICulture.Equals(En) ? ZhCn : En;
            });
        }
    }
}
