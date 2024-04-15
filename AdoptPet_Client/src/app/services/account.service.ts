import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { SignUp } from '../shared/models/account/SignUp';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private readonly baseApUrl = environment.baseUrl + '/account';

  constructor(private http: HttpClient) { }

  signup(model: SignUp) {
    return this.http.post(`${this.baseApUrl}/sign-up`,model);
  }

  confirmEmail(email: string, token: string) {
    return this.http.put(`${this.baseApUrl}/confirm-email`,{email: email, token: token});
  }

  signin() {

  }


}
