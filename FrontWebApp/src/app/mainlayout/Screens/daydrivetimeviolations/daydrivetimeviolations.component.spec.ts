/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DaydrivetimeviolationsComponent } from './daydrivetimeviolations.component';

describe('DaydrivetimeviolationsComponent', () => {
  let component: DaydrivetimeviolationsComponent;
  let fixture: ComponentFixture<DaydrivetimeviolationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DaydrivetimeviolationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DaydrivetimeviolationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
