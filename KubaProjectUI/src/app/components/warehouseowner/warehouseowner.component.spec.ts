import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WarehouseownerComponent } from './warehouseowner.component';

describe('WarehouseownerComponent', () => {
  let component: WarehouseownerComponent;
  let fixture: ComponentFixture<WarehouseownerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WarehouseownerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WarehouseownerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
