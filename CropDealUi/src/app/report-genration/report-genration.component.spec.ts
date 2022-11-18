import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportGenrationComponent } from './report-genration.component';

describe('ReportGenrationComponent', () => {
  let component: ReportGenrationComponent;
  let fixture: ComponentFixture<ReportGenrationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportGenrationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportGenrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
