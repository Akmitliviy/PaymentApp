import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {v4 as uuidv4} from "uuid"
import {HttpClient} from '@angular/common/http';
import {PaymentDetails} from './payment-details.model';
import {NgForm} from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class PaymentDetailsService {

  url: string = environment.apiBaseUrl + '/PaymentDetails';
  list:PaymentDetails[] = [];
  formData: PaymentDetails = new PaymentDetails()
  formSubmitted: boolean = false;
  constructor(private http: HttpClient) { }

  refreshList(){
    this.http.get(this.url)
    .subscribe({
      next: res => {this.list = res as PaymentDetails[]; console.log(this.list);},
      error: err => {console.log(err)},
    })
  }

  postPaymentDetails(){
    console.log(JSON.stringify(this.formData));
    this.formData.paymentDetailsId = uuidv4();
    return this.http.post(this.url, this.formData)
  }

  putPaymentDetails(){
    return this.http.put(this.url + "/" + this.formData.paymentDetailsId, this.formData)
  }
  deletePaymentDetails(id: string){
    return this.http.delete(this.url + "/" + id);
  }

  resetForm(form:NgForm) {
    form.reset();
    this.formData = new PaymentDetails();
    this.formSubmitted = false;
  }
}
