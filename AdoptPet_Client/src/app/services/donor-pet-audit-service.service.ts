import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
	providedIn: 'root',
})
export class DonorPetAuditServiceService {
	private readonly baseApi = environment.baseUrl + '/donorpetaudit';

	constructor(private http: HttpClient) {}

	getAllDonorPetAudits() {
		return this.http.get(this.baseApi + '/get-all-donorpetaudit');
	}
}
