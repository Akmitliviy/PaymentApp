import {Component, OnInit} from '@angular/core';
import {PaymentDetailsFormComponent} from './payment-details-form/payment-details-form.component';
import {PaymentDetailsService} from '../shared/payment-details.service';
import {NgForOf} from '@angular/common';
import {PaymentDetails} from '../shared/payment-details.model';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-payment-details',
  imports: [
    PaymentDetailsFormComponent,
    NgForOf
  ],
  templateUrl: './payment-details.component.html',
  styles: ``
})
export class PaymentDetailsComponent implements OnInit {

  constructor(public service: PaymentDetailsService, private toastr: ToastrService) {

  }

  ngOnInit(): void {
        this.service.refreshList()
  }
  populateForm(pd: PaymentDetails){
    this.service.formData = Object.assign({}, pd);
  }
  deleteRegistry(id: string){
    if(confirm('Are you sure you want to delete this record?')){
      this.service.deletePaymentDetails(id).subscribe({
        next: data => {
          console.log(data);
          fetch(this.service.url);
          this.toastr.success('Payment Details Successfully Deleted!');
        },
        error: error => {
          console.log(error)
        },
      });
    }
  }
}
