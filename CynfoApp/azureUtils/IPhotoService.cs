using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CynfoApp.azureUtils
{
    public interface IPhotoService
    {
        void CreateAndConfigureAsync();
        Task<string> UploadPhotoAsync(HttpPostedFileBase photoToUpload);
    }
}