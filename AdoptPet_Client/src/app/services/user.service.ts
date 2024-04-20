import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly baseUrl = environment.baseUrl + '/user'
  constructor(private http: HttpClient) { }

  getAllUsers() {
    return this.http.get(`${this.baseUrl}/get-all-users`);
  }
}
