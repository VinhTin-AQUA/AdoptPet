import { signalStore, withState } from '@ngrx/signals';

type UserState = {
	name: string,
    picture: string
};

const initState: UserState = {
	name: '',
    picture: ''
};

export const UserStore = signalStore({ providedIn: 'root' }, withState(initState));
