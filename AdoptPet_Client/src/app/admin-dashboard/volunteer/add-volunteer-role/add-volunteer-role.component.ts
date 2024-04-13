import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { VolunteerRoleService } from '../../../services/volunteer-role.service';
import { VolunteerRoleDto } from '../../../shared/models/volunteer-role/VolunteerRoleDto';
import { Router } from '@angular/router';

@Component({
	selector: 'app-add-volunteer-role',
	standalone: true,
	imports: [ReactiveFormsModule],
	templateUrl: './add-volunteer-role.component.html',
	styleUrl: './add-volunteer-role.component.scss',
})
export class AddVolunteerRoleComponent {
	volunteerRoleForm!: FormGroup;
	submitted: boolean = false;

	constructor(
		private formBuilder: FormBuilder,
		private volunteerRolerService: VolunteerRoleService,
    private router: Router
	) {}

	ngOnInit() {
		this.volunteerRoleForm = this.formBuilder.group({
			roleName: ['', Validators.required],
			description: ['', Validators.required],
		});
	}

	onSubmit() {
		this.submitted = true;

		if (this.volunteerRoleForm.valid === false) {
			return;
		}

		console.log(this.volunteerRoleForm.value);
		const role: VolunteerRoleDto = {
			name: this.volunteerRoleForm.controls['roleName'].value,
			description: this.volunteerRoleForm.controls['description'].value,
		};

		this.volunteerRolerService.addVolunteerRole(role).subscribe({
			next: (res: any) => {
				// console.log(res);
        this.router.navigateByUrl('/admin/volunteer-role');
			},
			error: err => {
				console.log(err);
			},
		});
	}
}
