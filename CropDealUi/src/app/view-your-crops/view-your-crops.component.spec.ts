import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewYourCropsComponent } from './view-your-crops.component';

describe('ViewYourCropsComponent', () => {
  let component: ViewYourCropsComponent;
  let fixture: ComponentFixture<ViewYourCropsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewYourCropsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewYourCropsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
