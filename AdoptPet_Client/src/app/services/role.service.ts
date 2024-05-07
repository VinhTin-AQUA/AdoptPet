import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  private readonly baseApiUrl = environment.baseUrl + '/role';

  constructor(private http: HttpClient) { }

  getAllRoles(pageNumber: number, pageSize: number) {
    return this.http.get(`${this.baseApiUrl}/get-all-roles?pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }

  addRole(form: FormData) {
    return this.http.post(`${this.baseApiUrl}/create-role`, form);
  }

  deleteRole(id: string) {
    return this.http.delete(`${this.baseApiUrl}/delete-role/${id}`);
  }
}
