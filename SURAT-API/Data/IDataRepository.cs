using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SURAT_API.Helpers;
using SURAT_API.Models;
using SURAT_API.ViewModels;
using SURAT_API.Helpers;

namespace SURAT_API.Data
{
    public interface IDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();

        #region surat_masuk

        Task<PagedList<surat_masuk>> GetListSuratMasuk(Params prm);
        Task<surat_masuk> GetSuratMasuk(int Id);

        #endregion

        #region surat_keluar

        Task<PagedList<surat_keluar>> GetListSuratKeluar(Params prm);
        Task<surat_keluar> GetSuratKeluar(int Id);

        #endregion
    }
}