import { Routes } from '@angular/router';
import { SigninComponent } from './account/signin/signin.component';
import { SignupComponent } from './account/signup/signup.component';
import { ProfileComponent } from './account/profile/profile.component';
import { ChangePasswordComponent } from './account/change-password/change-password.component';
import { ForgotPasswordComponent } from './account/forgot-password/forgot-password.component';
import { NoticeComponent } from './notice/notice.component';
import { ResetPasswordComponent } from './account/reset-password/reset-password.component';
import { PageNotFoundComponent } from './sharedPages/page-not-found/page-not-found.component';

export const routes: Routes = [
	{ path: '', redirectTo: 'adopt-pet', pathMatch: 'full' },
	{ path: 'sign-up', component: SignupComponent, title: 'Sign up' },
	{ path: 'sign-in', component: SigninComponent, title: 'Sign in' },
	{ path: 'profile', component: ProfileComponent, title: 'Profile' },
	{ path: 'change-pasword', component: ChangePasswordComponent, title: 'Change password' },
	{ path: 'forgot-pasword', component: ForgotPasswordComponent, title: 'Forgot password' },
	{ path: 'reset-pasword', component: ResetPasswordComponent, title: 'Reset password' },
	{ path: 'notice', component: NoticeComponent, title: 'Notice' },
	{
		path: 'adopt-pet',
		loadChildren: () => import('./adopt-pages/adopt-page.routes').then(r => r.adoptRoutes),
	},
	{
		path: 'admin',
		loadChildren: () => import('./admin-dashboard/admin.routes').then(r => r.adminRoutes),
	},
	{ path: '**', component: PageNotFoundComponent, title: 'Page not found' },
];
