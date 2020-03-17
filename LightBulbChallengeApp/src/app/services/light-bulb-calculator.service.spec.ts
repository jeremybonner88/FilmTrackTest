import { TestBed } from '@angular/core/testing';

import { LightBulbCalculatorService } from './light-bulb-calculator.service';

describe('LightBulbCalculatorService', () => {
  let service: LightBulbCalculatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LightBulbCalculatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
