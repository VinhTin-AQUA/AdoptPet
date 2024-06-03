import { Component } from '@angular/core';
import { VolunteerAuditService } from '../../../services/volunteer-audit.service';

@Component({
	selector: 'app-volunteer-audit',
	standalone: true,
	imports: [],
	templateUrl: './volunteer-audit.component.html',
	styleUrl: './volunteer-audit.component.scss',
})
export class VolunteerAuditComponent {
	pageNumber: number = 1;
	pageSize: number = 7;
	volunteerAudits: any = [];

	constructor(private volunteerAudit: VolunteerAuditService) {}

	ngOnInit() {
		this.getVolunteerAudits();
	}

	private getVolunteerAudits() {
		// this.volunteerAudit.getVolunteerAudits(this.pageNumber,this.pageSize).subscribe({
		// })
	}

	previousPage() {
		this.pageNumber --;
		if(this.pageNumber <= 0) {
			this.pageNumber = 1
		}
	}

	nextPage() {
		this.pageNumber++;
	}
}
