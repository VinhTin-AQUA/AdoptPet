import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GoogleService {

  constructor() { }

  saveCredential(credential: string) {
    localStorage.setItem('credential', credential);
  }

  clearCredential() {
    localStorage.removeItem('credential')
  }
  
  getCredential() {
    return localStorage.getItem('credential')
  }
}
