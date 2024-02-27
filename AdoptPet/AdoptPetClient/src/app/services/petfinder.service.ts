import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
	providedIn: 'root',
})
export class PetfinderService {
	private accessToken: string = '';
	private baseUrl = 'https://localhost:7012/api';

	constructor(private http: HttpClient) {}

	getBreeds(type: string) {
		const url = this.baseUrl + '/Pet/get-breeds?type=' + type;
		return this.http.get(url);
	}

	getAnimals(
		type: string,
		breed: string,
		age: string,
		size: string,
		gender: string,
		color: string,
		page: number,
		limit: number
	) {
		const url =
			this.baseUrl +
			`/Pet/get-animals?type=${type}&breed=${breed}&age=${age}&size=${size}&gender=${gender}&color=${color}&page=${page}&limit=${limit}`;
		return this.http.get(url);
	}
}
