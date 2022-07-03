import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MenuItem } from 'primeng/api';
import { SuratMasuk } from '../_model/SuratMasuk';
import { PaginatedResult } from '../_model/Pagination';

@Injectable({
  providedIn: 'root'
})

export class DataService {
  baseUrl = environment.apiUrl + 'suratmasuk/';

  constructor(private http: HttpClient) { }

  getListSuratMasuk(page?: any, itemsPerPage?: any, prm?: any): Observable<PaginatedResult<SuratMasuk[]>> {
    const paginatedResult: PaginatedResult<SuratMasuk[]> = new PaginatedResult<SuratMasuk[]>();
    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('PageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }
    if (prm.dtft != null) {
      params = params.append('dtft', prm.dtft);
    }

    return this.http.get<SuratMasuk[]>(this.baseUrl, { observe: 'response', params})
    .pipe(
      map((response: any | null) => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResult;
      })
    );
  }

  addSuratMasuk(data: SuratMasuk): Observable<any> {
    return this.http.post(this.baseUrl, data);
  }

  editSuratMasuk(data: SuratMasuk, id: number): Observable<any> {
    return this.http.put(this.baseUrl + id, data);
  }

  deleteSuratMasuk(prm: any, id: number) {
    let params = new HttpParams();
    return this.http.delete(this.baseUrl + id, { observe: 'response', params});
  }

}
