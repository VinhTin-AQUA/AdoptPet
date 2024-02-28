import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PetfinderService } from '../services/petfinder.service';
import { LoadingStore } from '../shared/stores/loading.store';
import { patchState } from '@ngrx/signals';

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
	current_page = 1;
	limit = 12;

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

	animals: any = [];
	total_pages: number = 0;
	animalTemps = [
		{
			name: 'Coco Pebbles',
			age: 'Young',
			breed: 'Affenpinscher',
			photos: [
				{
					small: 'https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/70844219/1/?bust=1708864906&width=300',
				},
			],
		},
		{ name: 'Coco Pebbles', age: 'Young', breed: 'Affenpinscher', photos: [] },
		{ name: 'Coco Pebbles', age: 'Young', breed: 'Affenpinscher', photos: [] },
		{
			name: 'Coco Pebbles',
			age: 'Young',
			breed: 'Affenpinscher',
			photos: [
				{
					small: 'https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/70844219/2/?bust=1708864907&width=600',
				},
			],
		},
		{ name: 'Coco Pebbles', age: 'Young', breed: 'Affenpinscher', photos: [] },
		{
			name: 'Coco Pebbles',
			age: 'Young',
			breed: 'Affenpinscher',
			photos: [
				{
					small: 'https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/70844219/2/?bust=1708864907&width=600',
				},
			],
		},
		{ name: 'Coco Pebbles', age: 'Young', breed: 'Affenpinscher', photos: [] },
		{ name: 'Coco Pebbles', age: 'Young', breed: 'Affenpinscher', photos: [] },
		{ name: 'Coco Pebbles', age: 'Young', breed: 'Affenpinscher', photos: [] },
		{
			name: 'Coco Pebbles',
			age: 'Young',
			breed: 'Affenpinscher',
			photos: [
				{
					small: 'https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/70843457/1/?bust=1708921425&width=100',
				},
			],
		},
		{ name: 'Coco Pebbles', age: 'Young', breed: 'Affenpinscher', photos: [] },
		{ name: 'Coco Pebbles', age: 'Young', breed: 'Affenpinscher', photos: [] },
		{ name: 'Coco Pebbles', age: 'Young', breed: 'Affenpinscher', photos: [] },
	];
	loadingStore = inject(LoadingStore);

	constructor(private petService: PetfinderService) {}

	ngOnInit() {
		
		this.getBreeds()
	}

	private getBreeds() {
		patchState(this.loadingStore, {isLoading: true});
		this.petService.getBreeds(this.petType).subscribe({
			next: (res: any) => {
				// console.log(res);
				this.breeds = res.breeds.map((b: any) => b.name);
				this.breed = this.breeds[0];
				this.search();
			},
			error: err => {
				console.log(err);
				patchState(this.loadingStore, {isLoading: false});
			},
		});
	}

	preStack() {
		this.isShownMiles = false;
		this.isShownTypes = false;
	}

	search() {
		patchState(this.loadingStore, {isLoading: true});
		this.petService
			.getAnimals(
				this.petType,
				this.breed,
				this.age,
				this.size,
				this.gender,
				this.color,
				this.current_page,
				this.limit
			)
			.subscribe({
				next: (res: any) => {
					this.animals = res.animals;
					this.total_pages = res.pagination.total_pages;
					// console.log(this.animals);
					patchState(this.loadingStore, {isLoading: false});
				},
				error: (err: any) => {
					console.log(err);
					patchState(this.loadingStore, {isLoading: false});
				},
			});
	}

	onShowType(event: any) {
		event.stopPropagation();
		this.isShownTypes = !this.isShownTypes;
	}

	onShowMile(event: any) {
		event.stopPropagation();
		this.isShownMiles = !this.isShownMiles;
	}

	onChooseType(type: string, event: any) {
		event.stopPropagation();
		this.current_page = 1;
		this.age = '';
		this.size = '';
		this.gender = '';
		this.color = '';
		this.petType = type;
		this.preStack();
		this.getBreeds();
	}

	onChooseMile(mile: string, event: any) {
		event.stopPropagation();
		this.mile = mile;
		this.preStack();
		this.search();
	}

	onSearch() {
		console.log(this.petType);
		console.log(this.mile);
		// console.log(this.location);
		console.log(this.breed);
	}

	onNextPage() {
		if (this.current_page === this.total_pages) {
			return;
		}
		this.current_page++;
		this.search();
	}

	onPrePage() {
		if (this.current_page === 1) {
			return;
		}
		this.current_page--;
		this.search();
	}

	breeedChange(event: any) {
		event.stopPropagation();
	}

	ageChange(event: any) {
		event.stopPropagation();
		// this.age = event.target.value;
		this.search();
	}

	sizeChange(event: any) {
		event.stopPropagation();
		// this.size = event.target.value;
		this.search();
	}

	genderChange(event: any) {
		event.stopPropagation();
		// this.gender = event.target.value;
		this.search();
	}

	colorChange(event: any) {
		event.stopPropagation();
		// this.color = event.target.value;
		this.search();
	}
}
