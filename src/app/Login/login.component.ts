import { Component } from "@angular/core";
import { LoginDto } from "./login.model";
import { LoginService } from "./login.service";
import { HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';
import Swal from "sweetalert2";
import { CookieService } from 'ngx-cookie-service';





@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent {
private userId: any;
public logininfo: LoginDto | any;

 constructor(private http: HttpClient, private loginSrv: LoginService, private router: Router, private cookieService: CookieService){
  this.logininfo = new LoginDto();
 }

SaveLoginInfo() {
  if (!this.logininfo) {
    return;
  }

  this.loginSrv.getUserId(this.logininfo.username).subscribe(result => {
    this.userId = result;

    if (this.userId) {
      this.loginSrv.checkPassword(this.logininfo.userName, this.userId, this.logininfo.password).subscribe(result => {
        const isPasswordCorrect = result.isPasswordCorrect;
        const userLevel = result.userLevel;
        const jwt = result.jwt;

        if (isPasswordCorrect) {
          this.cookieService.set('jwt', jwt);
          if(userLevel=="Main Admin") this.router.navigate(['/podcast']);
          else                        this.router.navigate(['/podcastuser']);
          // this.loginSrv.login(userLevel);
          this.logininfo = null;
          this.userId = null;
        } else {
          Swal.fire('Your password is not correct.');
        }
      });
    } else {
      Swal.fire('The username is invalid.');
    }
  });
}
}
