import { TestBed } from '@angular/core/testing';

import { ChangestatusService } from './changestatus.service';

describe('ChangestatusService', () => {
  let service: ChangestatusService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChangestatusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
