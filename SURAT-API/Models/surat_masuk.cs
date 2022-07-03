using System;

namespace SURAT_API.Models
{
    public class surat_masuk
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Regarding { get; set; }
        public string? To_person { get; set; }
        public string? From_person { get; set; }
        public string? Message { get; set; }
        public decimal Created_at { get; set; }
        public decimal Created_time { get; set; }
        public decimal Updated_at { get; set; }
        public decimal Updated_time { get; set; }
    }
}