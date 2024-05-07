import { Component, inject } from '@angular/core';
import {} from 'tw-elements';
import { UserService } from '../../../services/user.service';
import { UserDto } from '../../../shared/models/user/UserDto';
import { DialogStore } from '../../../shared/stores/DialogStore';
import { patchState } from '@ngrx/signals';

@Component({
	selector: 'app-user-manager',
	standalone: true,
	imports: [],
	templateUrl: './user-manager.component.html',
	styleUrl: './user-manager.component.scss',
})
export class UserManagerComponent {
  users: UserDto[] = []
  dialog = inject(DialogStore);
  pageNumber: number = 1;
  pageSize: number = 10;

	constructor(private userService: UserService) {}

  ngOnInit() {
    this.getAllUsers();
  }

  private getAllUsers() {
    this.getUsers();
  }

  private getUsers() {
    this.userService.getAllUsers(this.pageNumber, this.pageSize).subscribe({
      next: (res: any) => {
        // console.log(res);
        this.users = res;
        
      }, error:(err) => {
        console.log(err.error);
      }
    })
  }

  lockUser(user: UserDto) {
    if(user.lockoutEnd === null) {
      this.userService.lockUser(user.id).subscribe({
        next: (res: any) => {
          user.lockoutEnd = res.data;
        },
        error: (err) => {
          if(err.error.data !== null) {
            const messages = err.error.data.join("\n");
            patchState(this.dialog, {isShowed: true, message: messages, title: "Error"})
          }
        }
      })
    } else {
      this.userService.unLockUser(user.id).subscribe({
        next: (res: any) => {
          user.lockoutEnd = null;
        },
        error: (err) => {
          if(err.error.data !== null) {
            const messages = err.error.data.join("\n");
            patchState(this.dialog, {isShowed: true, message: messages, title: "Error"})
          }
        }
      })
    }
  }

  onPrevPage() {
    this.pageNumber--;
    if(this.pageNumber < 1) {
      this.pageNumber = 1
    }
    this.getUsers();
  }

  onNextPage() {
    this.pageNumber++;
    this.getUsers();
  }
}
