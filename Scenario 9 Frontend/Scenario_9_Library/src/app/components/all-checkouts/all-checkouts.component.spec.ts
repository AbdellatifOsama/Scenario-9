import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllCheckoutsComponent } from './all-checkouts.component';

describe('AllCheckoutsComponent', () => {
  let component: AllCheckoutsComponent;
  let fixture: ComponentFixture<AllCheckoutsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllCheckoutsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllCheckoutsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
