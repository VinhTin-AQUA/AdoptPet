import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class PetService {

  private readonly baseApi = environment.baseUrl + '/pet';

  constructor(private http: HttpClient) {}

  getAllPets() {
    return this.http.get(this.baseApi + '/')
  }
}
