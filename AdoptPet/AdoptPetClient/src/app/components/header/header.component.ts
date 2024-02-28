import { Component, inject } from '@angular/core';
import { GoogleService } from '../../services/google.service';
import { LoginStore } from '../../shared/stores/login.store';
import { patchState } from '@ngrx/signals';
import { UserStore } from '../../shared/stores/user.store';

declare var google: any;

@Component({
	selector: 'app-header',
	standalone: true,
	imports: [],
	templateUrl: './header.component.html',
	styleUrl: './header.component.scss',
})
export class HeaderComponent {
	loginStore = inject(LoginStore);
	userStore = inject(UserStore);
	isShowMenuProfile: boolean = false;

	constructor(private googleService: GoogleService) {}

	ngOnInit() {
		google.accounts.id.initialize({
			client_id: '826248673827-j1rj2ve04imgq3suubondvk264ppdjh6.apps.googleusercontent.com',
			callback: (res: any) => {
				this.googleService.saveCredential(res.credential);
				patchState(this.loginStore, { isLoggedIn: true });
				window.location.reload();
			},
		});
	}

	ngAfterViewInit() {
		google.accounts.id.renderButton(document.getElementById('gg-btn'), {
			// theme: 'red',
			size: 'large',
			shape: 'rectangle',
			width: 200,
		});
	}

	onShowMenuProfile() {
		this.isShowMenuProfile = !this.isShowMenuProfile;
	}

	onLogout() {
		this.googleService.clearCredential();
		window.location.reload();
	}
}
