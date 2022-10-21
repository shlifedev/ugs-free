using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Packages.ugs_free.Runtime.Core
{
    public class UGSStreamBuilder
    {
        private UGSStream stream = null;
        public UGSStreamBuilder()
        {
            stream = new UGSStream();
        }
        public UGSStreamBuilder BasePath(string basePath)
        {
            if (System.IO.Directory.Exists(basePath))
                System.IO.Directory.CreateDirectory(basePath);

            stream.basePath = basePath;
            return this;
        }
        public UGSStreamBuilder AddWriter(Action<FileStream> parser)
        {
            stream.parser.Add(parser);
            return this;
        }
        public UGSStreamBuilder AddReader(Action<FileStream> parser)
        {
            stream.reader.Add(parser);
            return this;
        }

        public UGSStream Build() => stream;
    }


    public class UGSStream
    {
        public List<Action<FileStream>> parser = null;
        public List<Action<FileStream>> reader = null;
        public string basePath;

        internal UGSStream()
        {
            parser = new List<Action<FileStream>>();
            reader = new List<Action<FileStream>>();
        }

        private string GetPath(string path) => Path.Combine(basePath, path);
        public byte[] Write(string path)
        {
            System.IO.Directory.CreateDirectory(GetPath(path));
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
