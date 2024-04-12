import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor(private http: HttpClient) { }

  getProvices() {
    return this.http.get('https://vapi.vnappmob.com/api/province');
	}

  getDistricts(provinceId: string) {
    return this.http.get('https://vapi.vnappmob.com/api/province/district/' + provinceId)
	}

	getWards(districtId: string) {
    return this.http.get('https://vapi.vnappmob.com/api/province/ward/' + districtId)
	}
}
