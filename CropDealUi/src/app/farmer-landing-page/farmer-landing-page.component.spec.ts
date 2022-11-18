import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FarmerLandingPageComponent } from './farmer-landing-page.component';

describe('FarmerLandingPageComponent', () => {
  let component: FarmerLandingPageComponent;
  let fixture: ComponentFixture<FarmerLandingPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FarmerLandingPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FarmerLandingPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
