import { TestBed } from '@angular/core/testing';

import { ViewcropsService } from './viewcrops.service';

describe('ViewcropsService', () => {
  let service: ViewcropsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ViewcropsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
