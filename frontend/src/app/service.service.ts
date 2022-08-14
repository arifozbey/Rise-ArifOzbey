import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders }    from '@angular/common/http';
import { backendurl } from './BackendURL';
@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  url=backendurl;
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  getData(){

    return this.http.get(this.url.url+'/CRUD');  //https://localhost:44382 webapi host url
  }

  postData(formData:any){
    return this.http.post(this.url.url+'/CRUD',formData);
  }

  putData(id:any,formData:any){
    return this.http.put(this.url.url+'/CRUD/'+id,formData);
  }
  deleteData(id:any){
    return this.http.delete(this.url.url+'/CRUD/'+id);
  }
 }
