import { Routes } from '@angular/router';
import { SigninComponent } from './account/signin/signin.component';
import { SignupComponent } from './account/signup/signup.component';

export const routes: Routes = [
	{ path: '', redirectTo: 'adopt-pet', pathMatch: 'full' },
	{ path: 'sign-up', component: SignupComponent, title: 'Sign up' },
	{ path: 'sign-in', component: SigninComponent, title: 'Sign in' },
	{
		path: 'adopt-pet',
		loadChildren: () => import('./adopt-pages/adopt-page.routes').then(r => r.adoptRoutes),
	},
	{ path: '**', redirectTo: 'adopt' },
];
