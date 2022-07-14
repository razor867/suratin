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

public class SuratKeluarController : ControllerBase
{
    private readonly IDataRepository _repo;
    // private readonly IMapper _mapper;

    public SuratKeluarController(IDataRepository repo)
    {
        _repo = repo;
    }

    #region Surat Keluar
    [HttpGet]
    public async Task<IActionResult> GetListSuratKeluar([FromQuery] Params prm)
    {
        var data = await _repo.GetListSuratKeluar(prm);
        Response.AddPagination(data.CurrentPage, data.PageSize, data.TotalCount, data.TotalPages);

        var res = data.Select(x => new SuratKeluarDto()
        {
            IdSuratKeluar = x.Id,
            Title = x.Title,
            NoLetter = x.No_letter,
            Regarding = x.Regarding,
            ToPerson = x.To_person,
            FromPerson = x.From_person,
            Message = x.Message,
            Created = HelperMethod.NumericToDate(x.Created_at)
        });

        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSuratKeluar(int id)
    {
        var data = await _repo.GetSuratKeluar(id);
        if (data == null)
            return BadRequest("Surat tidak ditemukan!");

        var res = new SuratKeluarDto()
        {
            IdSuratKeluar = data.Id,
            Title = data.Title,
            NoLetter = data.No_letter,
            Regarding = data.Regarding,
            ToPerson = data.To_person,
            FromPerson = data.From_person,
            Message = data.Message,
            Created = HelperMethod.NumericToDate(data.Created_at)
        };

        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> AddSuratKeluar(SuratKeluarDto data)
    {
        var suratKeluar = new surat_keluar()
        {
            Title = data.Title,
            No_letter = data.NoLetter,
            Regarding = data.Regarding,
            To_person = data.ToPerson,
            From_person = data.FromPerson,
            Message = data.Message,
            Created_at = HelperMethod.DateToNumeric(DateTime.Now),
            Created_time = HelperMethod.TimeToNumeric(DateTime.Now),
            Updated_at = HelperMethod.DateToNumeric(DateTime.Now),
            Updated_time = HelperMethod.TimeToNumeric(DateTime.Now)
        };
        _repo.Add<surat_keluar>(suratKeluar);

        if (await _repo.SaveAll())
            return Ok();

        throw new Exception("Failed to add surat keluar!");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditSuratKeluar(SuratKeluarDto data, int id)
    {
        var suratKeluar = await _repo.GetSuratKeluar(id);
        if (suratKeluar == null)
            return BadRequest("Surat keluar not found!");

        suratKeluar.Title = data.Title;
        suratKeluar.No_letter = data.NoLetter;
        suratKeluar.Regarding = data.Regarding;
        suratKeluar.To_person = data.ToPerson;
        suratKeluar.From_person = data.FromPerson;
        suratKeluar.Message = data.Message;
        suratKeluar.Updated_at = HelperMethod.DateToNumeric(DateTime.Now);
        suratKeluar.Updated_time = HelperMethod.TimeToNumeric(DateTime.Now);

        if (await _repo.SaveAll())
            return Ok();

        throw new Exception("Failed to edit surat keluar!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSuratKeluar([FromQuery] Params prm, int id)
    {
        var suratKeluar = await _repo.GetSuratKeluar(id);
        if (suratKeluar == null)
            return BadRequest("Surat keluar not found!");

        _repo.Delete<surat_keluar>(suratKeluar);
        if (await _repo.SaveAll())
            return Ok();

        throw new Exception("Failed to delete surat keluar!");
    }
    #endregion
}