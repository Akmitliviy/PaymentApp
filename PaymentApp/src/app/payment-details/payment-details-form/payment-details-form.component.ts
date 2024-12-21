import {Component} from '@angular/core';
import {PaymentDetailsService} from '../../shared/payment-details.service';
import {FormsModule, NgForm} from '@angular/forms';
import {PaymentDetails} from '../../shared/payment-details.model';
import {ToastrModule, ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-payment-details-form',
  standalone: true,
  imports: [
    FormsModule,
    ToastrModule,
  ],
  templateUrl: './payment-details-form.component.html',
  styles: ``
})
export class PaymentDetailsFormComponent {

  constructor(public service: PaymentDetailsService, private toastr: ToastrService) {}

  onSubmit(form: NgForm) {
    this.service.formSubmitted = true;
    if(form.valid) {
      if(this.service.formData.paymentDetailsId == ""){
        this.insertRecord(form);
      }else{
        this.updateRecord(form);
      }
    }
  }

  insertRecord(form: NgForm) {
    this.service.postPaymentDetails().subscribe({
      next: data => {
        console.log(data);
        this.service.list.push(data as PaymentDetails);
        this.service.resetForm(form);
        this.toastr.success('Payment Details Successfully Added!');
      },
      error: error => {
        console.log(error)
      },
    });
  }

  updateRecord(form: NgForm) {
    this.service.putPaymentDetails().subscribe({
      next: data => {
        console.log(data);
        let newObj = data as PaymentDetails;
        let oldObj = this.service.list.find(element => element.paymentDetailsId == newObj.paymentDetailsId);
        if(oldObj){
          oldObj.cardOwnerName = newObj.cardOwnerName;
          oldObj.cardNumber = newObj.cardNumber;
          oldObj.expirationDate = newObj.expirationDate;
          oldObj.cardVerificationValue = newObj.cardVerificationValue;

        }
        this.service.resetForm(form);
        this.toastr.success('Payment Details Successfully Updated!');},
      error: error => {console.log(error)}
    })
  }
}
