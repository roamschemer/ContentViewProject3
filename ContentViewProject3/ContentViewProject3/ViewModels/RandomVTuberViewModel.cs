using ContentViewProject3.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;

namespace ContentViewProject3.ViewModels {
    public class RandomVTuberViewModel : IDisposable {

        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<int> Count { get; }
        public ReactiveCommand RundomCommand { get; } = new ReactiveCommand();

        public RandomVTuberViewModel(VTuberRandom vTuberRandom) {
            //Modelとの接続
            Name = vTuberRandom.ObserveProperty(x => x.Name)
                                    .Where(x => x != null)
                                    .Select(x => new[] { "九条", "縁うか", "泡沫調" }.Any(y => x.Contains(y)) ? $"{x} 様" : x) //様を付けろ
                                    .ToReactiveProperty()
                                    .AddTo(this.Disposable);
            Count = vTuberRandom.ObserveProperty(x => x.Count).ToReactiveProperty().AddTo(this.Disposable);

            //Commandの実行
            RundomCommand.Subscribe(_ => vTuberRandom.RundomNameSet());
        }

        //後始末
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();
        public void Dispose() => this.Disposable.Dispose();

    }
}
