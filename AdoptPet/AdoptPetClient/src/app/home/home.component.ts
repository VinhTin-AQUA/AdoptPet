import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PetfinderService } from '../services/petfinder.service';

@Component({
	selector: 'app-home',
	standalone: true,
	imports: [FormsModule],
	templateUrl: './home.component.html',
	styleUrl: './home.component.scss',
})
export class HomeComponent {
	petType: string = 'Dog';
	mile: string = '';
	// location: string = '';
	breed: string = '';
	age: string = '';
	size: string = '';
	gender: string = '';
	goodWith: string = '';
	color: string = '';
	page = 1;
	limit = 10;

	isShownTypes: boolean = false;
	isShownMiles: boolean = false;

	types: string[] = ['Dog', 'Cat', 'Rabbit', 'Horse', 'Bird', 'Barnyard'];
	miles: string[] = ['Any', '10', '25', '50', '100', 'Anywhere'];

	breeds: string[] = [];
	ages: string[] = ['Any', 'Kitten', 'Young', 'Adult', 'Senior'];
	sizes: string[] = ['Any', 'Small', 'Medium', 'Large', 'Extra Large'];
	genders: string[] = ['Any', 'Male', 'Female'];
	colors: string[] = [
		'Any',
		'Black',
		'Blue Cream',
		'Blue Point',
		'Calico',
		'Chocolate Point',
		'Cream Point',
		'Dilute Calico',
		'Dilute Tortoiseshell',
		'Flame Point',
		'Gray & White',
		'Lilac Point',
		'Orange & White',
		'Seal Point',
		'Smoke',
		'Torbie',
		'Tortoiseshell',
		'White',
	];

	animal: any;

	constructor(private petService: PetfinderService) {}

	ngOnInit() {
		this.petService.getBreeds(this.petType).subscribe({
			next: (res: any) => {
				// console.log(res);
				this.breeds = res.breeds.map((b: any) => b.name);
				this.breed = this.breeds[0];
				this.search();
			},
			error: err => {
				console.log(err);
			},
		});
	}

	private getBreeds() {
		this.petService.getBreeds(this.petType).subscribe({
			next: (res: any) => {
				// console.log(res);
				this.breeds = res.breeds.map((b: any) => b.name);
				this.breed = this.breeds[0];
				this.search();
			},
			error: err => {
				console.log(err);
			},
		});
	}

	search() {
		this.petService
			.getAnimals(
				this.petType,
				this.breed,
				this.age,
				this.size,
				this.gender,
				this.color,
				this.page,
				this.limit
			)
			.subscribe({
				next: (res: any) => {
					this.animal = res.animals;
					console.log(this.animal);
				},
				error: (err: any) => {
					console.log(err);
				},
			});
	}

	onShowType() {
		this.isShownTypes = !this.isShownTypes;
	}

	onShowMile() {
		this.isShownMiles = !this.isShownMiles;
	}

	onChooseType(type: string) {
		this.petType = type;
		this.onShowType();
		this.getBreeds();
	}

	onChooseMile(mile: string) {
		this.mile = mile;
		this.onShowMile();
		this.search();
	}

	onSearch() {
		console.log(this.petType);
		console.log(this.mile);
		// console.log(this.location);
		console.log(this.breed);
	}
}
