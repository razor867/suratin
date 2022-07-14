import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { ToastrModule } from 'ngx-toastr';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule, TitleCasePipe } from '@angular/common';
// import { JwtModule } from '@auth0/angular-jwt';
import { TableModule } from 'primeng/table';
import { CalendarModule } from 'primeng/calendar';
import { ModalModule } from 'ngx-bootstrap/modal';
import { PrintService } from './_service/print.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { PanelMenuModule } from 'primeng/panelmenu';
import { RadioButtonModule } from 'primeng/radiobutton';
import { BlockUIModule } from 'primeng/blockui';
import { TooltipModule } from 'primeng/tooltip';
import { DataViewModule } from 'primeng/dataview';
import { KeyFilterModule } from 'primeng/keyfilter';
import { ProgressBarModule } from 'primeng/progressbar';
import { DropdownModule } from 'primeng/dropdown';
// import { LoginComponent } from './login/login.component';
import { AccordionModule } from 'primeng/accordion';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { LayoutComponent } from './print/layout/layout.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './core/home/home.component';
import { SuratmasukComponent } from './core/suratmasuk/suratmasuk.component';
import { SuratkeluarComponent } from './core/suratkeluar/suratkeluar.component';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    HomeComponent,
    SuratmasukComponent,
    SuratkeluarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TableModule,
    ConfirmDialogModule,
    BsDatepickerModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CalendarModule,
    ModalModule,
    CommonModule,
    BrowserAnimationsModule,
    ScrollPanelModule,
    OverlayPanelModule,
    PanelMenuModule,
    BlockUIModule,
    RadioButtonModule,
    AutoCompleteModule,
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      maxOpened: 2,
      autoDismiss: true
    }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    ConfirmationService,
    PrintService,
    TitleCasePipe
],
  bootstrap: [AppComponent]
})
export class AppModule { }
