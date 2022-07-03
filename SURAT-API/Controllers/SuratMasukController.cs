using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SURAT_API.Models;
using SURAT_API.ViewModels;
using SURAT_API.Helpers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using SURAT_API.Data;

namespace SURAT_API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class SuratMasukController : ControllerBase
{
    private readonly IDataRepository _repo;
    // private readonly IMapper _mapper;

    public SuratMasukController(IDataRepository repo)
    {
        _repo = repo;
    }

    #region Surat Masuk
    [HttpGet]
    public async Task<IActionResult> GetListSuratMasuk([FromQuery] Params prm)
    {
        var data = await _repo.GetListSuratMasuk(prm);
        if (data.Count() == 0)
            return BadRequest("Data not found");
        Response.AddPagination(data.CurrentPage, data.PageSize, data.TotalCount, data.TotalPages);

        var res = data.Select(x => new SuratMasukDto()
        {
            IdSuratMasuk = x.Id,
            Title = x.Title,
            Regarding = x.Regarding,
            ToPerson = x.To_person,
            FromPerson = x.From_person,
            Message = x.Message,
            Created = HelperMethod.NumericToDate(x.Created_at)
        });

        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSuratMasuk(int id)
    {
        var data = await _repo.GetSuratMasuk(id);
        if (data == null)
            return BadRequest("Surat tidak ditemukan!");

        var res = new SuratMasukDto()
        {
            IdSuratMasuk = data.Id,
            Title = data.Title,
            Regarding = data.Regarding,
            ToPerson = data.To_person,
            FromPerson = data.From_person,
            Message = data.Message,
            Created = HelperMethod.NumericToDate(data.Created_at)
        };

        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> AddSuratMasuk(SuratMasukDto data)
    {
        var suratMasuk = new surat_masuk()
        {
            Title = data.Title,
            Regarding = data.Regarding,
            To_person = data.ToPerson,
            From_person = data.FromPerson,
            Message = data.Message,
            Created_at = HelperMethod.DateToNumeric(DateTime.Now),
            Created_time = HelperMethod.TimeToNumeric(DateTime.Now),
            Updated_at = HelperMethod.DateToNumeric(DateTime.Now),
            Updated_time = HelperMethod.TimeToNumeric(DateTime.Now)
        };
        _repo.Add<surat_masuk>(suratMasuk);

        if (await _repo.SaveAll())
            return Ok();

        throw new Exception("Failed to add surat masuk!");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditSuratMasuk(SuratMasukDto data, int id)
    {
        var suratMasuk = await _repo.GetSuratMasuk(id);
        if (suratMasuk == null)
            return BadRequest("Surat masuk not found!");

        suratMasuk.Title = data.Title;
        suratMasuk.Regarding = data.Regarding;
        suratMasuk.To_person = data.ToPerson;
        suratMasuk.From_person = data.FromPerson;
        suratMasuk.Message = data.Message;
        suratMasuk.Updated_at = HelperMethod.DateToNumeric(DateTime.Now);
        suratMasuk.Updated_time = HelperMethod.TimeToNumeric(DateTime.Now);

        if (await _repo.SaveAll())
            return Ok();

        throw new Exception("Failed to edit surat masuk!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSuratMasuk([FromQuery] Params prm, int id)
    {
        var suratMasuk = await _repo.GetSuratMasuk(id);
        if (suratMasuk == null)
            return BadRequest("Surat masuk not found!");

        _repo.Delete<surat_masuk>(suratMasuk);
        if (await _repo.SaveAll())
            return Ok();

        throw new Exception("Failed to delete surat masuk!");
    }
    #endregion
}