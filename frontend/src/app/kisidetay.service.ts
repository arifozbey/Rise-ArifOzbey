import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { backendurl } from './BackendURL';

@Injectable({
  providedIn: 'root'
})
export class KisidetayService {
url=backendurl;
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  getData(kisiid:any){
    console.log(kisiid);
    return this.http.get(this.url.url+'/KisiDetay/'+kisiid);  //https://localhost:44382 webapi host url
  }

  postData(kisiid:any,formData:any){
    return this.http.post(this.url.url+'/KisiDetay/'+kisiid,formData);
  }

  putData(id:any,formData:any){
    return this.http.put(this.url.url+'/KisiDetay/'+id,formData);
  }
  deleteData(id:any){
    return this.http.delete(this.url.url+'/KisiDetay/'+id);
  }}
