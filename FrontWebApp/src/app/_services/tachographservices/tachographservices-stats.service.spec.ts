import { TestBed } from '@angular/core/testing';

import { TachographServicesStatsService } from './tachographservices-stats.service';

describe('TachographServicesStatsService', () => {
  let service: TachographServicesStatsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TachographServicesStatsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
