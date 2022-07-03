import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
// import { Dpk } from '../_model/Dpk';

@Injectable({
  providedIn: 'root',
})
export class PrintService {
  isPrinting = false;
  // dpkObject: Dpk;

  constructor(private router: Router) {}

  printDocument(documentName: string, documentId: string[], documentData?: any) {
    this.isPrinting = true;
    // if (documentName === 'dpk' && documentData) {
    //   this.dpkObject = documentData;
    // }
    this.router.navigate([
      '/',
      {
        outlets: {
          print: ['print', documentName, documentId.join()],
        },
      },
    ]);
  }

  onDataReady() {
    setTimeout(() => {
      window.print();
      this.isPrinting = false;
      this.router.navigate([{ outlets: { print: null } }]);
    }, 250);
  }
}