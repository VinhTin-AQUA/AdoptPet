import { Component, ElementRef } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'AdoptPet';

  constructor(
    private router: Router,
    private element: ElementRef
  ) {
    this.router.events.subscribe((path) => {
      this.element.nativeElement.scrollIntoView();
    });
  }

}
