/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { SingledrivetimeviolationsComponent } from './singledrivetimeviolations.component';

describe('SingledrivetimeviolationsComponent', () => {
  let component: SingledrivetimeviolationsComponent;
  let fixture: ComponentFixture<SingledrivetimeviolationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SingledrivetimeviolationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SingledrivetimeviolationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
