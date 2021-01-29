import { Component } from '@angular/core';
import { faLock } from '@fortawesome/fontawesome-free';
import { Api } from '../services/api.services';
import { JwtService } from '../services/jwt.services';
import { User } from '../models/user';
import { interval } from 'rxjs';
import { DataSharingService } from '../services/data-sharing.services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
})
export class SignIn {
  faLock = faLock;
  private token: string;
  public loadingSpnIsHdn: boolean = true;
  public btnIsHdn: boolean = false;
  public failedIsHdn: boolean = true;
  public invalidIsHidden: boolean = true;
  public hide: boolean = true;
  constructor(
    private api: Api,
    private jwtService: JwtService,
    private dataSharingService: DataSharingService,
    private router: Router) { }

  public clickSignIn(username: string, password: string, isLocalStorage: boolean) {
    var token = this.jwtService.get(username);
    if (token != null) {
      this.displayLoading();
      this.api.validateToken(token).subscribe(result => {
        this.setSignInMessage(username);
        this.setUserNameLocalStorage(username);
        this.displayBtn();
        //this.router.navigate(['/admin-home']);
      }, err => {
        this.getToken(username, password, isLocalStorage);
      });
    }
    else {
      this.displayLoading();
      this.getToken(username, password, isLocalStorage);
    }
  }

  private getToken(username: string, password: string, isLocalStorage: boolean) {
    var user = new User(username, password);
    this.api.signIn(user).subscribe(result => {
      this.token = result.token;
      this.setSignInMessage(username);
      this.jwtService.set(this.token, username, isLocalStorage);
      this.setUserNameLocalStorage(username);
      this.displayBtn();
      //this.router.navigate(['/admin-home']);
    }, err => {
      this.loadingSpnIsHdn = true;
      this.failedIsHdn = false;
      interval(500).subscribe(e => {
        this.failedIsHdn = true;
        this.displayBtn();
        this.invalidIsHidden = false;
      });
    });
  }

  private displayLoading() {
    this.invalidIsHidden = true;
    this.btnIsHdn = true;
    this.failedIsHdn = true;
    this.loadingSpnIsHdn = false;
  }

  private displayBtn() {
    this.invalidIsHidden = true;
    this.failedIsHdn = true;
    this.loadingSpnIsHdn = true;
    this.btnIsHdn = false;
  }

  private setSignInMessage(username: string) {
    this.dataSharingService.signInMessage.next(username);
    this.dataSharingService.signedIn.next(true);
  }

  private setUserNameLocalStorage(username: string) {
    localStorage.setItem('em-username', username);
  }
}
