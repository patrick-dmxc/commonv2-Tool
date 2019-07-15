using System;

namespace commonv2_Tool
{
    public struct PathOffsetSize
    {
        public readonly string Path;
        public readonly UInt32 Offset;
        public readonly UInt32 Size;
        public PathOffsetSize(string path, UInt32 offset, UInt32 size)
        {
            this.Path = path;
            this.Offset = offset;
            this.Size = size;
        }

        public override string ToString()
        {
            return Path;
        }
    }
}
