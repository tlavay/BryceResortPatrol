import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { JwtService } from './jwt.services';

@Injectable()
export class AuthService {
  constructor(private jwtHelper: JwtHelperService, private jwtService: JwtService) { }
  public isAuthenticated(): boolean {
    const username = localStorage.getItem('em-username');
    const token = this.jwtService.get(username);
    return !this.jwtHelper.isTokenExpired(token);
  }
}
