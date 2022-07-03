/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { SuratmasukComponent } from './suratmasuk.component';

describe('SuratmasukComponent', () => {
  let component: SuratmasukComponent;
  let fixture: ComponentFixture<SuratmasukComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SuratmasukComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SuratmasukComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
