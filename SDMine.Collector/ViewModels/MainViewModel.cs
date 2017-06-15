using GalaSoft.MvvmLight;
using SDMine.Collector.Services;
using SDMine.Collector.Services.Collectors;
using System.Collections.ObjectModel;
using System.Linq;

namespace SDMine.Collector.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<FacebookPostItemViewModel> _facebookPostItems;

        public ObservableCollection<FacebookPostItemViewModel> List
        {
            get { return _facebookPostItems; }
            set
            {
                _facebookPostItems = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            List = new ObservableCollection<FacebookPostItemViewModel>();
            List.Add(new FacebookPostItemViewModel { Name = "text 1" });
            List.Add(new FacebookPostItemViewModel { Name = "text 1" });
            List.Add(new FacebookPostItemViewModel { Name = "text 1" });
            List.Add(new FacebookPostItemViewModel { Name = "text 1" });
            List.Add(new FacebookPostItemViewModel { Name = "text 1" });
            List.Add(new FacebookPostItemViewModel { Name = "text 1" });
            List.Add(new FacebookPostItemViewModel { Name = "text 1" });

            var pages = new CollectorPagesService().GetPages();
            if (pages.Any())
            {
                var pagesId = pages.Select(p => p.PageId).ToList();
                PostsCollector.Collect(pagesId);
            }
        }
    }
}
