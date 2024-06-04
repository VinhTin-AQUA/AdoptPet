import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdoptMapComponent } from './adopt-map.component';

describe('AdoptMapComponent', () => {
  let component: AdoptMapComponent;
  let fixture: ComponentFixture<AdoptMapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdoptMapComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdoptMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
