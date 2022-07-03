using System;

namespace SURAT_API.Helpers
{
    public class Params
    {
        private const int MaxPageSize = 3000;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public string? dtft { get; set; }
    }
}