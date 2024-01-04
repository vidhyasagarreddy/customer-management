import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ICustomer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.services';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.css']
})
export class CustomersListComponent implements OnInit, OnDestroy {
  customers!: ICustomer[];

  private selectedCustomer!: ICustomer;
  private subscription: Subscription = new Subscription();

  constructor(
    private router: Router,
    private readonly customerService: CustomerService) {
  }


  ngOnInit(): void {
    this.loadCustomers();
  }

  onRowEditInit(customer: ICustomer): void {
    this.selectedCustomer = { ...customer };
  }

  onRowEditSave(customer: ICustomer, index: number): void {
    this.subscription.add(this.customerService.updateCustomer(customer).subscribe(_customer => {
      this.customers[index] = _customer;
    }));
  }

  onRowEditCancel(customer: ICustomer, index: number): void {
    this.customers[index] = { ...this.selectedCustomer };
  }

  deleteCustomer(identifier: string, index: number): void {
    this.subscription.add(this.customerService.deleteCustomer(identifier).subscribe(response => {
      if (response) {
        this.customers = this.customers.filter(m => m.identifier !== identifier);
      }
      else {
        alert("Failed to delete Customer, pelase try again");
      }
    }));
  };

  navigateToAddCustomer(): void {
    this.router.navigate(['/add-customer']);
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

  private loadCustomers(): void {
    this.subscription.add(this.customerService.getAllCustomers().subscribe(customers => {
      this.customers = customers;
    }));
  }
}
