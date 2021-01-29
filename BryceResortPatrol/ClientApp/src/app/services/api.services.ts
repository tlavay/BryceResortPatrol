import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Candidate } from '../models/candidate';
import { JwtToken } from '../models/jwt-token';
import { User } from '../models/user';


@Injectable()
export class Api {
  constructor(private http: HttpClient) { }
  public createCandidate(candidate: Candidate) {
    return this.http.post('/api/join/create-candidate', candidate);
  }

  public signIn(user: User) {
    return this.http.post<JwtToken>('/api/auth/sign-in', user);
  }

  public validateToken(token: string): Observable<boolean> {
    const headers = new HttpHeaders().set('Authorization', 'Bearer ' + token);
    return this.http.get<boolean>('/api/auth/validate', { headers });
  }
}
