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
import { LocationService } from '../../../services/location.service';
import { BreedService } from '../../../services/breed.service';
import { PetService } from '../../../services/pet.service';
import { ColorService } from '../../../services/color.service';
import { Router } from '@angular/router';

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

	breeds: any = [];
	dataImages: any = [];
	filesAdd: any = [];
	locations: any = [];
	colors: any = [];

	constructor(
		private formBuilder: FormBuilder,
		private breedService: BreedService,
		private locationService: LocationService,
		private petService: PetService,
		private colourService: ColorService,
		private router: Router
	) {}

	ngOnInit() {
		this.petForm = this.formBuilder.group({
			petName: ['', [Validators.required]],
			petDescription: ['', [Validators.required]],
			petWeight: [0, [Validators.required]],
			petAge: ['', [Validators.required]],
			petGender: [0],
			petDesexed: [0],
			petWormed: [0],
			petVaccined: [0],
			microchipped: [0],
			breedId: [0],
			petEntryDate: [new Date()],
			locationId: [0],
			colourId: [0],
		});

		this.getBreeds();
		this.getLocations();
		this.getColours();
	}

	private getColours() {
		this.colourService.getAllColor(1,57).subscribe({
			next: (res:any) => {
				// console.log(res.items);
				this.colors = res.items;
				
			}
		})
	}

	private getLocations() {
		this.locationService.getLocations(1,20).subscribe({
			next: (res:any) => {
				// console.log(res.data);
				this.locations = res.data
			}

		})
	}

	private getBreeds() {
		this.breedService.getAllBreed(1, 25).subscribe({
			next: (res: any) => {
				// console.log(res.data);
				this.breeds = res.data;
			},
		});
	}

	onImageSelected(event: any) {
		if (event.target.files.length > 0) {
			this.filesAdd = [];
			this.dataImages = [];
			for (let file of event.target.files) {
				this.filesAdd.push(file);

				const reader = new FileReader();
				reader.readAsDataURL(file);
				reader.onload = event => {
					const data = event.target?.result;
					this.dataImages.push(data);
					// console.log(this.dataImages);
				};
			}
		}
	}

	onSubmit() {
		const form = new FormData();
		form.append('petName', this.petForm.controls['petName'].value);
		form.append('petDescription', this.petForm.controls['petDescription'].value);
		form.append('petWeight', this.petForm.controls['petWeight'].value);
		form.append('petAge', this.petForm.controls['petAge'].value);
		form.append('petGender', this.petForm.controls['petGender'].value);
		form.append('petDesexed', this.petForm.controls['petDesexed'].value);
		form.append('petWormed', this.petForm.controls['petWormed'].value);
		form.append('petVaccined', this.petForm.controls['petVaccined'].value);
		form.append('microchipped', this.petForm.controls['microchipped'].value);
		form.append('petEntryDate', this.petForm.controls['petEntryDate'].value);
		form.append('locationId', this.petForm.controls['locationId'].value);
		form.append('breedId', this.petForm.controls['breedId'].value);
		form.append('colourId', this.petForm.controls['colourId'].value);

		for(let i of this.filesAdd) {
			form.append('Images', i);
		}
		// console.log(1234);
		
		this.petService.addPet(form).subscribe({
			next:(res: any) => {
				console.log(res);
				this.router.navigateByUrl('/admin/pet-manager')
			},
			error: (err) => {
				console.log(err.error);
				
			}
		})
	}
}
