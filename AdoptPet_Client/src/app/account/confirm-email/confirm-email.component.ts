import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { NoticeStore } from '../../shared/stores/NoticeStore';
import { patchState } from '@ngrx/signals';

@Component({
	selector: 'app-confirm-email',
	standalone: true,
	imports: [],
	templateUrl: './confirm-email.component.html',
	styleUrl: './confirm-email.component.scss',
})
export class ConfirmEmailComponent {
	email: string = '';
	token: string = '';
	noticeStore = inject(NoticeStore);

	constructor(
		private activatedRoute: ActivatedRoute,
		private router: Router,
		private accountService: AccountService
	) {}

	ngOnInit() {
		this.getEmailAndToken();
	}

	private getEmailAndToken() {
		this.activatedRoute.queryParams.subscribe((res: any) => {
			// console.log(res.email);
			// console.log(res.token);
			this.email = res.email;
			this.token = res.token;

			this.confirmEmail();
		});
	}

	private confirmEmail() {
		this.accountService.confirmEmail(this.email, this.token).subscribe({
			next: (res: any) => {
				patchState(this.noticeStore, {
					status: true,
					title: 'Xác thực email thành công',
					message: res.messages.join(''),
				});
				this.router.navigateByUrl('/notice');
			},
			error: err => {
				// console.log(err);

				patchState(this.noticeStore, {
					status: false,
					title: 'Xác thực email không thành công',
					message: err.error.messages.join(''),
				});
				this.router.navigateByUrl('/notice');
			},
		});
	}
}
