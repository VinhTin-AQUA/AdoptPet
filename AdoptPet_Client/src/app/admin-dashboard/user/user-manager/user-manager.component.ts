import { Component } from '@angular/core';
import {} from 'tw-elements';
import { UserService } from '../../../services/user.service';
import { UserDto } from '../../../shared/models/user/UserDto';

@Component({
	selector: 'app-user-manager',
	standalone: true,
	imports: [],
	templateUrl: './user-manager.component.html',
	styleUrl: './user-manager.component.scss',
})
export class UserManagerComponent {
  users: UserDto[] = []

	constructor(private userService: UserService) {}

  ngOnInit() {
    this.getAllUsers();
  }

  private getAllUsers() {
    this.userService.getAllUsers().subscribe({
      next: (res: any) => {
        console.log(res);
        this.users = res;
        
      }, error:(err) => {
        console.log(err.error);
      }
    })
  }
}
