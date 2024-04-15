import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { SignUp } from '../../shared/models/account/SignUp';
import { NoticeStore } from '../../shared/stores/NoticeStore';
import { patchState } from '@ngrx/signals';

@Component({
	selector: 'app-signup',
	standalone: true,
	imports: [RouterLink, ReactiveFormsModule],
	templateUrl: './signup.component.html',
	styleUrl: './signup.component.scss',
})
export class SignupComponent {
	signupForm!: FormGroup;
	submitted: boolean = false;
	noticeStore = inject(NoticeStore)

	constructor(
		private formBuilder: FormBuilder, 
		private router: Router,
		private accountService: AccountService) {}

	ngOnInit() {
		this.signupForm = this.formBuilder.group({
			firstName: ['', [Validators.required]],
			lastName: ['', [Validators.required]],
			email: ['', [Validators.required, Validators.email]],
			phone: ['', [Validators.required]],
			password: ['', [Validators.required]],
			confirmPassword: ['', [Validators.required]],
		});
	}

	onSubmit() {
		this.submitted = true;
		if (this.signupForm.valid === false) {
			return;
		}

		const model: SignUp = {
			firstName: this.signupForm.controls['firstName'].value,
			lastName: this.signupForm.controls['lastName'].value,
			email: this.signupForm.controls['email'].value,
			phoneNumber: this.signupForm.controls['phone'].value,
			password: this.signupForm.controls['password'].value,
			confirmPassword: this.signupForm.controls['confirmPassword'].value,
		};

		this.accountService.signup(model).subscribe({
			next: (res: any) => {
				// console.log(res.value.message);
				// console.log(res.value.title);

				patchState(this.noticeStore, { status: true, title: res.value.title, message: res.value.message })
				this.router.navigateByUrl('/notice')
			},
			error: (err) => {
				console.log(err);
			}
		})
	}
}
