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

  images: string[] = [
    "/assets/bg-home/bg-home-1.jpeg",
    "/assets/bg-home/bg-home-2.jpeg",
    "/assets/bg-home/bg-home-3.jpeg",
    "/assets/bg-home/bg-home-4.jpeg",
    "/assets/bg-home/bg-home-5.jpeg",
    "/assets/bg-home/bg-home-6.jpeg",
  ];

  ngOnInit() {
    initTWE({ Carousel });
  }
  
  
  
}
