import { Component } from '@angular/core';
import { BreedService } from '../../../services/breed.service';
import { ActivatedRoute } from '@angular/router';
import { Breed } from '../../../shared/models/breed/breed';

@Component({
	selector: 'app-breed-detail',
	standalone: true,
	imports: [],
	templateUrl: './breed-detail.component.html',
	styleUrl: './breed-detail.component.scss',
})
export class BreedDetailComponent {
	breed?: Breed;

	constructor(private breedService: BreedService, private activatedRoute: ActivatedRoute) {}

	ngOnInit() {
		this.activatedRoute.params.subscribe({
			next: (params: any) => {
				// console.log(params.id);
				this.getBreed(params.id);
			},
		});
	}

	private getBreed(id: number) {
		this.breedService.getBreedById(id).subscribe({
			next: (res: any) => {
				console.log(res.data);
				this.breed = res.data;
			},
		});
	}
}
