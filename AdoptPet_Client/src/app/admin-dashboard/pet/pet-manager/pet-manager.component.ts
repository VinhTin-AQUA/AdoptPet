import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-pet-manager',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './pet-manager.component.html',
  styleUrl: './pet-manager.component.scss'
})
export class PetManagerComponent {
  constructor() {}

  ngOnInit() {
    
  }
}
