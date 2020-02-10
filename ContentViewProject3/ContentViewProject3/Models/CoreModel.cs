using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace ContentViewProject3.Models {
    public class CoreModel : BindableBase {
        public ObservableCollection<VTuberRandom> VTuberRandoms { get; private set; }

        /// <summary>
        /// リストの数をセットする
        /// </summary>
        /// <param name="i">リスト数</param>
        public void Set(int i) {
            var items = Enumerable.Range(0, i).Select(x => new VTuberRandom());
            VTuberRandoms = new ObservableCollection<VTuberRandom>(items);
        }
    }
}
