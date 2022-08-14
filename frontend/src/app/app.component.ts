import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from './modal/modal.component';
import { ServiceService } from './service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'arifozbey-rise';
  constructor(
    public modalService: NgbModal,
    private ServiceService: ServiceService
  ) { }
  data: any;
  id: any;
  KisiData!: FormGroup;
  submitted = false;
  EventValue: any = "Save";

  ngOnInit(): void {
    this.getdata();

    this.KisiData = new FormGroup({
      adi: new FormControl("", [Validators.required]),
      soyadi: new FormControl("", [Validators.required]),
      firma: new FormControl("", [Validators.required]),
    })
  }
  getdata() {
    this.ServiceService.getData().subscribe((data: any) => {
      this.data = data;
      console.log(this.data);
    })
  }
  deleteData(id: any) {
    console.log("delete " + id);
    this.ServiceService.deleteData(id).subscribe((data: any) => {
      this.data = data;
      this.getdata();

    })
  }

  Save() {
    this.submitted = true;
    if (this.KisiData.invalid) {
      return;
    }
    this.ServiceService.postData(this.KisiData.value).subscribe((data: any) => {
      this.data = data;
      this.resetFrom();
      this.getdata();

    })
  }

  Update() {
    this.submitted = true;

    if (this.KisiData.invalid) {
      return;
    }
    console.log(this.KisiData.value);
    this.ServiceService.putData(this.id, this.KisiData.value).subscribe((data: any) => {
      this.data = data;
      this.resetFrom();
      this.getdata();

    })
  }

  EditData(Data: any) {
    this.KisiData.controls["firma"].setValue(Data.firma);
    this.KisiData.controls["adi"].setValue(Data.adi);
    this.KisiData.controls["soyadi"].setValue(Data.soyadi);
    this.id = Data.id;

    this.EventValue = "Update";
  }

  resetFrom() {
    this.getdata();
    this.KisiData.reset();
    this.EventValue = "Save";
    this.submitted = false;
  }

  openModal(data:any) {
    //ModalComponent is component name where modal is declare
    console.log(this.KisiData);
    const modalRef = this.modalService.open(ModalComponent);
    modalRef.componentInstance.kisiid = data.id;
    modalRef.componentInstance.kisi = data.firma+": "+data.adi+" "+data.soyadi;

    modalRef.result.then((result) => {
      console.log(result);
    }).catch((error) => {
      console.log(error);
    });
  }
}
