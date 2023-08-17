import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "http://10.1.45.26:1234/api/";

  constructor(private http: HttpClient) { }

  getAuthorizedData(): HttpHeaders {
    const jwt = localStorage.getItem('jwt');
    if (jwt) {
      const headers = new HttpHeaders({
        'Authorization': `Bearer ${jwt}` // Thêm JWT vào header Authorization
      });
      return headers;
    }
    return new HttpHeaders();
  }

  // getAllCategories(val: any): Observable<any> {
  //   return this.http.get<any>("https://localhost:7195/api/" + 'Categories', val);
  // }

  getAllCategories(searchTerm: any): Observable<any> {
    let params = new HttpParams();
    if (searchTerm) {
      params = params.set('searchTerm', searchTerm);
    }
  
    return this.http.get<any>(this.APIUrl + 'Categories', { params });
  }

  createCategories(val: any) {
    const headers = this.getAuthorizedData();
    return this.http.post(this.APIUrl + 'Categories', val, { headers });
  }

  updateCategories(id : any, val: any) {
    const headers = this.getAuthorizedData();
    return this.http.put<any>(this.APIUrl + 'Categories/' + id, val, { headers });
  }

  deleteCategories(val: any) {
    const headers = this.getAuthorizedData();
    return this.http.delete<any>(this.APIUrl + 'Categories/' + val, { headers });
  }

  getAllProducts(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + 'Products');
  }

  login(user: any) {
    return this.http.post<any>(this.APIUrl + 'Users/login', user);
  }
}
