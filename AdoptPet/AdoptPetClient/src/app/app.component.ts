import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { LoadingComponent } from './components/loading/loading.component';
import { LoginStore } from './shared/stores/login.store';
import { GoogleService } from './services/google.service';
import { patchState } from '@ngrx/signals';
import { JwtHelperService } from '@auth0/angular-jwt';
import { jwtDecode } from 'jwt-decode';
import { UserStore } from './shared/stores/user.store';

@Component({
	selector: 'app-root',
	standalone: true,
	imports: [CommonModule, RouterOutlet, HeaderComponent, FooterComponent, LoadingComponent],
	templateUrl: './app.component.html',
	styleUrl: './app.component.scss',
})
export class AppComponent {
	title = 'AdoptPet';
	loginStore = inject(LoginStore);
	userStore = inject(UserStore)
	constructor(private googleService: GoogleService, private jwtHelper: JwtHelperService) {}

	ngOnInit() {
		const credential = this.googleService.getCredential();
		if (credential === null) {
			patchState(this.loginStore, { isLoggedIn: false });
			return;
		}

		// check expire
		if (this.jwtHelper.isTokenExpired(credential) === true) {
			patchState(this.loginStore, { isLoggedIn: false });
		} else {
			patchState(this.loginStore, { isLoggedIn: true });

			var decoded:any = jwtDecode(credential);
			patchState(this.userStore, {name: decoded.name, picture: decoded.picture})
		}
	}
}
