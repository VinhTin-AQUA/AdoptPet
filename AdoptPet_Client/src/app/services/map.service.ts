import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
@Injectable({
  providedIn: 'root'
})
export class MapService {
  private apiUrl = environment.baseUrl + '/AdoptMap/geojson';;

  constructor(private http: HttpClient) { }

  getGeoJson(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
