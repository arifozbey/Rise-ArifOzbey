import { TestBed } from '@angular/core/testing';

import { KisidetayService } from './kisidetay.service';

describe('KisidetayService', () => {
  let service: KisidetayService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KisidetayService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
