import { Component } from '@angular/core';
import {
  Carousel,
  initTWE,
} from "tw-elements";

import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  ngOnInit() {
    initTWE({ Carousel });
    // window.scrollTo(0, 0);
  }


  
  
  
}
