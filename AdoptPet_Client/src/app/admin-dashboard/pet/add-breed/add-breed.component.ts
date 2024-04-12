import { Component } from '@angular/core';
import { BreedService } from '../../../services/breed.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Breed } from '../../../shared/models/breed/breed';

@Component({
  selector: 'app-add-breed',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-breed.component.html',
  styleUrl: './add-breed.component.scss'
})
export class AddBreedComponent {
  breedForm!: FormGroup
  submitted: boolean = false;
  selectedImageOnView: any;
  selectImageToServer: any;

  constructor(private breedService: BreedService,
    private formBuilder: FormBuilder) {
      this.breedForm = this.formBuilder.group({
        breedName: ['',[Validators.required]],
        description: ['', [Validators.required]]
      })
  }

  onImageSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      this.selectImageToServer = file;
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.selectedImageOnView = e.target.result;
      };
      reader.readAsDataURL(file);
    }
  }

  onSubmit() {
    this.submitted = true;

    if( this.breedForm.valid === false) {
      return;
    }
    
    let form = new FormData();
    form.append('breedName', this.breedForm.controls['breedName'].value);
    form.append('description', this.breedForm.controls['description'].value);
    form.append('file', this.selectImageToServer);

    // const breed: Breed = {
    //   breedName: this.breedForm.controls['breedName'].value,
    //   description: this.breedForm.controls['description'].value,
    // }

    this.breedService.addBreed(form).subscribe({
      next: (res: any) => {
        console.log(res);
        
      }, error(err) {
        console.log(err);
        
      },
    })
    
  }
}
