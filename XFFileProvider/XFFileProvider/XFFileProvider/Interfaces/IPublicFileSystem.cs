using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFFileProvider.Interfaces
{
    public interface IPublicFileSystem
    {
        IFolder PublicDownloadFolder { get; }
    }
}
