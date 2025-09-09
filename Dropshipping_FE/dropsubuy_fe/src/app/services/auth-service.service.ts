import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  constructor(private http: HttpClient) { }

  public login(username: string, password: string) {
    return this.http.post('http://localhost:x/api/auth/login', {username, password});
  }
}
