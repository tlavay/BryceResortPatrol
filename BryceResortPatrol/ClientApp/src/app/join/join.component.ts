import { Component, ViewChild, ElementRef } from '@angular/core';
import { Candidate } from '../models/candidate';
import { Api } from '../services/api.services';

@Component({
  selector: 'app-join',
  templateUrl: './join.component.html',
  styleUrls: ['./join.component.css']
})
export class JoinComponent {
  @ViewChild('inputForm', { static: true }) inputForm: ElementRef;
  public firstName: string;
  public lastName: string;
  public email: string;
  public phoneNumber: string;
  public description: string;
  public isFormHidden: boolean;
  public loading: boolean;
  public isErrorMessageHidden: boolean = true;

  constructor(private api: Api) { }

  public submit(): void {
    if (this.isEmptyOrUndefined(this.firstName) || this.isEmptyOrUndefined(this.email)) {
      this.inputForm.nativeElement.classList.add('was-validated');
    } else {
      this.isErrorMessageHidden = true;
      this.loading = true;
      this.api.createCandidate(new Candidate(this.firstName, this.lastName, this.email, this.phoneNumber, this.description)).subscribe(response =>
      {
        this.isFormHidden = true;
        this.loading = false;
      },
        error => {
          this.isErrorMessageHidden = false;
          this.loading = false;
        });
    }
  }

  private isEmptyOrUndefined(input: string): boolean {
    if (!input || input.length === 0) {
      return true;
    }
    return false;
  }
}
