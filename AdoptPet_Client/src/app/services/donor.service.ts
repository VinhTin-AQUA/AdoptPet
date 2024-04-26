import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class DonorService {
  private readonly baseApi = environment.baseUrl + '/donor';

  constructor(private http: HttpClient) { }

  getAllDonors() {
    return this.http.get(this.baseApi + '/get-all-donor');
  }

  softDeleteDonor(donorId: number) {
    return this.http.put(this.baseApi + '/soft-delete-donor/' + donorId, null);
  }
}
