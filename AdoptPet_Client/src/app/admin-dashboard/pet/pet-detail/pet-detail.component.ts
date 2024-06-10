import { Component } from '@angular/core';
import { PetService } from '../../../services/pet.service';
import { PetDto } from '../../../shared/models/pet/PetDto';
import { ActivatedRoute, Router } from '@angular/router';
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

	constructor(private petService: PetService, 
		private router: Router,
		private activatedRoute: ActivatedRoute) {}

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

	deletePet() {
		if(this.pet !== null) {
			this.petService.deletePet(this.pet.id).subscribe({
				next: (res: any) => {
					this.router.navigateByUrl('/admin/pet-manager')
				}, error: (err) => {
					console.log(err.error);
					
				}
			})
		}
	}
}
