using ContentViewProject3.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContentViewProject3.ViewModels {
    public class FastPageViewModel : ViewModelBase {

        public ReadOnlyReactiveCollection<RandomVTuberViewModel> RandomVTuberViewModels { get; }
        public FastPageViewModel(INavigationService navigationService,CoreModel coreModel) : base(navigationService) {

            RandomVTuberViewModels = coreModel.VTuberRandoms.ToReadOnlyReactiveCollection(x => new RandomVTuberViewModel(x));

        }
    }
}
