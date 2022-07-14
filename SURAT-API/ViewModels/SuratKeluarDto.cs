using System;

namespace SURAT_API.ViewModels
{
    public class SuratKeluarDto
    {
        public int IdSuratKeluar { get; set; }
        public string? Title { get; set; }
        public string? NoLetter { get; set; }
        public string? Regarding { get; set; }
        public string? ToPerson { get; set; }
        public string? FromPerson { get; set; }
        public string? Message { get; set; }
        public DateTime Created { get; set; }
    }
}