import { Component, ElementRef, inject } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { DialogComponent } from './components/dialog/dialog.component';
import { DialogStore } from './shared/stores/dialogStore';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, FooterComponent, DialogComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'AdoptPet';
  dialog = inject(DialogStore);
  
  constructor(
    private router: Router,
    private element: ElementRef
  ) {
    this.router.events.subscribe((path) => {
      this.element.nativeElement.scrollIntoView();
    });
  }

}
