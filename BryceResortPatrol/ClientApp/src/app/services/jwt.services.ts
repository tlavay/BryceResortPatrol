import { Injectable } from '@angular/core';

@Injectable()
export class JwtService {
  private jwtKey: string = 'em-jwt-key';
  public set(jwtToken: string, username: string, isSession: boolean) {
    const key = `${this.jwtKey}-${username}`;
    if (jwtToken) {
      if (isSession) {
        sessionStorage.setItem(key, jwtToken);
      }
      else {
        localStorage.setItem(key, jwtToken);
      }
    }
  }

  public get(username: string) {
    const key = `${this.jwtKey}-${username}`;
    var jwtToken = sessionStorage.getItem(key);
    if (jwtToken) {
      return jwtToken;
    }

    return localStorage.getItem(key);
  }

  public remove(username: string) {
    const key = `${this.jwtKey}-${username}`;
    sessionStorage.removeItem(key);
    localStorage.removeItem(key);
  }
}
