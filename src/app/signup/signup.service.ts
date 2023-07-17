import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/Environment';

@Injectable({
  providedIn: 'root'
})
export class SignupService {

  constructor(private http: HttpClient) {}

  public CheckUsername(username: string): Observable<any> {
    return this.http.get(environment.api + 'User/' + username, { withCredentials: false });
  }

  public SendUser(SignupDto: any): Observable<any> {
    return this.http.post(environment.api + 'User', {
      username: SignupDto.username,
      password: SignupDto.password,
      levelId: 4,
      userimgaddress: SignupDto.userimgaddress
    }, { withCredentials: false });
  }
}
