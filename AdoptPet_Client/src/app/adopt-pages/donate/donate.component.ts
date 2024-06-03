import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { PetService } from '../../services/pet.service';
import { environment } from '../../../environments/environment.development';

@Component({
	selector: 'app-donate',
	standalone: true,
	imports: [RouterLink],
	templateUrl: './donate.component.html',
	styleUrl: './donate.component.scss',
})
export class DonateComponent {
  pets: any = [];
  pageNumber: number = 1;
	pageSize: number = 4;
  baseImg = environment.baseImgUrl;
  
	constructor(private petService: PetService) {}

	ngOnInit() {
    this.getPets()
  }

  private getPets() {
		this.petService.getAllPets(this.pageNumber, this.pageSize).subscribe({
			next: (res: any) => {
				console.log(res.data);
				this.pets = res.data;
			},
			error: err => {
				console.log(err);
			},
		});
	}

}
