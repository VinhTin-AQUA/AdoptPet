import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { PetService } from '../../services/pet.service';
import { ColorService } from '../../services/color.service';
import { Color } from '../../shared/models/color/Color';
import { BreedService } from '../../services/breed.service';
import { Breed } from '../../shared/models/breed/breed';
import { PetDto } from '../../shared/models/pet/PetDto';
import { environment } from '../../../environments/environment.development';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
	selector: 'app-adopt',
	standalone: true,
	imports: [RouterLink, ReactiveFormsModule],
	templateUrl: './adopt.component.html',
	styleUrl: './adopt.component.scss',
})
export class AdoptComponent {
	pageNumber: number = 1;
	pageSize: number = 10;
	colors: Color[] = [];
	breeds: Breed[] = [];
	pets: PetDto[] = [];
	baseImg = environment.baseImgUrl;

	// search
	petSearchForm!: FormGroup;
	isSeached: boolean = false;

	constructor(
		private petService: PetService,
		private colourService: ColorService,
		private breedService: BreedService,
		private formBuilder: FormBuilder
	) {}

	ngOnInit() {
		this.getColor();
		this.getBreeds();
		this.getPets();

		this.petSearchForm = this.formBuilder.group({
			name: [''],
			breedNames: [[]],
			colourNames: [[]],
			gender: [0],
			desexed: [false],
			ageRange: [''],
		});
	}

	private getColor() {
		this.colourService.getAllColor(1, 60).subscribe({
			next: (res: any) => {
				// console.log(res.items);
				this.colors = res.items;
			},
			error: err => {
				console.log(err);
			},
		});
	}

	private getBreeds() {
		this.breedService.getAllBreed(1, 25).subscribe({
			next: (res: any) => {
				// console.log(res.data);
				this.breeds = res.data;
			},
			error: err => {
				console.log(err);
			},
		});
	}

	private getPets() {
		this.petService.getAllPets(this.pageNumber, this.pageSize).subscribe({
			next: (res: any) => {
				// console.log(res.data);
				this.pets = res.data;
			},
			error: err => {
				console.log(err);
			},
		});
	}

	previousPage() {
		this.pageNumber--;
		if (this.pageNumber <= 0) {
			this.pageNumber = 1;
		}
		if(this.isSeached === false) {
			this.getPets();
		} else {
			this.search()
		}
		
	}

	nextPage() {
		this.pageNumber++;
		if(this.isSeached === false) {
			this.getPets();
		} else {
			this.search()
		}
	}

	search() {
		this.isSeached = true;
		const dataSearch = {
			name: this.petSearchForm.controls['name'].value,
			breedNames: this.petSearchForm.controls['breedNames'].value,
			colourNames: this.petSearchForm.controls['colourNames'].value,
			gender: this.petSearchForm.controls['gender'].value,
			desexed: this.petSearchForm.controls['desexed'].value === '1',
			ageRange: this.petSearchForm.controls['ageRange'].value,
		};

		// console.log(dataSearch);
		this.petService.search(dataSearch, this.pageNumber, this.pageSize).subscribe({
			next: (res: any) => {
				// console.log(res.data);
				console.log(dataSearch);
				// console.log(res);
				
				if (res.data.length > 0) {
					this.pets = res.data;
				}
			},
			error: err => {
				console.log(err.error);
			},
		});
	}
}
