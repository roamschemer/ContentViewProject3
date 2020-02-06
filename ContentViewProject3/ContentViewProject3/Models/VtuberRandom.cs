using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContentViewProject3.Models {
    public class VTuberRandom : BindableBase {
        public string Name { get => name; set => SetProperty(ref name, value); }
        private string name;
        public int Count { get => count; set => SetProperty(ref count, value); }
        private int count;
        
        private readonly int seed;

        public VTuberRandom() {
            seed = Environment.TickCount;
        }

        public void RundomNameSet() {
            var a2p = new[] {
                "九条林檎","九条棗","九条杏子","九条茘枝",
                "雨ヶ崎笑虹","都三代らみょん","三田そにあ","縁うか","ひなわんこ",
                "巻乃もなか","幸糖ミュウミュウ","青咲ローズ","泡沫調",
                "白乃クロミ","碧惺スキア","紫吹ふうか","菜花なな",
                "結目ユイ","水瀬しあ"
            };
            //抽選
            Random rnd = new System.Random(seed);
            var no = rnd.Next(0, a2p.Count());
            Name = a2p[no];
            Count++;
        }
    }
}
