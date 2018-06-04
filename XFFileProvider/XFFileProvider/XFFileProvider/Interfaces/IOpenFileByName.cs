using System;
using System.Collections.Generic;
using System.Text;

namespace XFFileProvider.Interfaces
{
    public interface IOpenFileByName
    {
        void OpenFile(string fullFileName);

        void MakeDownloadFolder(string fullFileName, string mimeType);
    }
}
