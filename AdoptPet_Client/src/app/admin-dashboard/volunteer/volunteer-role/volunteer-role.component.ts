import { Component, inject } from '@angular/core';
import { VolunteerRoleService } from '../../../services/volunteer-role.service';
import { RouterLink } from '@angular/router';
import { DialogStore } from '../../../shared/stores/DialogStore';
import { patchState } from '@ngrx/signals';

@Component({
	selector: 'app-volunteer-role',
	standalone: true,
	imports: [RouterLink],
	templateUrl: './volunteer-role.component.html',
	styleUrl: './volunteer-role.component.scss',
})
export class VolunteerRoleComponent {
	dialog = inject(DialogStore);
	roles: any = [];
	isShowRoleDelete: boolean = false;
	roleDelete: any;

	constructor(private volunteerRoleService: VolunteerRoleService) {}

	ngOnInit() {
		this.volunteerRoleService.getAllVolunteerRoles().subscribe({
			next: (res: any) => {
				this.roles = res.data;
				// console.log(this.roles);
			},
			error: err => {
				console.log(err);
			},
		});
	}

	onDeleteRole() {
		this.volunteerRoleService.softDelete(this.roleDelete.id).subscribe({
			next: (res: any) => {
				const id = res.data;

				const index = this.roles.findIndex((x: any) => x.id === id);

				if (index !== -1) {
					this.roles[index].isDeleted = !this.roles[index].isDeleted;
				}
				this.isShowRoleDelete = false;
				this.roleDelete = null;

				
			},
			error: err => {
				var _messages = err.error.messages.join('\n');
				patchState(this.dialog, { isShowed: true, title: 'Lỗi', message: _messages });
			},
		});
	}

	onShowRoleDelete(role: any) {
		this.isShowRoleDelete = !this.isShowRoleDelete;
		this.roleDelete = role;
	}
}
