import { signalStore, withState } from '@ngrx/signals';

type DialogState = {
	title: string;
	message: string;
	isShowed: boolean;
};

const initState: DialogState = {
	title: '',
	message: '',
	isShowed: false,
};

export const DialogStore = signalStore({ providedIn: 'root' }, withState(initState));
