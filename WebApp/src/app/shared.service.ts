import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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

  getAllCategories(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + 'Categories');
  }

  createCategories(val: any) {
    const headers = this.getAuthorizedData();
    return this.http.post(this.APIUrl + 'Categories', val, { headers });
  }

  updateCategories(val: any) {
    const headers = this.getAuthorizedData();
    return this.http.put<any>(this.APIUrl + 'Categories', val, { headers });
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
