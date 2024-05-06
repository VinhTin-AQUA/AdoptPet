import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { VolunteerAdd } from '../shared/models/volunteer/volunteer-add';

@Injectable({
	providedIn: 'root',
})
export class VolunteerService {
	private readonly baseApi = environment.baseUrl + '/volunteer';

	constructor(private http: HttpClient) {}

	getVolunteers(pageNumber: number = 1, pageSize: number = 20) {
		return this.http.get(
			`${this.baseApi}/get-all-volunteer/pageNumber/${pageNumber}/pageSize/${pageSize}`
		);
	}

	softDelete(volunteerId: number) {
		return this.http.delete(`${this.baseApi}/soft-delete/${volunteerId}`);
	}

	addVolunteer(model: VolunteerAdd) {
		return this.http.post(`${this.baseApi}/add-volunteer`, model);
	}
}
