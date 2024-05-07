import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Breed } from '../../../shared/models/breed/breed';
import { BreedService } from '../../../services/breed.service';
import { environment } from '../../../../environments/environment.development';

@Component({
  selector: 'app-breed-manager',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './breed-manager.component.html',
  styleUrl: './breed-manager.component.scss'
})
export class BreedManagerComponent {
  breeds: Breed[] =[]
  baseBreedImage = environment.baseImgUrl + '/Breeds';
  pageNumber: number = 1;
  pageSize: number = 8;

  constructor(private breedService: BreedService) {}

  ngOnInit() {
    this.getBreeds();
  }

  private getBreeds() {
    this.breedService.getAllBreed(this.pageNumber, this.pageSize).subscribe({
      next: (res: any) => {
        // console.log(res.data);
        this.breeds = res.data;
      },
      error: (err) => {
        console.log(err);
      }
    })
  }
  

  onPrevPage() {
		this.pageNumber--;
		if (this.pageNumber < 1) {
			this.pageNumber = 1;
		}
		this.getBreeds();
	}

	onNextPage() {
		this.pageNumber++;
		this.getBreeds();
	}



}
