using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Packages.ugs_free.Runtime.Core
{ 
    public class UGSStream
    {
        private List<Action<FileStream>> parser = null;
        private List<Action<FileStream>> reader = null;
        private string basePath;
        public UGSStream(string basePath, List<Action<FileStream>> writePostProcessorActions, List<Action<FileStream>> readPreProcessor)
        {
            if(System.IO.Directory.Exists(basePath))
               System.IO.Directory.CreateDirectory(basePath);
    
            this.basePath = basePath;
            parser = writePostProcessorActions;
            reader = readPreProcessor;
        }

        private string GetPath(string path) => Path.Combine(basePath, path);
        public byte[] Write(string path)
        {
            byte[] fileData = null;
            using (var stream = Open(GetPath(path)))
            {
                lock (stream)
                {
                    if (parser != null)
                    {
                        foreach (var parseCallback in parser)
                        {
                            parseCallback?.Invoke(stream);
                        }
                    }
                    stream.Close();
                }
                stream.Dispose();
            }

            return fileData = Read(path);
        } 

        public byte[] Read(string path)
        {
            byte[] fileData = null;
            using (var stream = Open(GetPath(path)))
            {
                lock (stream)
                {
                    if (parser != null)
                    {
                        foreach (var parseCallback in reader)
                        {
                            parseCallback?.Invoke(stream);
                        }
                    }

                    using (BinaryReader binaryReader = new BinaryReader(stream))
                    {
                        fileData = binaryReader.ReadBytes((int)stream.Length);
                    }

                    stream.Close();
                }
                stream.Dispose();
            }

            return fileData;
        }


        public string ReadAllText(string path) => System.IO.File.ReadAllText(GetPath(path));
        public byte[] ReadAllBytes(string path) => System.IO.File.ReadAllBytes(GetPath(path));

        public FileStream Open(string path)
        {
            return new FileStream(path, FileMode.OpenOrCreate);
        }
    }
}
