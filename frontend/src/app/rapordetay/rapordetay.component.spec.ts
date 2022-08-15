import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RapordetayComponent } from './rapordetay.component';

describe('RapordetayComponent', () => {
  let component: RapordetayComponent;
  let fixture: ComponentFixture<RapordetayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RapordetayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RapordetayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
