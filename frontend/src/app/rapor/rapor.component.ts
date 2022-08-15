import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';
import { RaporService } from '../rapor.service';
import { RapordetayComponent } from '../rapordetay/rapordetay.component';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-rapor',
  templateUrl: './rapor.component.html',
  styleUrls: ['./rapor.component.css']
})
export class RaporComponent implements OnInit {

  constructor(private sanitizer: DomSanitizer,
    public modalService: NgbModal,
    private raporService: RaporService
  ) { }
  data: any;
  id: any;
  RaporData!: FormGroup;
  submitted = false;
  EventValue: any = "Save";

  ngOnInit(): void {
    this.getdata();

    this.RaporData = new FormGroup({
      konum: new FormControl("", [Validators.required]),
    })
  }
  download(url: string) {
    console.log(url);
    window.open(url);

    return this.sanitizer.bypassSecurityTrustUrl(url);
  }

  getdata() {
    this.raporService.getData().subscribe((data: any) => {
      this.data = data;
      console.log(this.data);
    })
  }
  deleteData(id: any) {
    console.log("delete " + id);
    this.raporService.deleteData(id).subscribe((data: any) => {
      this.data = data;
      this.getdata();

    })
  }

  Save() {
    this.submitted = true;
    if (this.RaporData.invalid) {
      return;
    }
    this.raporService.postData(this.RaporData.value).subscribe((data: any) => {
      this.data = data;
      setTimeout(() => {}, 3000);
      this.getdata();

    })
  }

  openModal(data: any) {
    //ModalComponent is component name where modal is declare
    console.log(this.RaporData);
    const modalRef = this.modalService.open(RapordetayComponent);
    modalRef.componentInstance.detayid = data.id;

    modalRef.result.then((result) => {
      console.log(result);
    }).catch((error) => {
      console.log(error);
    });
  }

}
