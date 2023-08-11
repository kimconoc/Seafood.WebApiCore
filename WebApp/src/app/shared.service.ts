import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "http://10.1.45.26:1234/api/";

  constructor(private http:HttpClient) { }

  getAllCategories():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'Categories');
  }

  createCategories(val:any){
    return this.http.post(this.APIUrl+'Categories', val);
  }

  updateCategories(val:any){
    return this.http.put<any>(this.APIUrl+'Categories', val);
  }

  deleteCategories(val:any){
    return this.http.delete<any>(this.APIUrl+'Categories'+val);
  }

  getAllProducts():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'Products');
  }
}
