import { Component, inject } from '@angular/core';
import { Role } from '../../../shared/models/role/role';
import { RoleService } from '../../../services/role.service';
import { patchState } from '@ngrx/signals';
import { DialogStore } from '../../../shared/stores/DialogStore';

@Component({
	selector: 'app-role-manager',
	standalone: true,
	imports: [],
	templateUrl: './role-manager.component.html',
	styleUrl: './role-manager.component.scss',
})
export class RoleManagerComponent {
	roles: Role[] = [];
	dialog = inject(DialogStore);

	// delete role
	roleDelete!: Role | null;
	isShowRoleDelete: boolean = false;

	constructor(private roleService: RoleService) {}

	ngOnInit() {
		this.roleService.getAllRoles().subscribe({
			next: (res: any) => {
				// console.log(res.data);
				this.roles = res.data;
			},
		});
	}

	onAddRole(roleNameInput: HTMLInputElement) {
		if (roleNameInput.value === '') {
			return;
		}
		const form = new FormData();
		form.append('roleName', roleNameInput.value);

		this.roleService.addRole(form).subscribe({
			next: (res: any) => {
				// console.log(res.data);
				this.roles.push(res.data);

				roleNameInput.value = '';
				roleNameInput.focus();
			},
			error: err => {
				let messages = err.error.messages.join("\n");
				patchState(this.dialog, { message: messages, title: 'Lỗi', isShowed: true });
			},
		});
	}

	onShowRoleDelete(role: Role | null) {
		this.isShowRoleDelete = !this.isShowRoleDelete;
		this.roleDelete = role;
	}

	onDeleteRole() {
		if(this.roleDelete === null) {
			return;
		}
		const id = this.roleDelete.id;

		this.roleService.deleteRole(this.roleDelete.id).subscribe({
			next:(res: any) => {
				const tempRoles = this.roles.filter(r => r.id !== id);
				this.roles = tempRoles;
				this.isShowRoleDelete = false;
				this.roleDelete = null;
			}, error: (err) => {
				console.log(err);
			}
		})
	}
}
