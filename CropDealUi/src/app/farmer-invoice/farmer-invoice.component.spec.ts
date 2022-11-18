import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FarmerInvoiceComponent } from './farmer-invoice.component';

describe('FarmerInvoiceComponent', () => {
  let component: FarmerInvoiceComponent;
  let fixture: ComponentFixture<FarmerInvoiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FarmerInvoiceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FarmerInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
