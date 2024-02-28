import { signalStore, withState } from '@ngrx/signals';

type LoadingState = {
	isLoading: boolean;
};

const initState: LoadingState = {
	isLoading: false,
};

export const LoadingStore = signalStore({ providedIn: 'root' }, withState(initState));
