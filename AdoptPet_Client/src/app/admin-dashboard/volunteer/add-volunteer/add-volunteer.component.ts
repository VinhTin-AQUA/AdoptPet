import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { LocationService } from '../../../services/location.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
	selector: 'app-add-volunteer',
	standalone: true,
	imports: [RouterLink, ReactiveFormsModule],
	templateUrl: './add-volunteer.component.html',
	styleUrl: './add-volunteer.component.scss',
})
export class AddVolunteerComponent {
	provinces: any = [];
	districts: any = [];
	wards: any = [];
	volunteerForm!: FormGroup;
  submitted: boolean = false;

	constructor(private formBuilder: FormBuilder, private locationService: LocationService) {}

	ngOnInit() {
		this.volunteerForm = this.formBuilder.group({
			firstName: ['', [Validators.required]],
			lastName: ['', [Validators.required]],
			phone: ['', [Validators.required]],
			email: ['', [Validators.required]],
			province: ['', [Validators.required]],
			district: ['', [Validators.required]],
			ward: ['', [Validators.required]],
      street: [''],
			password: ['', [Validators.required]],
			confirmPassword: ['', [Validators.required]],
		});

		this.locationService.getProvices().subscribe({
			next: (res: any) => {
				this.provinces = res.results;
				// console.log(this.provinces);
				this.volunteerForm.controls['province'].setValue('01');
				this.getDistricts(this.volunteerForm.controls['province'].value);
			},
		});
	}



	private getDistricts(provinceId: string) {
		this.locationService.getDistricts(provinceId).subscribe({
			next: (res: any) => {
				this.districts = res.results;
				// console.log(this.provinces);
				this.volunteerForm.controls['district'].setValue(this.districts[0].district_id);
				this.getWards(this.districts[0].district_id);
			},
		});
	}

	private getWards(districtId: string) {
		this.locationService.getWards(districtId).subscribe({
			next: (res: any) => {
				this.wards = res.results;
				this.volunteerForm.controls['ward'].setValue(this.wards[0].ward_id);
			},
		});
	}

	onProviceChanged() {
		this.getDistricts(this.volunteerForm.controls['province'].value);
	}

	onDistrictChanged() {
		this.getWards(this.volunteerForm.controls['district'].value);
	}

	

	onSubmit() {
    this.submitted = true;

    if(this.volunteerForm.valid === false) {
      return;
    }


		console.log(this.volunteerForm.value);
	}
}
