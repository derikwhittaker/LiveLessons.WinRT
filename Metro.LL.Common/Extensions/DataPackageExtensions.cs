using Windows.ApplicationModel.DataTransfer;

namespace Metro.LL.Common.Extensions
{
    public static class DataPackageExtensions
    {
        public static bool IsTextMessage(this DataPackageView dataPackage)
        {
            if ( dataPackage.Contains(StandardDataFormats.Text) )
            {
                return true;
            }
            
            return false;
        }

        public static bool IsUrlMessage(this DataPackageView dataPackage)
        {
            if (dataPackage.Contains(StandardDataFormats.Uri))
            {
                return true;
            }

            return false;         
        }

        public static bool IsImageMessage(this DataPackageView dataPackage)
        {
            if (dataPackage.Contains(StandardDataFormats.Bitmap))
            {
                return true;
            }

            return false;   
        }

        public static bool IsStorageItemsMessage(this DataPackageView dataPackage)
        {
            if (dataPackage.Contains(StandardDataFormats.StorageItems))
            {
                return true;
            }

            return false;   
        }
    }
}
