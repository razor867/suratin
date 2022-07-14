import { Component, OnInit, TemplateRef, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/api';
import { SuratKeluar } from 'src/app/_model/SuratKeluar';
import { HelperService } from 'src/app/_service/helper.service';
import { PaginatedResult, Pagination } from 'src/app/_model/Pagination';
import  * as moment from 'moment';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { DataService } from 'src/app/_service/data.service';

@Component({
  selector: 'app-suratkeluar',
  templateUrl: './suratkeluar.component.html',
  styleUrls: ['./suratkeluar.component.css']
})
export class SuratkeluarComponent implements OnInit {
  listSuratKeluar: SuratKeluar[] = [];
  detailSuratKeluar!: SuratKeluar;
  formSuratKeluar!: FormGroup;
  pagination!: Pagination;
  params: any = {};
  loading = true;
  isEdit = false;
  blocked = false;
  title = "";
  modalRef!: BsModalRef;
  bsConfig!: Partial<BsDatepickerConfig>;
  config = {
    ignoreBackdropClick: true,
    // class: 'modal-lg'
  };
  selectedDate!: Date;
  idData = 0;


  constructor(
    private modalService: BsModalService,
    private toastr: ToastrService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService,
    private ui: HelperService,
    private dataService: DataService
  ) { }

  ngOnInit() {
    this.pagination = {
      currentPage: 1,
      itemsPerPage: 10,
      totalItems: 0,
      totalPages: 1
    };
    this.bsConfig = {
      containerClass: 'theme-blue',
      dateInputFormat: 'DD-MM-YYYY'
    };
    this.formInit();
  }

  formInit() {
    this.formSuratKeluar = this.fb.group({
      title: ['', Validators.required],
      noLetter: ['', Validators.required],
      regarding: ['', Validators.required],
      toPerson: ['', Validators.required],
      fromPerson: ['', Validators.required],
      message: ['', Validators.required]
    })
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.first / event.rows + 1;
    this.pagination.itemsPerPage = event.rows;
    this.loadData();
  }

  loadData() {
    if (typeof this.selectedDate != "undefined") {
      this.params.dtft = moment(this.selectedDate).format('YYYYMMDD');
    }
    this.dataService.getListSuratKeluar(this.pagination.currentPage, this.pagination.itemsPerPage, this.params)
      .subscribe({
        next: (res: PaginatedResult<SuratKeluar[]>) => {
          this.listSuratKeluar = res.result;
          this.pagination = res.pagination;
          this.loading = false;
        }
      });
  }

  showForm(template: TemplateRef<any>, item: SuratKeluar | null) {
    this.formSuratKeluar.reset();
    if (item) {
      this.title = 'Edit Surat Keluar';
      this.idData = item.idSuratKeluar;
      this.isEdit = true;
      this.formSuratKeluar.setValue({
        title: item.title,
        noLetter: item.noLetter,
        regarding: item.regarding,
        toPerson: item.toPerson,
        fromPerson: item.fromPerson,
        message: item.message
      });
    } else {
      this.title = 'Add Surat Masuk';
      this.isEdit = false;
    }
    this.modalRef = this.modalService.show(template, this.config);
  }

  del(data: SuratKeluar) {
    this.confirmation.confirm({
      message: 'Are you sure you want to delete this surat masuk?',
      header: 'Confirmation',
      accept: () => {
        this.blocked = true;
        this.dataService.deleteSuratKeluar(this.params, data.idSuratKeluar)
        .subscribe(() => {
              this.blocked = false;
              this.toastr.success('Successfully deleted surat masuk!');
              this.loading = true;
              this.loadData();
            }, (error: any) => {
              this.toastr.error(error.error);
              this.blocked = false;
            });
      }
    });
  }

  detail(template: TemplateRef<any>, data: SuratKeluar | null) {
    if (data) {
      this.detailSuratKeluar = data;
    }
    this.modalRef = this.modalService.show(template, this.config);
  }

  save() {
    if (this.formSuratKeluar.invalid) {
      this.ui.validateFormEntry(this.formSuratKeluar);
      return;
    }

    const data = this.formSuratKeluar.getRawValue();
    this.blocked = true;
    if (this.isEdit) {
      this.dataService.editSuratKeluar(data, this.idData)
      .subscribe({
        next: (res: any) => {
          this.blocked = false;
          this.toastr.success("Successfuly changed data");
          this.modalRef.hide();
          this.loading = true;
          this.loadData();
        },
        error: (err: any) => {
          this.blocked = false;
        }
      })
    } else {
      this.dataService.addSuratKeluar(data)
      .subscribe({
        next: (res: any) => {
          this.blocked = false;
          this.toastr.success("Successfuly added data");
          this.modalRef.hide();
          this.loading = true;
          this.loadData();
        },
        error: (err: any) => {
          this.blocked = false;
        }
      })
    }
  }

}
