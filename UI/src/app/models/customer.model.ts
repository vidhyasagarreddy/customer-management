export interface ICustomer {
    identifier: string;
    firstName: string;
    lastName: string;
    email: string;
    createdOn: Date;
    modifiedOn?: Date;
}