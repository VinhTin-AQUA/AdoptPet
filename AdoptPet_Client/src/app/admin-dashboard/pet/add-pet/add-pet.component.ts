import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-pet',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-pet.component.html',
  styleUrl: './add-pet.component.scss'
})
export class AddPetComponent {
  petForm!: FormGroup;

  constructor(private formBuilder: FormBuilder) {
  }

  ngOnInit() {  
    this.petForm = this.formBuilder.group({
      petName: ['', [Validators.required]],
      email: ['', [Validators.email, Validators.required]],
      age: ['', [Validators.required]],
      province: ['',[Validators.required]],
      district: ['', [Validators.required]],
      wards: ['', [Validators.required]],
      street: ['', [Validators.required]],
      weight: [0, [Validators.required]],
      petGender: [0],
      petDesexed: [0],
      petWormed: [0],
      petVaccined: [0],
      petEntryDate: [new Date()],
    })

    
  }

}
