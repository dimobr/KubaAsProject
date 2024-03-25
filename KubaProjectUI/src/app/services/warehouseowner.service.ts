import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class WarehouseownerService {

  constructor(private http: HttpClient) { }

  getOwnerById(id: number): Observable<any> {
    let params = new HttpParams().set('id', id.toString());
    return this.http.get<any>('api/getOwner', { params });
  }
}
