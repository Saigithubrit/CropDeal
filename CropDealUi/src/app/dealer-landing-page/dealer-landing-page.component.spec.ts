import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DealerLandingPageComponent } from './dealer-landing-page.component';

describe('DealerLandingPageComponent', () => {
  let component: DealerLandingPageComponent;
  let fixture: ComponentFixture<DealerLandingPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DealerLandingPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DealerLandingPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
