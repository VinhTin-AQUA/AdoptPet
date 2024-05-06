import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { VolunteerRoleAdd } from '../shared/models/volunteer/volunteer-role-add';

@Injectable({
  providedIn: 'root'
})
export class VolunteerRoleService {
  private readonly baseApiUrl = environment.baseUrl + '/VolunteerRole';

  constructor(private http: HttpClient) { }
  
  addVolunteerRole(volunteerRoleDto: VolunteerRoleAdd) {
    return this.http.post(`${this.baseApiUrl}/add-volunteerrole`,volunteerRoleDto);
  }

  getAllVolunteerRoles() {
    return this.http.get(`${this.baseApiUrl}/get-all-volunteerrole`);
  }

  softDelete(id: number) {
    return this.http.put(`${this.baseApiUrl}/soft-delete-volunteerrole/${id}`, {});
  }
}
