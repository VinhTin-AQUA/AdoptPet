import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import {
	FormBuilder,
	FormControl,
	FormGroup,
	FormsModule,
	ReactiveFormsModule,
	Validators,
} from '@angular/forms';

@Component({
	selector: 'app-add-pet',
	standalone: true,
	imports: [ReactiveFormsModule, FormsModule],
	templateUrl: './add-pet.component.html',
	styleUrl: './add-pet.component.scss',
})
export class AddPetComponent {
	petForm!: FormGroup;
	provinces: any = [];
	districts: any = [];
	wards: any = [];

	constructor(private formBuilder: FormBuilder, private http: HttpClient) {}

	ngOnInit() {
		this.petForm = this.formBuilder.group({
			petName: ['', [Validators.required]],
			email: ['', [Validators.email, Validators.required]],
			age: ['', [Validators.required]],
			province: ['', [Validators.required]],
			district: ['', [Validators.required]],
			ward: ['', [Validators.required]],
			street: ['', [Validators.required]],
			weight: [0, [Validators.required]],
			petGender: [0],
			petDesexed: [0],
			petWormed: [0],
			petVaccined: [0],
			microchipped: [0],
			petEntryDate: [new Date()],
		});

		this.getProvices();
	}

	private getProvices() {
		this.http.get('https://vapi.vnappmob.com/api/province').subscribe({
			next: (res: any) => {
				this.provinces = res.results;
				// console.log(this.provinces);
				this.petForm.controls['province'].setValue(this.provinces[0].province_id);
        this.getDistricts(this.petForm.controls['province'].value);
			},
		});
	}

	private getDistricts(provinceId: string) {
		this.http.get('https://vapi.vnappmob.com/api/province/district/' + provinceId).subscribe({
			next: (res: any) => {
				this.districts = res.results;
				// console.log(this.provinces);
				this.petForm.controls['district'].setValue(this.districts[0].district_id);
        this.getWards(this.districts[0].district_id);
			},
		});
	}

  private getWards(districtId: string) {
    this.http.get('https://vapi.vnappmob.com/api/province/ward/' + districtId).subscribe({
			next: (res: any) => {
				this.wards = res.results;
				this.petForm.controls['ward'].setValue(this.wards[0].ward_id);
      },
		});
  }



	onProviceChanged() {
		this.getDistricts(this.petForm.controls['province'].value);
	}

	onDistrictChanged() {
		this.getWards(this.petForm.controls['district'].value);
	}

	onWardsChanged() {
		console.log('Wards');
	}

	onSubmit() {
		console.log(this.petForm.value);
	}
}
