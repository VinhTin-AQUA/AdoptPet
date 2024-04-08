import { Component } from '@angular/core';



@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.scss'
})
export class ContactComponent {

  ngAfterViewChecked() {
		window.scrollTo(0, 0);
	}
}
