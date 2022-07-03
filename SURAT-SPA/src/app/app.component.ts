import { Component, OnInit } from '@angular/core';
import { PrintService } from './_service/print.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SURAT-SPA';

  constructor(
    private printService: PrintService
  ) {}

  ngOnInit() {
    
  }
}
