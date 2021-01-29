import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class DataSharingService {
  public signInMessage: BehaviorSubject<string> = new BehaviorSubject<string>('Sign in');
  public signedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
}
