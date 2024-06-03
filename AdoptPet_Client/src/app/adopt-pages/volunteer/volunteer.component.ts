import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { environment } from '../../../environments/environment.development';
import { PetService } from '../../services/pet.service';

@Component({
  selector: 'app-volunteer',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './volunteer.component.html',
  styleUrl: './volunteer.component.scss'
})
export class VolunteerComponent {
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
