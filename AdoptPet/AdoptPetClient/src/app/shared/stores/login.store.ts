import { signalStore, withState } from '@ngrx/signals';

type LoginState = {
	isLoggedIn: boolean;
};

const initState: LoginState = {
	isLoggedIn: false,
};

export const LoginStore = signalStore({ providedIn: 'root' }, withState(initState));
