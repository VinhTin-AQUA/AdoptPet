import { Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { UserManagerComponent } from './user-manager/user-manager.component';
import { RoleManagerComponent } from './role-manager/role-manager.component';
import { VolunteerManagerComponent } from './volunteer-manager/volunteer-manager.component';
import { VolunteerRoleComponent } from './volunteer-role/volunteer-role.component';

export const adminRoutes: Routes = [
	{
		path: '',
		component: AdminComponent,
		children: [
			{ path: '', redirectTo: 'user-manager', pathMatch: 'full' },
			{ path: 'user-manager', component: UserManagerComponent, title: 'User manager' },
			{ path: 'role-manager', component: RoleManagerComponent, title: 'Role manager' },
			{ path: 'volunteer-manager', component: VolunteerManagerComponent, title: 'Volunteer manager' },
			{ path: 'volunteer-role', component: VolunteerRoleComponent, title: 'Volunteer role' },
		],
	},
];
