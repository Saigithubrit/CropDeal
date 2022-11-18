import { TestBed } from '@angular/core/testing';

import { CropsonsaleService } from './cropsonsale.service';

describe('CropsonsaleService', () => {
  let service: CropsonsaleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CropsonsaleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
