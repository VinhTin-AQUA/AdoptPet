import { Component, inject } from '@angular/core';
import { ActivatedRoute, Route } from '@angular/router';
import { PetfinderService } from '../services/petfinder.service';
import { LoadingStore } from '../shared/stores/loading.store';
import { patchState } from '@ngrx/signals';

@Component({
	selector: 'app-details',
	standalone: true,
	imports: [],
	templateUrl: './details.component.html',
	styleUrl: './details.component.scss',
})
export class DetailsComponent {
	id: string = '';
	name: string = '';
	health: string = '';
	breed: string = '';
	age: string = '';
	gender: string = '';
	size: string = '';
	description: string = '';
	status_changed_at: Date = new Date();
	published_at: Date = new Date();
	email: string = '';
	phone: string = '';
	address: string = '';
	city: string = '';
	state: string = '';
	postcode: string = '';
	country: string = '';
	photos: any = [];

	loadingStore = inject(LoadingStore);

	constructor(private activatedRoute: ActivatedRoute, private petService: PetfinderService) {}

	ngOnInit() {
		patchState(this.loadingStore, { isLoading: true });
		this.activatedRoute.params.subscribe({
			next: (params: any) => {
				console.log(params.id); // {id: '2', name: 'hoc'}
				this.id = params.id;
				this.getInfo();
			},
		});
	}

	private getInfo() {
		this.petService.getAnimal(this.id).subscribe({
			next: (res: any) => {
				// console.log(res);
				this.name = res.animal.name;
				this.breed = res.animal.breeds.primary;
				this.age = res.animal.age;
				this.gender = res.animal.gender;
				this.size = res.animal.size;
				this.description = res.animal.description;
				this.status_changed_at = res.animal.status_changed_at;
				this.published_at = res.animal.published_at;
				this.email = res.animal.contact.email;
				this.phone = res.animal.contact.phone;
				this.address = res.animal.contact.address.address1;
				this.city = res.animal.contact.address.city;
				this.state = res.animal.contact.address.state;
				this.postcode = res.animal.contact.address.postcode;
				this.country = res.animal.contact.address.country;
				this.photos = res.animal.photos;
				patchState(this.loadingStore, { isLoading: false });
			},
			error: err => {
				console.log(err);
				patchState(this.loadingStore, { isLoading: false });
			},
		});
	}
}
