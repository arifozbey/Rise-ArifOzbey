import { TestBed } from '@angular/core/testing';

import { RaporService } from './rapor.service';

describe('RaporService', () => {
  let service: RaporService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RaporService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
