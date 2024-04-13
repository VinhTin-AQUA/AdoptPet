import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
	providedIn: 'root',
})
export class ColorService {
	private readonly baseApiUrl = environment.baseUrl + '/colour';

	constructor(private http: HttpClient) {}

	addColor(colorName: string) {
		return this.http.post(`${this.baseApiUrl}/add-colour`, { colourName: colorName });
	}

	getAllColor() {
		return this.http.get(`${this.baseApiUrl}/get-all-colour`);
	}

	softDeleteColor(id: number) {
		return this.http.put(`${this.baseApiUrl}/soft-delete-colour/${id}`, {});
	}
}
