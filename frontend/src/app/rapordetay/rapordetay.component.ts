import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { RaporService } from '../rapor.service';

@Component({
  selector: 'app-rapordetay',
  templateUrl: './rapordetay.component.html',
  styleUrls: ['./rapordetay.component.css']
})
export class RapordetayComponent implements OnInit {
  @Input() detayid: any;
  data: any;
  Durumu: string = "Durum Detay"
  RaporDetayData!: FormGroup;
  constructor(private activeModal: NgbActiveModal, private sanitizer: DomSanitizer,
    private RaporService: RaporService
  ) { }

  ngOnInit(): void {
    this.getdata();

    this.RaporDetayData = new FormGroup({

      //  id: new FormControl(""),
      talepTarihi: new FormControl("", [Validators.required]),
      konum: new FormControl("", [Validators.required]),
      durumu: new FormControl("", [Validators.required]),
      dosyapath: new FormControl("", [Validators.required]),
    });
  }
  download(data: string) {
    const blob = new Blob([data], { type: 'application/octet-stream' });
    const url = window.URL.createObjectURL(blob);
    window.open(url);
  }
  getdata() {
    this.RaporService.Detay(this.detayid).subscribe((data: any) => {
      this.data = data;
      console.log(this.data);
    })
  }

  closeModal() {
    this.activeModal.close('Modal Closed');
  }


}
