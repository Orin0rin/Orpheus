import { HttpClient } from '@angular/common/http';
import {Injectable} from'@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/Environment';

@Injectable({
  providedIn: 'root'
})

export class LoginService{

  constructor(private http: HttpClient){}
  public getUserId(username: string): Observable<any>{

    return this.http.get(environment.api + 'User/' + username, { withCredentials: false })
  }
  public checkPassword(username:string, id:number, password:string): Observable<any>{
    return this.http.get(environment.api + 'User/'+ 'check-password/' +username+ '/'+ id + '/' + password, { withCredentials: false })
  }

  // private isLoggedInValue = false;
  // private userLevelValue: string | null | undefined;

  // // Call this method to log the user in
  // public login(userLevel: string) {
  //   this.isLoggedInValue = true;
  //   this.userLevelValue = userLevel;
  // }

  // // Call this method to log the user out
  // public logout() {
  //   this.isLoggedInValue = false;
  //   this.userLevelValue = null;
  // }

  // // Call this method to check if the user is logged in
  // public isLoggedIn(): boolean {
  //   return this.isLoggedInValue;
  // }

  // // Call this method to check if the user has the necessary permissions
  // public hasPermission(requiredUserLevel: string): boolean {
  //   return this.userLevelValue === requiredUserLevel;
  // }



}

