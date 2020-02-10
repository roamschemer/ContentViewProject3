using ContentViewProject3.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContentViewProject3.ViewModels {
    public class SecondPageViewModel : ViewModelBase {

        public ReadOnlyReactiveCollection<RandomVTuberViewModel> RandomVTuberViewModels { get; }
        public ReactiveCommand AllRundomCommand { get; } = new ReactiveCommand();

        public SecondPageViewModel(INavigationService navigationService, CoreModel coreModel) : base(navigationService) {
            //個別Viewへ
            coreModel.Set(16);
            RandomVTuberViewModels = coreModel.VTuberRandoms.ToReadOnlyReactiveCollection(x => new RandomVTuberViewModel(x));
            //親からの操作
            AllRundomCommand.Subscribe(_ => { foreach (var x in coreModel.VTuberRandoms) x.RundomNameSet(); });
        }
    }
}
