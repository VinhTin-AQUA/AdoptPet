import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';

export function tokenGetter() {
	return localStorage.getItem('credential');
}

export const appConfig: ApplicationConfig = {
	providers: [
		provideRouter(routes),
		provideHttpClient(),
		importProvidersFrom(
			JwtModule.forRoot({
				config: {
					tokenGetter: tokenGetter,
				},
			})
		),
	],
};
