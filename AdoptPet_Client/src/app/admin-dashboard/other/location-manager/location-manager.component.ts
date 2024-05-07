import { Component } from '@angular/core';
import { LocationService } from '../../../services/location.service';
import { Location } from '../../../shared/models/location/location';

@Component({
	selector: 'app-location-manager',
	standalone: true,
	imports: [],
	templateUrl: './location-manager.component.html',
	styleUrl: './location-manager.component.scss',
})
export class LocationManagerComponent {
	locations: Location[] = [];
	pageNumber: number = 1;
	pageSize: number = 20;

	constructor(private locationService: LocationService) {}

	ngOnInit() {
		this.locationService.getSavedLocation(this.pageNumber, this.pageSize).subscribe({
			next: (res: any) => {
				// console.log(res.data);
				this.locations = res.data;
			},
			error: err => {
				console.log(err);
			},
		});
	}
}
