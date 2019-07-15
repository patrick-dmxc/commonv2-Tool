using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commonv2_Tool
{
    public class Recompiler
    {
        public string DecompiledDirectory { get; private set; }
        public string Commonv2_agz_Path { get; private set; }
        
        public Recompiler(string commonv2_agz_Path, string decompiledDirectory)
        {
            this.Commonv2_agz_Path = commonv2_agz_Path;
            this.DecompiledDirectory = decompiledDirectory;
        }

        public void RunRecompiler()
        {
            string[] fileNames = File.ReadAllLines($"{DecompiledDirectory}\\decompiledOrder.txt");


            int offset = (int) ((fileNames.Length+2) * 0x100);
            int newOffset = 0;
            int size = 0;
            List<PathOffsetSizeCompressed> files = new List<PathOffsetSizeCompressed>();
            foreach (string fileName in fileNames)
            {
                byte[] gzip = Compress(File.ReadAllBytes($"{DecompiledDirectory}\\{fileName}"));
                gzip[0x08] = 0x00;
                gzip[0x09] = 0x13;
                size = gzip.Length;
                files.Add(new PathOffsetSizeCompressed(fileName, (uint) offset, (uint) size, gzip));
                newOffset = offset + size;
                newOffset++;
                while (!Convert.ToString(newOffset, 8).EndsWith("000") || newOffset / 0x100 % 2 != 0)
                    newOffset++;
                offset = newOffset;
            }

            int totalFileLength = offset;

            //List<uint> blockCountList = new List<uint>();
            //for (int i = 0; i < files.Count - 1; i++)
            //{
            //    uint blockSize = files[i + 1].Offset - files[i].Offset;
            //    uint blockCount = blockSize / 0x100;
            //    blockCountList.Add(blockCount);
            //}
            using (var stream = File.OpenWrite(this.Commonv2_agz_Path))
            {
                foreach (var file in files)
                {
                    byte[] path = Encoding.ASCII.GetBytes(file.Path);
                    byte[] path2 = new byte[0xF8];
                    for (int i = 0; i < path.Length; i++)
                    {
                        path2[i] = path[i];
                    }
                    stream.Write(path2, 0, path2.Length);
                    stream.Write(BitConverter.GetBytes(file.Offset), 0, 4);
                    stream.Write(BitConverter.GetBytes(file.Size), 0, 4);
                }

                foreach (var file in files)
                {
                    while (stream.Position != file.Offset)
                        stream.WriteByte(0);
                    stream.Write(file.Compressed,0, file.Compressed.Length);
                }
                while (stream.Position != totalFileLength)
                    stream.WriteByte(0);
            }
            //using (FileStream fs = )
        //    {
        //        byte[] b = new byte[0x100];
        //        UTF8Encoding temp = new UTF8Encoding(true);

        //        //Read Pathes
        //        byte emptyPathes = 0;
        //        while (fs.Read(b, 0, b.Length) > 0)
        //        {
        //            string path = temp.GetString(b, 0, 0xf8).Replace("\0","");
        //            UInt32 offset = BitConverter.ToUInt32(b, 0xf8);
        //            UInt32 size = BitConverter.ToUInt32(b, 0xfc);
        //            if (offset != 0 && size != 0)
        //            {
        //                storedFiles.Add(new PathOffsetSize(path, offset, size));
        //            }
        //                else
        //            {
        //                emptyPathes++;
        //                if (emptyPathes == 2)
        //                    break;
        //            }
        //        }
        //        string savePath = $"{DecompiledDirectory}\\decompiledOrder.txt";
        //        string directory = Path.GetDirectoryName(savePath);
        //        if (!Directory.Exists(directory))
        //        {
        //            Directory.CreateDirectory(directory);
        //        }
        //        File.WriteAllLines(savePath,storedFiles.Select(p=>p.Path).ToArray());
        //        foreach (PathOffsetSize pathOffsetSize in storedFiles)
        //        {
        //            fs.Position = pathOffsetSize.Offset;
        //            byte[] gzip = new byte [pathOffsetSize.Size];
        //            fs.Read(gzip, 0, gzip.Length);
        //            byte[] decompressed = Decompress(gzip);
        //            savePath = $"{DecompiledDirectory}\\{pathOffsetSize.Path}";
        //            directory = Path.GetDirectoryName(savePath);
        //            if (!Directory.Exists(directory))
        //            {
        //                Directory.CreateDirectory(directory);
        //            }
        //            File.WriteAllBytes(savePath, decompressed);
        //        }
        //    }
        }
        public static byte[] Compress(byte[] data)
        {
            using (var compressedStream = new MemoryStream())
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                zipStream.Write(data, 0, data.Length);
                zipStream.Close();
                return compressedStream.ToArray();
            }
        }

    }
}
