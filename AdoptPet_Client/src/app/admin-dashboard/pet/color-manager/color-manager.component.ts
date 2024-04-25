import { Component } from '@angular/core';
import { ColorService } from '../../../services/color.service';
import { Color } from '../../../shared/models/color/Color';

@Component({
  selector: 'app-color-manager',
  standalone: true,
  imports: [],
  templateUrl: './color-manager.component.html',
  styleUrl: './color-manager.component.scss'
})
export class ColorManagerComponent {
  colors: Color[] =[];

  constructor(private colorService: ColorService) {}

  ngOnInit() {
    this.colorService.getAllColor().subscribe({
      next: (res: any) => {
        this.colors = res.data
      }, error: (err) => {
        console.log(err);
      }
    })
  }

  onAddColor(inputColor: HTMLInputElement) {
    if(inputColor.value === '') {
      return;
    }

    console.log(inputColor.value);
    this.colorService.addColor(inputColor.value).subscribe({
      next: (res: any) => {
        console.log(res);
        this.colors.push(res.data);
      }, error: (err) => {
        console.log(err);
      }
    })
  }

  onDelete(id: number) {
    this.colorService.softDeleteColor(id).subscribe({
      next: (res: any) => {
        const index = this.colors.findIndex(c => c.id === id);

        if(index !== -1) {
          this.colors[index].isDeleted = !this.colors[index].isDeleted
        }
      }, error: (err) => {
        console.log(err);
      }
    })
  }

}
