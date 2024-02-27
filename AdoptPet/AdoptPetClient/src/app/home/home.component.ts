import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PetfinderService } from '../services/petfinder.service';

@Component({
	selector: 'app-home',
	standalone: true,
	imports: [FormsModule],
	templateUrl: './home.component.html',
	styleUrl: './home.component.scss',
})
export class HomeComponent {
	petType: string = 'Dog';
	distance: string = '10';
	isShownTypes: boolean = false;
	isShownMiles: boolean = false;
	cityName: string = '';

	types: string[] = [
		'Dog',
		'Cat',
		'Rabbit',
		'Horse',
		'Bird',
		'Barnyard',
	];
	miles: string[] = ['10', '25', '50', '100', 'Anywhere'];

  breeds: string[] = [];
	ages: string[] = ['Any', 'Kitten', 'Young', 'Adult', 'Senior'];
	sizes: string[] = ['Small', 'Medium', 'Large', 'Extra Large'];
	gender: string[] = ['Male', 'Female'];
	goodWith: string[] = ['Kids', 'Dogs', 'Other cats'];
	colors: string[] = [
		'Black',
		'Blue Cream',
		'Blue Point',
		'Calico',
		'Chocolate Point',
		'Cream Point',
		'Dilute Calico',
		'Dilute Tortoiseshell',
		'Flame Point',
		'Gray & White',
		'Lilac Point',
		'Orange & White',
		'Seal Point',
		'Smoke',
		'Torbie',
		'Tortoiseshell',
		'White',
	];

  constructor(private petService:PetfinderService) {

  }

  async ngOnInit() {
    (await this.petService.getBreeds('Dog')).subscribe({
      next: (res: any) => {
        // console.log(res.breeds);
        this.breeds = res.breeds.map((b:any) => b.name)
      },
      error: (err: any) => {
        console.log(err);
      }
    })
  }

	onShowType() {
		this.isShownTypes = !this.isShownTypes;
	}

	onShowMile() {
		this.isShownMiles = !this.isShownMiles;
	}

	onChooseType(type: string) {
		this.petType = type;
		this.onShowType();
	}

	onChooseMile(mile: string) {
		this.distance = mile;
		this.onShowMile();
	}

	onSearch() {
		console.log(this.petType);
		console.log(this.distance);
		console.log(this.cityName);
	}
}
