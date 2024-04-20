import { signalStore, withState } from '@ngrx/signals';

type UserState = {
	id: string,
	email: string;
	phoneNumber: string;
	firstName: string;
	lastName: string;
    loggedIn: boolean;
};

const initState: UserState = {
	id: '',
	email: '',
	phoneNumber: '',
	firstName: '',
	lastName: '',
    loggedIn: false
};

export const UserStore = signalStore({ providedIn: 'root' }, withState(initState));
