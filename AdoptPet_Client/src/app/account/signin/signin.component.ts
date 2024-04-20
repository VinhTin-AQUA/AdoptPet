import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from '../../components/header/header.component';

@Component({
	selector: 'app-signin',
	standalone: true,
	imports: [RouterLink, ReactiveFormsModule, HeaderComponent],
	templateUrl: './signin.component.html',
	styleUrl: './signin.component.scss',
})
export class SigninComponent {
	signUpForm!: FormGroup;
  isLoginFailed: boolean = false;

	constructor(
		private accountService: AccountService,
		private formBuilder: FormBuilder,
		private router: Router
	) {}

	ngOnInit() {
		this.signUpForm = this.formBuilder.group({
			email: [''],
			password: [''],
		});
	}

	onSignIn() {
    this.isLoginFailed = false;
		this.accountService
			.signin(
				this.signUpForm.controls['email'].value,
				this.signUpForm.controls['password'].value
			)
			.subscribe({
				next: (res: any) => {
					console.log(res);
					this.accountService.checkSignIn(res.data);
					this.accountService.saveJwt(res.data);
          this.router.navigateByUrl('/')
				},
				error: err => {
					console.log(err.error);
          this.isLoginFailed = true;
				},
			});
	}
}
