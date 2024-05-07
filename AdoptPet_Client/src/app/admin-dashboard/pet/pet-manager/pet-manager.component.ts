import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { PetService } from '../../../services/pet.service';
import { PetDto } from '../../../shared/models/pet/PetDto';

@Component({
	selector: 'app-pet-manager',
	standalone: true,
	imports: [RouterLink],
	templateUrl: './pet-manager.component.html',
	styleUrl: './pet-manager.component.scss',
})
export class PetManagerComponent {
	pageSize: number = 8;
	pageNumber: number = 1;
	pets: PetDto[] = [];

	constructor(private petService: PetService) {}

	ngOnInit() {
		this.getPets();
	}

	private getPets() {
		this.petService.getAllPets(this.pageNumber, this.pageSize).subscribe({
			next: (res: any) => {
				// console.log(res.data);
				this.pets = res.data;
			},
			error: err => {
				console.log(err.error);
			},
		});
	}

	onPrevPage() {
		this.pageNumber--;
		if (this.pageNumber < 1) {
			this.pageNumber = 1;
		}
		this.getPets();
	}

	onNextPage() {
		this.pageNumber++;
		this.getPets();
	}
}
