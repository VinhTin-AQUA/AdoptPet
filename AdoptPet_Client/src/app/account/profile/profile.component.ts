import { Component, inject } from '@angular/core';
import { HeaderComponent } from '../../components/header/header.component';
import { FooterComponent } from '../../components/footer/footer.component';
import { Router, RouterLink } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { UserStore } from '../../shared/stores/UserStore';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
	selector: 'app-profile',
	standalone: true,
	imports: [HeaderComponent, FooterComponent, RouterLink, ReactiveFormsModule],
	templateUrl: './profile.component.html',
	styleUrl: './profile.component.scss',
})
export class ProfileComponent {
	userForm!: FormGroup;
	userStore = inject(UserStore);

	constructor(
		private accountService: AccountService,
		private formBuilder: FormBuilder,
		private router: Router
	) {}

	ngOnInit() {
    console.log(this.userStore.firstName());
    
		this.userForm = this.formBuilder.group({
			firstName: [this.userStore.firstName()],
			lastName: [this.userStore.lastName()],
			phone: [this.userStore.phoneNumber()],
			email: [this.userStore.email()],
		});
	}

	signOut() {
		this.accountService.checkSignOut();
		this.router.navigateByUrl('/sign-in');
	}
}
