import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // La URL de tu backend
private apiUrl = 'http://localhost:5213/api/Usuarios';

  constructor(private http: HttpClient) { }

  login(rut: string, password: string): Observable<any> {
    const body = { rut: rut, password: password };
    return this.http.post(`${this.apiUrl}/login`, body);
  }
}