import { Component, inject } from '@angular/core';
import { RouterLinkActive, RouterLink } from '@angular/router';
import { UserStore } from '../../shared/stores/UserStore';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLinkActive,RouterLink],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  userStore = inject(UserStore);
}
