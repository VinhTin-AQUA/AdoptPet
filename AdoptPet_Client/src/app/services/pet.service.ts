import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class PetService {

  private readonly baseApi = environment.baseUrl + '/pets';

  constructor(private http: HttpClient) {}

  getAllPets(pageNumber: number, pageSize: number) {
    return this.http.get(this.baseApi + `/get-all-pets?pageNumber=${pageNumber}&pageSize=${pageSize}`)
  }

  getPet(petId: number) {
    return this.http.get(this.baseApi + '/get-pet-by-id/' + petId);
  }

  addPet(pet: any) {
    return this.http.post(this.baseApi + `/add-pet`,pet)
  }

  search(dataSearch: any, pageNumber: number, pageSize: number) {

    let breedNames = '';
    for(let b of dataSearch.breedNames) {
      breedNames += 'breedNames='+ b + '&'
    }

    let colourNames = '';
    for(let b of dataSearch.colourNames) {
      colourNames += 'colourNames='+ b + '&'
    }

    return this.http.get(this.baseApi + `/search-by-criteria?${breedNames}name=${dataSearch.name}&${colourNames}&gender=${dataSearch.gender}&desexed=${dataSearch.desexed}&ageRange=${dataSearch.ageRange}&pageNumber=${pageNumber}&pageSize=${pageSize}`,dataSearch)
  }

  deletePet(id: number) {
    return this.http.delete(this.baseApi + `/soft-delete-pet/${id}`)
  }
}
