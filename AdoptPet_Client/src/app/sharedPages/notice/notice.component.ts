import { Component, inject } from '@angular/core';
import { NoticeStore } from '../../shared/stores/NoticeStore';

@Component({
  selector: 'app-notice',
  standalone: true,
  imports: [],
  templateUrl: './notice.component.html',
  styleUrl: './notice.component.scss'
})
export class NoticeComponent {
  noticeStore = inject(NoticeStore);
}
