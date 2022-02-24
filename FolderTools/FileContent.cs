using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FolderTools
{
    public class FileContent
    {
        public string FileName { get; set; }

        public long Size { get; set; }
        public FileContent(FileInfo info)
        {
            FileName = info.Name;
            Size = info.Length;
        }
        public override string ToString()
        {
            return $"{FileName} {Size}";
        }
    }
}
