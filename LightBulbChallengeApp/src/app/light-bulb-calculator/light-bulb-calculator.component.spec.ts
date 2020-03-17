import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LightBulbCalculatorComponent } from './light-bulb-calculator.component';

describe('LightBulbCalculatorComponent', () => {
  let component: LightBulbCalculatorComponent;
  let fixture: ComponentFixture<LightBulbCalculatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LightBulbCalculatorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LightBulbCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
