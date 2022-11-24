import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Service } from '../_models/Service';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  private baseUrl: String = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getService(id: number) {
    return this.http.get<Service>(this.baseUrl + 'services/' + id);
  }

  getServices() {
    return this.http.get<Service[]>(this.baseUrl + 'services/');
  }

  addService(service: Service){
    return this.http.post<Service>(this.baseUrl + 'services/', service);
  }

  updateService(id: number, service: Service){
    return this.http.put<Service>(this.baseUrl + 'services/' + id, service);
  }

  deleteService(id: number){
    return this.http.delete(this.baseUrl + 'services/' + id);
  }
}