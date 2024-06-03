import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class VolunteerAuditService {
  private readonly baseApiUrl = environment.baseUrl + '/VolunteerRole';

  constructor() { }

  getVolunteerAudits(pageNumber: number, pageSize: number) {
    
	}
}
