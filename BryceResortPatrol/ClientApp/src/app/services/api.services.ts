import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Candidate } from '../models/candidate';


@Injectable()
export class Api {
  constructor(private http: HttpClient) { }
  public createCandidate(candidate: Candidate) {
    return this.http.post('/api/join', candidate);
  }
}
