import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
	providedIn: 'root',
})
export class PetfinderService {
	private baseUrl = 'https://localhost:7012/api'; // url của BE - url sẽ hiển thị trên thanh URL khi chạy BE

	constructor(private http: HttpClient) {}

	getBreeds(type: string) {
		// tùy chỉnh url của BE
		// '/Pet/get-breeds?type=' : làm sao biết được => khi test API ở BE, thì url được hiển thị chi tiết trong lời gọi API
		const url = this.baseUrl + '/Pet/get-breeds?type=' + type;

		// gọi API
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
		// tùy chỉnh url của BE
		const url =
			this.baseUrl +
			`/Pet/get-animals?type=${type}&breed=${breed}&age=${age}&size=${size}&gender=${gender}&color=${color}&page=${page}&limit=${limit}`;

		// gọi API
		return this.http.get(url);
	}

	getAnimal(id: string) {

		// '/Pet/get-breeds?type=' : làm sao biết được => khi test API ở BE, thì url được hiển thị chi tiết trong lời gọi API
		const url = this.baseUrl + '/Pet/get-one?id=' + id;

		// gọi API
		return this.http.get(url);
	}
}
