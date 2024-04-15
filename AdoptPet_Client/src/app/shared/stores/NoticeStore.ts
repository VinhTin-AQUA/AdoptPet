import { signalStore, withState } from '@ngrx/signals';

type NoticeState = {
	title: string;
	message: string;
	status: boolean;
};

const initState: NoticeState = {
	title: '',
	message: '',
	status: false,
};

export const NoticeStore = signalStore({ providedIn: 'root' }, withState(initState));
