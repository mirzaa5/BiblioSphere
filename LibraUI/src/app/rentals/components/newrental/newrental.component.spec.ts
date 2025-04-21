import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewrentalComponent } from './newrental.component';

describe('NewrentalComponent', () => {
  let component: NewrentalComponent;
  let fixture: ComponentFixture<NewrentalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NewrentalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewrentalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
