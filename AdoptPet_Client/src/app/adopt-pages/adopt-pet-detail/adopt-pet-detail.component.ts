import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { PetService } from '../../services/pet.service';
import { PetDto } from '../../shared/models/pet/PetDto';
import { environment } from '../../../environments/environment.development';
import { DatePipe } from '@angular/common';

@Component({
	selector: 'app-adopt-pet-detail',
	standalone: true,
	imports: [RouterLink, DatePipe],
	templateUrl: './adopt-pet-detail.component.html',
	styleUrl: './adopt-pet-detail.component.scss',
})
export class AdoptPetDetailComponent {
	petId: number = -1;
	pet: PetDto | null = null;
	baseImg = environment.baseImgUrl;

	constructor(private activatedRoute: ActivatedRoute, private petService: PetService) {}

	ngOnInit() {
		this.activatedRoute.params.subscribe({
			next: (params: any) => {
				// console.log(params.id); // {id: '2', name: 'hoc'}
				this.petId = params.id;
        this.getPet();
			},
		});
	}

	private getPet() {
		this.petService.getPet(this.petId).subscribe({
			next: (res: any) => {
				console.log(res);
        		this.pet = res;
			},
			error: err => {
				console.log(err);
			},
		});
	}
}
