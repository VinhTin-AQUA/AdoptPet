import { Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { UserManagerComponent } from './user/user-manager/user-manager.component';
import { RoleManagerComponent } from './user/role-manager/role-manager.component';
import { VolunteerManagerComponent } from './volunteer/volunteer-manager/volunteer-manager.component';
import { VolunteerRoleComponent } from './volunteer/volunteer-role/volunteer-role.component';
import { PetManagerComponent } from './pet/pet-manager/pet-manager.component';
import { BreedManagerComponent } from './pet/breed-manager/breed-manager.component';
import { ColorManagerComponent } from './pet/color-manager/color-manager.component';
import { DonorManagerComponent } from './donor/donor-manager/donor-manager.component';
import { LocationManagerComponent } from './other/location-manager/location-manager.component';
import { AddVolunteerComponent } from './volunteer/add-volunteer/add-volunteer.component';
import { VolunteerAuditComponent } from './volunteer/volunteer-audit/volunteer-audit.component';

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
			{ path: 'volunteer-audit', component: VolunteerAuditComponent, title: 'Volunteer audit' },
			{ path: 'add-volunteer', component: AddVolunteerComponent, title: 'Add volunteer' },
			{ path: 'pet-manager', component: PetManagerComponent, title: 'Pet manager' },
			{ path: 'breed-manager', component: BreedManagerComponent, title: 'Breed manager' },
			{ path: 'color-manager', component: ColorManagerComponent, title: 'Color manager' },
			{ path: 'donor-manager', component: DonorManagerComponent, title: 'Donor manager' },
			{ path: 'location-manager', component: LocationManagerComponent, title: 'Location manager' },
		],
	},
];
