import { Component } from '@angular/core';
import { DonorService } from '../../../services/donor.service';
import { DonorDto } from '../../../shared/models/donor/DonorDto';

@Component({
	selector: 'app-donor-manager',
	standalone: true,
	imports: [],
	templateUrl: './donor-manager.component.html',
	styleUrl: './donor-manager.component.scss',
})
export class DonorManagerComponent {
	donors: DonorDto[] = [];
	constructor(private donorService: DonorService) {}

	ngOnInit() {
		this.getAllDonors();
	}

	private getAllDonors() {
		this.donorService.getAllDonors().subscribe({
			next: (res: any) => {
				console.log(res.data);
				this.donors = res.data;
			},
			error: err => {
				console.log(err);
			},
		});
	}
}
