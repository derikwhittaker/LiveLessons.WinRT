using Metro.LL.Common;
using Metro.LL.Common.Models;

namespace LL.SearchContracts.DataModel
{
    public class SearchItemModel : BaseViewModel
    {
        private readonly SimpleItem _simpleItem;
        private int _id;

        public SearchItemModel( SimpleItem simpleItem )
        {
            _simpleItem = simpleItem;
        }

        public int Id
        {
            get { return _simpleItem.Id; }
            set
            {
                _simpleItem.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _simpleItem.Name; }
            set
            {
                _simpleItem.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string ShortDescription
        {
            get { return _simpleItem.ShortDescription; }
            set
            {
                _simpleItem.ShortDescription = value;
                OnPropertyChanged("ShortDescription");
            }
        }

        public string FullDescription
        {
            get { return _simpleItem.FullDescription; }
            set
            {
                _simpleItem.FullDescription = value;
                OnPropertyChanged("FullDescription");
            }
        }

        public string ImagePath
        {
            get { return _simpleItem.ImagePath; }
            set
            {
                _simpleItem.ImagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }
    }
}