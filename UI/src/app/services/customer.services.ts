import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ICustomer } from "../models/customer.model";
import { IAddCustomer } from "../models/add-customer.model";

const customersEndpoint = 'http://localhost:5134/api/customers';

@Injectable({
    providedIn: 'root',
})
export class CustomerService {
    constructor(private http: HttpClient) { }

    getAllCustomers(): Observable<ICustomer[]> {
        return this.http.get<ICustomer[]>(customersEndpoint);
    }

    addCustomer(customer: IAddCustomer): Observable<ICustomer> {
        return this.http.post<ICustomer>(customersEndpoint, customer);
    }

    updateCustomer(customer: ICustomer): Observable<ICustomer> {
        return this.http.put<ICustomer>(`${customersEndpoint}/${customer.identifier}`, customer);
    }

    deleteCustomer(identifier: string): Observable<boolean> {
        return this.http.delete<boolean>(`${customersEndpoint}/${identifier}`);
    }
}