import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CropOnSaleComponent } from './crop-on-sale.component';

describe('CropOnSaleComponent', () => {
  let component: CropOnSaleComponent;
  let fixture: ComponentFixture<CropOnSaleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CropOnSaleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CropOnSaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
