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

	
}
