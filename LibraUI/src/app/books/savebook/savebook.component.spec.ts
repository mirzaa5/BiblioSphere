import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SavebookComponent } from './savebook.component';

describe('SavebookComponent', () => {
  let component: SavebookComponent;
  let fixture: ComponentFixture<SavebookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SavebookComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SavebookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
