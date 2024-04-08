import { Component, ElementRef } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { HeaderComponent } from '../components/header/header.component';
import { FooterComponent } from '../components/footer/footer.component';

@Component({
  selector: 'app-adopt-pages',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, FooterComponent],
  templateUrl: './adopt-pages.component.html',
  styleUrl: './adopt-pages.component.scss'
})
export class AdoptPagesComponent {

  constructor(
    private router: Router,
    private element: ElementRef
  ) {
    this.router.events.subscribe((path) => {
      this.element.nativeElement.scrollIntoView();
    });
  }
  
}
