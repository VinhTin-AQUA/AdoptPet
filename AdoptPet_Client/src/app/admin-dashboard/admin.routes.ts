import { Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { UserManagerComponent } from './user-manager/user-manager.component';

export const adminRoutes: Routes = [
	{
		path: '',
		component: AdminComponent,
		children: [
			{ path: '', redirectTo: 'user-manager', pathMatch: 'full' },
			{ path: 'user-manager', component: UserManagerComponent, title: 'User manager' },
		],
	},
];
