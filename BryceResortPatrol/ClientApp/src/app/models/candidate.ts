export class Candidate {
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  description: string;
  constructor(
    firstName: string,
    lastName: string,
    email: string,
    phoneNumber: string,
    description: string) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.email = email;
    this.phoneNumber = phoneNumber;
    this.description = description;
  }
}
