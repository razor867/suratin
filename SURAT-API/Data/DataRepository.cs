using System;
using System.Linq;
using System.Collections.Generic;
using SURAT_API.Models;
using SURAT_API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Data;
using SURAT_API.Helpers;

namespace SURAT_API.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly SuratinContext context;

        public DataRepository(SuratinContext _context)
        {
            context = _context;
        }

        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }
        public async Task<bool> SaveAll()
        {
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<PagedList<surat_masuk>> GetListSuratMasuk(Params prm)
        {
            var query = context.surat_masuk
                .OrderByDescending(x => x.Created_at).ThenByDescending(x => x.Created_time)
                .AsQueryable();

            if (!string.IsNullOrEmpty(prm.dtft))
                query = query.Where(x => x.Created_at == Convert.ToDecimal(prm.dtft));

            return await PagedList<surat_masuk>.CreateAsync(query, prm.PageNumber, prm.PageSize);
        }
        public async Task<surat_masuk> GetSuratMasuk(int Id)
        {
            return await context.surat_masuk.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}