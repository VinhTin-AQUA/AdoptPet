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
	isShowDonorDelete: boolean = false;
	donorDelete: any;
	pageNumber: number = 1;
	pageSize: number = 10;

	constructor(private donorService: DonorService) {}

	ngOnInit() {
		this.getAllDonors();
	}

	private getAllDonors() {
		this.donorService.getAllDonors(this.pageNumber, this.pageSize).subscribe({
			next: (res: any) => {
				// console.log(res.data);
				this.donors = res.data;
			},
			error: err => {
				console.log(err);
			},
		});
	}

	onShowDelete(donor: any) {
		this.donorDelete = donor;
		this.isShowDonorDelete = !this.isShowDonorDelete;
	}

	deleteDonor() {
		if (this.donorDelete === null) {
			return;
		}

		this.donorService.softDeleteDonor(this.donorDelete.id).subscribe({
			next: (res: any) => {
				this.donorDelete.isDeleted = !this.donorDelete.isDeleted;
				this.isShowDonorDelete = false;
				this.donorDelete = null
			},
			error: err => {
				console.log(err.error);
				this.isShowDonorDelete = false;
				this.donorDelete = null
			},
		});
	}

	onPrevPage() {
		this.pageNumber--;
		if (this.pageNumber < 1) {
			this.pageNumber = 1;
		}
		this.getAllDonors();
	}

	onNextPage() {
		this.pageNumber++;
		this.getAllDonors();
	}

}
