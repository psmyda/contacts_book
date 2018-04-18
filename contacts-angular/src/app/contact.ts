export class Contact {
  id: number;
  firstName: string;
  lastName: string;
  phone: string;
  constructor (fName: string, lName: string, ph: string) {
    this.firstName = fName;
    this.lastName = lName;
    this.phone = ph;
}
}

