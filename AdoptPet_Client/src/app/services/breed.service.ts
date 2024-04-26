import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BreedService {
  private readonly baseUrl = environment.baseUrl + '/breed';

  constructor(private http: HttpClient) { }

  addBreed(form: FormData) {
    return this.http.post(`${this.baseUrl}/add-breed`,form)
  }

  getAllBreed() {
    return this.http.get(`${this.baseUrl}/get-all-breed`);
  }

  getBreedById(id: number) {
    return this.http.get(this.baseUrl + '/get-breed-by-id/' + id);
  }
  
}
