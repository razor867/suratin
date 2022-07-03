import { Injectable } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import  * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class HelperService {

constructor() { }
  validateFormEntry(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach((field) => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsTouched({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateFormEntry(control);
      }
    });
  }
  isNullOrEmpty(obj: any) {
    if (typeof obj === 'string') {
      return obj === null || obj.match(/^ *$/) !== null;
    }
    if (obj) {
      if (typeof obj === 'object') {
        if (Array.isArray(obj)) {
          return obj.length === 0;
        }
        return Object.keys(obj).length === 0;
      }
    }

    return typeof obj === 'undefined' || (typeof obj !== 'object' || !obj);
  }

  compareValues(key: any, order = 'asc') {
    return function innerSort(a: any, b: any) {
      if (!a.hasOwnProperty(key) || !b.hasOwnProperty(key)) {
        // property doesn't exist on either object
        return 0;
      }

      const varA = (typeof a[key] === 'string')
        ? a[key].toUpperCase() : a[key];
      const varB = (typeof b[key] === 'string')
        ? b[key].toUpperCase() : b[key];

      let comparison = 0;
      if (varA > varB) {
        comparison = 1;
      } else if (varA < varB) {
        comparison = -1;
      }
      return (
        (order === 'desc') ? (comparison * -1) : comparison
      );
    };
  }

  setUTCoffset(input: Date): Date {
    if (input) {
      const utcOffset = moment(input).utcOffset();
      return moment(input).add(utcOffset, 'm').toDate();
    }
    return input;
  }
  getLocationName(location: string): string {
    if (location === 'CKP') {
      return 'CIKAMPEK (AGGD)';
    }      
    if (location === 'CFG') {
      return 'CIKAMPEK (FGGD)';
    }
    if (location === 'JKT') {
      return 'JAKARTA';
    }
    if (location === 'SDA') {
      return 'SIDOARJO';
    }

    return location;
  }
}