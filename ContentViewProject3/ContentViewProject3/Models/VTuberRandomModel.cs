using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace ContentViewProject3.Models {
    public class VTuberRandomModel : BindableBase {
        public ObservableCollection<VTuberRandom> VTuberRandoms { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="i">リストの数</param>
        public VTuberRandomModel(int i = 1) {
            var items = Enumerable.Range(0, i).Select(x => new VTuberRandom());
            VTuberRandoms = new ObservableCollection<VTuberRandom>(items);
        }
    }
}
