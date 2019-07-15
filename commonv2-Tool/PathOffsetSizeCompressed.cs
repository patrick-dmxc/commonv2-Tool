using System;

namespace commonv2_Tool
{
    public struct PathOffsetSizeCompressed
    {
        public readonly string Path;
        public readonly UInt32 Offset;
        public readonly UInt32 Size;
        public readonly byte[] Compressed;
        public PathOffsetSizeCompressed(string path, UInt32 offset, UInt32 size, byte[] compressed)
        {
            this.Path = path;
            this.Offset = offset;
            this.Size = size;
            this.Compressed = compressed;
        }

        public override string ToString()
        {
            return Path;
        }
    }
}
