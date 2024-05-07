import { Component } from '@angular/core';
import { PetService } from '../../../services/pet.service';
import { PetDto } from '../../../shared/models/pet/PetDto';
import { ActivatedRoute } from '@angular/router';
import { environment } from '../../../../environments/environment.development';

@Component({
	selector: 'app-pet-detail',
	standalone: true,
	imports: [],
	templateUrl: './pet-detail.component.html',
	styleUrl: './pet-detail.component.scss',
})
export class PetDetailComponent {
	pet: PetDto | null = null;
	baseImg = environment.baseImgUrl;

	constructor(private petService: PetService, private activatedRoute: ActivatedRoute) {}

	ngOnInit() {
		this.activatedRoute.params.subscribe({
			next: (params: any) => {
				// console.log(params.id);
				this.getPet(params.id);
			},
		});
	}

	private getPet(petId: number) {
		this.petService.getPet(petId).subscribe({
			next: (res: any) => {
				// console.log(res);
				this.pet = res;
			},
		});
	}
}
