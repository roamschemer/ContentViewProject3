using Prism.Navigation;
using Reactive.Bindings;
using System;

namespace ContentViewProject3.ViewModels {
    public class MainPageViewModel : ViewModelBase {

        public ReactiveCommand<string> PageNavigationCommand { get; } = new ReactiveCommand<string>();

        public MainPageViewModel(INavigationService navigationService) : base(navigationService) {

            PageNavigationCommand.Subscribe(async x => await navigationService.NavigateAsync(x));

        }
    }
}
