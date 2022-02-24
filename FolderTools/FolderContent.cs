
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderTools
{
    public class FolderContent
    {

        private List<FolderContent> folders = new List<FolderContent>();
        public List<FolderContent> Folders { get { return folders; } set { folders = value; } }

        private List<FileContent> files = new List<FileContent>();
        public List<FileContent> Files { get { return files; } set { files = value; } }

        private string fullName;
        public string FullNmae { get { return fullName; } }

        private long fileContentSize;
        public long FileContentSize { get { return fileContentSize; } set { fileContentSize = value; } }

        private long folderContentSize;
        public long FolderContentSize { get { return folderContentSize; } set { folderContentSize = value; } }

        public int ItemCount { get { return folders?.Count ?? 0; } }

        private DirectoryInfo di;
        public FolderContent(string folder)
        {
            fullName = folder;
            di = new DirectoryInfo(fullName);
            SetDirectories();
        }

        internal void SetDirectories()
        {
            if (!string.IsNullOrEmpty(fullName))
            {
                if (di!=null && di.Exists)
                {
                    FileInfo[] fileInfos = di.GetFiles();
                    foreach (FileInfo file in fileInfos)
                    {
                        files.Add(new FileContent(file));
                        folderContentSize += file.Length;
                    }
                    fileContentSize = folderContentSize;
                    DirectoryInfo[] dirs = di.GetDirectories();
                    foreach (DirectoryInfo dir in dirs)
                    {
                        FolderContent newContent = new FolderContent(dir.FullName);
                        folders.Add(newContent);
                        folderContentSize += newContent.FolderContentSize;
                    }
                }

            }
        }

        public override string ToString()
        {
            return $"{fullName} {folders.Count} {folderContentSize} {fileContentSize}";
        }
    }
}