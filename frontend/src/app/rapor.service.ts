import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { backendurl } from './BackendURL';

@Injectable({
  providedIn: 'root'
})
export class RaporService {

  url=backendurl;
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  getData(){

    return this.http.get(this.url.url+'/Rapor');  //https://localhost:44382 webapi host url
  }

  postData(konum:any){
    return this.http.post(this.url.url+'/Rapor',konum);
  }

  Detay(id:any){
    return this.http.get(this.url.url+'/Rapor/'+id);
  }
  deleteData(id:any){
    return this.http.delete(this.url.url+'/Rapor/'+id);
  }
}
