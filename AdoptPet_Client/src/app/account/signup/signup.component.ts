import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { AccountService } from '../../services/account.service';

@Component({
	selector: 'app-signup',
	standalone: true,
	imports: [RouterLink, ReactiveFormsModule],
	templateUrl: './signup.component.html',
	styleUrl: './signup.component.scss',
})
export class SignupComponent {
	signupForm!: FormGroup;
	submitted:boolean = false;

	constructor(private formBuilder: FormBuilder, private accountService: AccountService) {}

	ngOnInit() {
		this.signupForm = this.formBuilder.group({
			firstName: ['',[Validators.required]],
			lastName: ['',[Validators.required]],
			email: ['',[Validators.required, Validators.email]],
			phone: ['',[Validators.required]],
			password: ['',[Validators.required]],
			confirmPassword: ['',[Validators.required]],
		});
	}


	onSubmit() {
		this.submitted = true;

		if(this.signupForm.valid === false) {
			
			return;
		}

		console.log(this.signupForm.value);
		
	}
	
}
