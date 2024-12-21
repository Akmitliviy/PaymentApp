import {Component} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {PaymentDetailsComponent} from './payment-details/payment-details.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, PaymentDetailsComponent],
  templateUrl: './app.component.html',
  styles: [],
})
export class AppComponent {
  title = 'PaymentApp';
}
