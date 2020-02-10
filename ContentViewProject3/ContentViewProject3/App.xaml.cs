using Prism;
using Prism.Ioc;
using ContentViewProject3.ViewModels;
using ContentViewProject3.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContentViewProject3.Models;
using Prism.Unity;
using Unity.Injection;
using Unity;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ContentViewProject3 {
    public partial class App {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized() {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<FastPage, FastPageViewModel>();

            // 引数無しでシングルトンならこれ
            //containerRegistry.RegisterSingleton<CoreModel>();

            // 引数渡すならこっち(但し基本的には使わないようにした方が良いと思われる)
            //var container = containerRegistry.GetContainer();
            //container.RegisterType<CoreModel>(new InjectionConstructor(20)); // DIに引数付ける
            //container.RegisterSingleton<CoreModel>(new InjectionConstructor(9)); // DIに引数付けてシングルトン
            containerRegistry.RegisterForNavigation<SecondPage, SecondPageViewModel>();
        }
    }
}
