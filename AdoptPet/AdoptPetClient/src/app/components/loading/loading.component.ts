import { Component, inject } from '@angular/core';
import { LoadingStore } from '../../shared/stores/loading.store';

@Component({
  selector: 'app-loading',
  standalone: true,
  imports: [],
  templateUrl: './loading.component.html',
  styleUrl: './loading.component.scss',
})
export class LoadingComponent {
  loadingStore = inject(LoadingStore);
}
