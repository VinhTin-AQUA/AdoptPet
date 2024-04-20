import { Component, inject } from '@angular/core';
import { NoticeStore } from '../../shared/stores/NoticeStore';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-notice',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './notice.component.html',
  styleUrl: './notice.component.scss'
})
export class NoticeComponent {
  noticeStore = inject(NoticeStore);
}
