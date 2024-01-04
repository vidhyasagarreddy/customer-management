import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IAddCustomer } from 'src/app/models/add-customer.model';
import { CustomerService } from 'src/app/services/customer.services';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnDestroy {
  customerForm = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    email: ['', Validators.required],
  });

  private subscription = new Subscription();

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private readonly customerService: CustomerService) {
  }


  addCustomer(): void {
    const customer = this.customerForm.value as IAddCustomer;
    this.subscription.add(this.customerService.addCustomer(customer).subscribe(customer => {
      this.navigateToCustomersPage();
    }, error => alert('Failed to add Customer, please try again.')));
  }

  navigateToCustomersPage(): void {
    this.router.navigate(['/customers']);
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }
}
