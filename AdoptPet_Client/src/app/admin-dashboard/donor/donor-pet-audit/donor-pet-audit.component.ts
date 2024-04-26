import { Component } from '@angular/core';
import { DonorPetAuditServiceService } from '../../../services/donor-pet-audit-service.service';
import { DonorPetAudit } from '../../../shared/models/donor/DonorPetAudit';
import { DatePipe } from '@angular/common';

@Component({
	selector: 'app-donor-pet-audit',
	standalone: true,
	imports: [DatePipe],
	templateUrl: './donor-pet-audit.component.html',
	styleUrl: './donor-pet-audit.component.scss',
})
export class DonorPetAuditComponent {
	donorPetAudits: DonorPetAudit[] = [];
	isShowDelete: boolean = false;
	donorPetAuditDelete: any;

	constructor(private donorPetAuditServiceService: DonorPetAuditServiceService) {}

	ngOnInit() {
		this.getAllDonorPetAudits();
	}

	private getAllDonorPetAudits() {
		this.donorPetAuditServiceService.getAllDonorPetAudits().subscribe({
			next: (res: any) => {
				// console.log(res.data);
				this.donorPetAudits = res.data;
			},
			error: err => {
				console.log(err);
			},
		});
	}

	onShowRoleDelete(donorAudit: any) {
		this.isShowDelete = !this.isShowDelete;
		this.donorPetAuditDelete = donorAudit;
	}

	onDeleteRole() {
		if (this.donorPetAuditDelete === null) {
			this.donorPetAuditDelete = null;
				this.isShowDelete = false;
			return;
		}

		this.donorPetAuditServiceService.softDelete(this.donorPetAuditDelete.id).subscribe({
			next: (res: any) => {
				console.log(res);
				this.donorPetAuditDelete.isDeleted = !this.donorPetAuditDelete.isDeleted;
				this.donorPetAuditDelete = null;
				this.isShowDelete = false;
			},
			error: err => {
				console.log(err.error);

				this.donorPetAuditDelete = null;
				this.isShowDelete = false;
			},
		});
	}
}
