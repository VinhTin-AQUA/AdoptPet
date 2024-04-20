import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { SignUp } from '../shared/models/account/SignUp';
import { jwtDecode } from 'jwt-decode';
import { patchState } from '@ngrx/signals';
import { UserStore } from '../shared/stores/UserStore';

@Injectable({
	providedIn: 'root',
})
export class AccountService {
	private readonly baseApUrl = environment.baseUrl + '/account';
	private readonly jwtKey = 'adopt-pet';
	userStore = inject(UserStore);

	constructor(private http: HttpClient) {}

	signup(model: SignUp) {
		return this.http.post(`${this.baseApUrl}/sign-up`, model);
	}

	confirmEmail(email: string, token: string) {
		return this.http.put(`${this.baseApUrl}/confirm-email`, { email: email, token: token });
	}

	signin(email: string, password: string) {
		return this.http.post(`${this.baseApUrl}/sign-in`, { email: email, password: password });
	}

	saveJwt(token: string) {
		localStorage.setItem(this.jwtKey, token);
	}

	getJwt() {
		const token = localStorage.getItem(this.jwtKey);
		return token;
	}

	private clearJwt() {
		localStorage.removeItem(this.jwtKey);
	}

	checkSignIn(token: string) {
		var decoded: any = jwtDecode(token);

		patchState(this.userStore, {
			id: decoded.nameid,
			email: decoded.email,
			firstName: decoded.firstName,
			lastName: decoded.lastName,
			phoneNumber: decoded.phoneNumber,
			loggedIn: true,
		});
	}

	checkSignOut() {
		this.clearJwt();
		patchState(this.userStore, {
			id: '',
			email: '',
			firstName: '',
			lastName: '',
			phoneNumber: '',
			loggedIn: false,
		});
	}
}
