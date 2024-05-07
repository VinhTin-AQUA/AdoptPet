import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
	providedIn: 'root',
})
export class LocationService {
	private readonly baseApi = environment.baseUrl + '/location';

	constructor(private http: HttpClient) {}

	getProvices() {
		return this.http.get('https://vapi.vnappmob.com/api/province');
	}

	getDistricts(provinceId: string) {
		return this.http.get('https://vapi.vnappmob.com/api/province/district/' + provinceId);
	}

	getWards(districtId: string) {
		return this.http.get('https://vapi.vnappmob.com/api/province/ward/' + districtId);
	}

	getSavedLocation(pageNumber: number, pageSize: number) {
		return this.http.get(this.baseApi + `/get-all-location?pageNumber=${pageNumber}&pageSize=${pageSize}`);
	}
}
