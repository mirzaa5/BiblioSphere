import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RentalhistoryComponent } from './rentalhistory.component';

describe('RentalhistoryComponent', () => {
  let component: RentalhistoryComponent;
  let fixture: ComponentFixture<RentalhistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RentalhistoryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RentalhistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
