import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { VolunteerService } from '../../../services/volunteer.service';
import { Volunteer } from '../../../shared/models/volunteer/Volunteer';
import { DatePipe } from '@angular/common';
@Component({
	selector: 'app-volunteer-manager',
	standalone: true,
	imports: [RouterLink, DatePipe],
	templateUrl: './volunteer-manager.component.html',
	styleUrl: './volunteer-manager.component.scss',
})
export class VolunteerManagerComponent {
	pageNumber: number = 1;
	pageSize: number = 20;
	volunteers: Volunteer[] = [];

	constructor(private volunteerService: VolunteerService) {}

	ngOnInit() {
		this.getVolunteers();
	}

	private getVolunteers() {
		this.volunteerService.getVolunteers(this.pageNumber, this.pageSize).subscribe({
			next: (res: any) => {
				// console.log(res.data);
				this.volunteers = res.data;
			},
			error: err => {
				console.log(err);
			},
		});
	}

	softDelete(v: Volunteer) {
		this.volunteerService.softDelete(v.id).subscribe({
			next: (res: any) => {
				// console.log(res);
				v.isDeleted = !v.isDeleted;
			},
			error: err => {
				console.log(err);
			},
		});
	}
}
