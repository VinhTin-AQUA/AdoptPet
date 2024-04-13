import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { VolunteerRoleDto } from '../shared/models/volunteer-role/VolunteerRoleDto';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class VolunteerRoleService {
  private readonly baseApiUrl = environment.baseUrl + '/VolunteerRole';

  constructor(private http: HttpClient) { }
  
  addVolunteerRole(volunteerRoleDto: VolunteerRoleDto) {
    return this.http.post(`${this.baseApiUrl}/add-volunteerrole`,volunteerRoleDto);
  }

  getAllVolunteerRoles() {
    return this.http.get(`${this.baseApiUrl}/get-all-volunteerrole`);
  }

  softDelete(id: number) {
    return this.http.put(`${this.baseApiUrl}/soft-delete-volunteerrole/${id}`, {});
  }

}
