import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { KisidetayService } from '../kisidetay.service';
@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {
  @Input() public kisiid:any;
  @Input() kisi:any;
  data: any;
  id:any;
  KisiDetayData!: FormGroup;
  submitted = false;
  EventValue: any = "Save";

  constructor(private activeModal: NgbActiveModal,
    private KisidetayService: KisidetayService
    ) {}

  ngOnInit(): void {
    this.getdata();

    this.KisiDetayData = new FormGroup({

      //  id: new FormControl(""),
      telefonNo: new FormControl("",[Validators.required]),
      email: new FormControl("",[Validators.required]),
      konum: new FormControl("",[Validators.required]),
      icerik: new FormControl("",[Validators.required]),
      kisiID: new FormControl("",[Validators.required]),
    });
    this.KisiDetayData.controls["kisiID"].setValue(this.kisiid);

  }
  getdata() {
    this.KisidetayService.getData(this.kisiid).subscribe((data: any) => {
      this.data = data;
      console.log(this.data);
    })
  }
  deleteData(id:any) {
    console.log("delete "+id);
    this.KisidetayService.deleteData(id).subscribe((data: any) => {
      this.data = data;
      this.getdata();

    })
  }

  Save() {
    this.submitted = true;
     if (this.KisiDetayData.invalid) {
            return;
     }
    this.KisidetayService.postData(this.kisiid,this.KisiDetayData.value).subscribe((data: any) => {
      this.data = data;
      this.resetFrom();
      this.getdata();

    })
  }

  Update() {
    this.submitted = true;

    if (this.KisiDetayData.invalid) {
     return;
    }
    console.log(this.KisiDetayData.value);
    this.KisidetayService.putData(this.id,this.KisiDetayData.value).subscribe((data: any) => {
      this.data = data;
      this.resetFrom();
      this.getdata();

    })
  }

  EditData(Data:any) {
    this.KisiDetayData.controls["telefonNo"].setValue(Data.telefonNo);
    this.KisiDetayData.controls["email"].setValue(Data.email);
    this.KisiDetayData.controls["konum"].setValue(Data.konum);
    this.KisiDetayData.controls["icerik"].setValue(Data.icerik);
    this.KisiDetayData.controls["kisiID"].setValue(this.kisiid);
    this.id=Data.id;

    this.EventValue = "Update";
  }

  resetFrom()
  {
    this.getdata();
    this.KisiDetayData.reset();
    this.EventValue = "Save";
    this.submitted = false;
  }
  closeModal() {
    this.activeModal.close('Modal Closed');
  }

}
