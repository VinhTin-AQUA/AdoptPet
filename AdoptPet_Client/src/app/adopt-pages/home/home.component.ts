import { Component } from '@angular/core';
import { Carousel, initTWE } from 'tw-elements';

import { RouterLink, RouterLinkActive } from '@angular/router';
import { PetDto } from '../../shared/models/pet/PetDto';
import { PetService } from '../../services/pet.service';
import { environment } from '../../../environments/environment.development';

@Component({
	selector: 'app-home',
	standalone: true,
	imports: [RouterLink, RouterLinkActive],
	templateUrl: './home.component.html',
	styleUrl: './home.component.scss',
})
export class HomeComponent {
	pets: PetDto[] = [];
  baseImg = environment.baseImgUrl;

	constructor(private petService: PetService) {}

	ngOnInit() {
		initTWE({ Carousel });
		// window.scrollTo(0, 0);

    this.getPets();
	}

  private getPets() {
    this.petService.getAllPets(1, 4).subscribe({
      next: (res: any) => {
        console.log(res);
        this.pets = res.data;
      }, error: (err) => {
        console.log(err);
        
      }
    })
  }
}
