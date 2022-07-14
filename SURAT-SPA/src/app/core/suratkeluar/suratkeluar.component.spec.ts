/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { SuratkeluarComponent } from './suratkeluar.component';

describe('SuratkeluarComponent', () => {
  let component: SuratkeluarComponent;
  let fixture: ComponentFixture<SuratkeluarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SuratkeluarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SuratkeluarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
