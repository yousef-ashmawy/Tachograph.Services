/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { WeekdrivetimeviolationsComponent } from './weekdrivetimeviolations.component';

describe('WeekdrivetimeviolationsComponent', () => {
  let component: WeekdrivetimeviolationsComponent;
  let fixture: ComponentFixture<WeekdrivetimeviolationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WeekdrivetimeviolationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WeekdrivetimeviolationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
