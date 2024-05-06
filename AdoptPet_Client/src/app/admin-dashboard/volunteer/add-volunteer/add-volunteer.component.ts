import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { LocationService } from '../../../services/location.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { VolunteerService } from '../../../services/volunteer.service';
import { VolunteerAdd } from '../../../shared/models/volunteer/volunteer-add';
import { patchState } from '@ngrx/signals';
import { DialogStore } from '../../../shared/stores/DialogStore';
import { VolunteerRole } from '../../../shared/models/volunteer/volunteer-role';
import { VolunteerRoleService } from '../../../services/volunteer-role.service';

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
	dialogStore = inject(DialogStore);
	volunteerRoles: VolunteerRole[] = [];
	roleDesciption: string = '';

	constructor(
		private formBuilder: FormBuilder,
		private locationService: LocationService,
		private volunteerService: VolunteerService,
		private volunteerRoleService: VolunteerRoleService
	) {}

	ngOnInit() {
		this.volunteerForm = this.formBuilder.group({
			email: ['', [Validators.required, Validators.email]],
			province: ['', [Validators.required]],
			district: ['', [Validators.required]],
			ward: ['', [Validators.required]],
			street: [''],
			roleId: [1],
		});

		this.locationService.getProvices().subscribe({
			next: (res: any) => {
				this.provinces = res.results;
				// console.log(this.provinces);
				this.volunteerForm.controls['province'].setValue('Thành phố Hà Nội');
				this.getDistricts('01');
			},
		});

		this.getVolunteerRoles();
	}

	private getDistricts(provinceId: string) {
		this.locationService.getDistricts(provinceId).subscribe({
			next: (res: any) => {
				this.districts = res.results;
				// console.log(this.provinces);
				this.volunteerForm.controls['district'].setValue(this.districts[0].district_name);
				this.getWards(this.districts[0].district_id);
			},
		});
	}

	private getWards(districtId: string) {
		this.locationService.getWards(districtId).subscribe({
			next: (res: any) => {
				this.wards = res.results;
				this.volunteerForm.controls['ward'].setValue(this.wards[0].ward_name);
			},
		});
	}

	private getVolunteerRoles() {
		this.volunteerRoleService.getAllVolunteerRoles().subscribe({
			next: (res: any) => {
				// console.log(res.data);
				this.volunteerRoles = res.data;
			},
			error: err => {
				console.log(err.error);
			},
		});
	}

	onProviceChanged(event: any) {
		const selectedOption = event.target.selectedOptions[0];
		this.getDistricts(selectedOption.getAttribute('id'));
	}

	onDistrictChanged(event: any) {
		const selectedOption = event.target.selectedOptions[0];
		this.getWards(selectedOption.getAttribute('id'));
	}

	onWardsChanged(event: any) {
		console.log('Wards');
	}

	onRoleSelectted(event: any) {
		const selectedOption = event.target.selectedOptions[0];
		this.roleDesciption = selectedOption.getAttribute('id')
	}

	onSubmit() {
		this.submitted = true;

		if (this.volunteerForm.valid === false) {
			return;
		}

		const data: VolunteerAdd = {
			userEmail: this.volunteerForm.controls['email'].value,
			location: {
				id: 0,
				isDeleted: false,
				street: this.volunteerForm.controls['street'].value,
				wards: this.volunteerForm.controls['ward'].value,
				districtCity: this.volunteerForm.controls['district'].value,
				provinceCity: this.volunteerForm.controls['province'].value,
			},
			roleId: this.volunteerForm.controls['roleId'].value,
		};

		this.volunteerService.addVolunteer(data).subscribe({
			next: (res: any) => {
				console.log(res);
			},
			error: err => {
				console.log(err.error);
				patchState(this.dialogStore, {
					isShowed: true,
					title: err.error.title,
					message: err.error.messages.join('\n'),
				});
			},
		});
		// console.log(data);
	}
}
