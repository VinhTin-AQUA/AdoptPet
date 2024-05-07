import { Component } from '@angular/core';
import { ColorService } from '../../../services/color.service';
import { Color } from '../../../shared/models/color/Color';

@Component({
	selector: 'app-color-manager',
	standalone: true,
	imports: [],
	templateUrl: './color-manager.component.html',
	styleUrl: './color-manager.component.scss',
})
export class ColorManagerComponent {
	colors: Color[] = [];
	pageNumber: number = 1;
	pageSize: number = 20;

	constructor(private colorService: ColorService) {}

	ngOnInit() {
		this.getColors();
	}

	private getColors() {
		this.colorService.getAllColor(this.pageNumber, this.pageSize).subscribe({
			next: (res: any) => {
				this.colors = res.items;
				console.log(res.items);
			},
			error: err => {
				console.log(err);
			},
		});
	}

	onAddColor(inputColor: HTMLInputElement) {
		if (inputColor.value === '') {
			return;
		}

		console.log(inputColor.value);
		this.colorService.addColor(inputColor.value).subscribe({
			next: (res: any) => {
				console.log(res);
				this.colors.push(res.data);
			},
			error: err => {
				console.log(err);
			},
		});
	}

	onDelete(id: number) {
		this.colorService.softDeleteColor(id).subscribe({
			next: (res: any) => {
				const index = this.colors.findIndex(c => c.id === id);

				if (index !== -1) {
					this.colors[index].isDeleted = !this.colors[index].isDeleted;
				}
			},
			error: err => {
				console.log(err);
			},
		});
	}

	onPrevPage() {
		this.pageNumber--;
		if (this.pageNumber < 1) {
			this.pageNumber = 1;
		}
		this.getColors();
	}

	onNextPage() {
		this.pageNumber++;
		this.getColors();
	}

}
