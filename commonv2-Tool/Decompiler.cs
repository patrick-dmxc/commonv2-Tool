using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commonv2_Tool
{
    public class Decompiler
    {
        public string DecompiledFileTargetPath { get; private set; }
        public string Commonv2_agz_Path { get; private set; }

        public List<PathOffsetSize> storedFiles= new List<PathOffsetSize>();
        public IReadOnlyCollection<PathOffsetSize> StoredFiles
        {
            get { return storedFiles.AsReadOnly(); }
        }
        public Decompiler(string commonv2_agz_Path, string decompiledFileTargetPath)
        {
            this.Commonv2_agz_Path = commonv2_agz_Path;
            this.DecompiledFileTargetPath = decompiledFileTargetPath;
        }

        public void RunDecompiler()
        {
            using (FileStream fs = File.OpenRead(this.Commonv2_agz_Path))
            {
                byte[] b = new byte[0x100];
                UTF8Encoding temp = new UTF8Encoding(true);

                //Read Pathes
                byte emptyPathes = 0;
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    string path = temp.GetString(b, 0, 0xf8).Replace("\0","");
                    UInt32 offset = BitConverter.ToUInt32(b, 0xf8);
                    UInt32 size = BitConverter.ToUInt32(b, 0xfc);
                    if (offset != 0 && size != 0)
                    {
                        storedFiles.Add(new PathOffsetSize(path, offset, size));
                    }
                        else
                    {
                        emptyPathes++;
                        if (emptyPathes == 2)
                            break;
                    }
                }
                string savePath = $"{DecompiledFileTargetPath}\\decompiledOrder.txt";
                string directory = Path.GetDirectoryName(savePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                File.WriteAllLines(savePath,storedFiles.Select(p=>p.Path).ToArray());
                foreach (PathOffsetSize pathOffsetSize in storedFiles)
                {
                    fs.Position = pathOffsetSize.Offset;
                    byte[] gzip = new byte [pathOffsetSize.Size];
                    fs.Read(gzip, 0, gzip.Length);
                    byte[] decompressed = Decompress(gzip);
                    savePath = $"{DecompiledFileTargetPath}\\{pathOffsetSize.Path}";
                    directory = Path.GetDirectoryName(savePath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    File.WriteAllBytes(savePath, decompressed);
                }
            }
            //List< uint> blockCountList= new List<uint>();
            //for (int i = 0; i < this.storedFiles.Count - 1; i++)
            //{
            //    uint blockSize = this.storedFiles[i + 1].Offset - this.storedFiles[i].Offset;
            //    uint blockCount = blockSize / 0x100;
            //    blockCountList.Add(blockCount);
            //}
        }
        static byte[] Decompress(byte[] gzip)
        {
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            using (GZipStream stream = new GZipStream(new MemoryStream(gzip),
                CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }
    }
}
