import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { PetService } from '../../services/pet.service';
import { ColorService } from '../../services/color.service';
import { Color } from '../../shared/models/color/Color';
import { BreedService } from '../../services/breed.service';
import { Breed } from '../../shared/models/breed/breed';
import { PetDto } from '../../shared/models/pet/PetDto';
import { environment } from '../../../environments/environment.development';

@Component({
	selector: 'app-adopt',
	standalone: true,
	imports: [RouterLink],
	templateUrl: './adopt.component.html',
	styleUrl: './adopt.component.scss',
})
export class AdoptComponent {
	pageNumber: number = 1;
	pageSize: number = 5;
	colors: Color[] = [];
	breeds: Breed[] = [];
	pets: PetDto[] = [];
	baseImg = environment.baseImgUrl;


	constructor(
		private petService: PetService,
		private colourService: ColorService,
		private breedService: BreedService
	) {}

	ngOnInit() {
		this.getColor();
		this.getBreeds();
		this.getPets();
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
		if(this.pageNumber <= 0) {
			this.pageNumber = 1
		}
		this.getPets();
	}

	nextPage() {
		this.pageNumber++;
		this.getPets();
	}

	search () {
		
	}
}
