import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
	providedIn: 'root',
})
export class PetfinderService {
	private accessToken: string = '';

	constructor(private http: HttpClient) {}

	private getAccessToken() {
		return new Promise(resolve => {
			const data = {
				grant_type: 'client_credentials',
				client_id: 'uehjuaxCWm5xM0cjeePkkWPIufyBxu27Goiew6uWQk0wlLVmSp',
				client_secret: 'rLhA90HKevqAaMjkQfMGQq4r7ooELZmjgBjtV55z',
			};
			this.http.post('https://api.petfinder.com/v2/oauth2/token', data).subscribe({
				next: (res: any) => {
					this.accessToken = res.access_token;
				},
				error: err => {
					console.log(err);
				},
			});
			resolve(1);
		});
	}

	async getBreeds(type: string) {
		await this.getAccessToken();
    console.log(type);
    
		return this.http.get(`https://api.petfinder.com/v2/types/${type}/breeds`, {
			headers: {
				Authorization: 'Bearer ' + this.accessToken,
			},
		});
	}
}
