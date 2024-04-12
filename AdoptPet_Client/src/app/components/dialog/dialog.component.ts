import { Component, inject } from '@angular/core';
import { DialogStore } from '../../shared/stores/dialogStore';
import { patchState } from '@ngrx/signals';

@Component({
	selector: 'app-dialog',
	standalone: true,
	imports: [],
	templateUrl: './dialog.component.html',
	styleUrl: './dialog.component.scss',
})
export class DialogComponent {
	dialog = inject(DialogStore);

	onHideDialog() {
		patchState(this.dialog, { title: '', message: '', isShowed: false });
	}
}
