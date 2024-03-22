import { TestBed } from '@angular/core/testing';

import { WarehouseownerService } from './warehouseowner.service';

describe('WarehouseownerService', () => {
  let service: WarehouseownerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WarehouseownerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
