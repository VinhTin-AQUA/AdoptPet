import { Component, inject } from '@angular/core';
import { GoogleService } from '../../services/google.service';
import { LoginStore } from '../../shared/stores/login.store';
import { patchState } from '@ngrx/signals';

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
	isloggedIn: boolean = false;
	constructor(private googleService: GoogleService) {}

	ngOnInit() {
		this.isloggedIn = this.loginStore.isLoggedIn();
		google.accounts.id.initialize({
			client_id: '826248673827-j1rj2ve04imgq3suubondvk264ppdjh6.apps.googleusercontent.com',
			callback: (res: any) => {
				this.googleService.saveCredential(res.credential);
				patchState(this.loginStore, { isLoggedIn: true });
				this.isloggedIn = true;
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
}
