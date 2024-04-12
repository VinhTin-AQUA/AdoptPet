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

  constructor(private breedService: BreedService) {}

  ngOnInit() {
    this.breedService.getAllBreed().subscribe({
      next: (res: any) => {
        // console.log(res.data);
        this.breeds = res.data;
      },
      error: (err) => {
        console.log(err);
        
      }
    })
  }


}
