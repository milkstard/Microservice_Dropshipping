import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  constructor(private http: HttpClient) { }

  public login(email: string, password: string) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post('https://localhost:7143/api/users/login', {email, password}, { headers });
  }
}
