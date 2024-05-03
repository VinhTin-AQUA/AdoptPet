import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-volunteer-manager',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './volunteer-manager.component.html',
  styleUrl: './volunteer-manager.component.scss'
})
export class VolunteerManagerComponent {
  
  constructor() {}
}
