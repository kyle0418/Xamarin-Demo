using System;
using System.Collections.Generic;
using System.Text;

namespace saveimage
{
    public interface ISavePhotoService
    {
        void SaveImageFromByte(byte[] imageByte, string filename);
    }
}
