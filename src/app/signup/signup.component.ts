// import { Component, OnInit } from '@angular/core';
// import { SignupDto } from "./signup.model";
// import { SignupService } from "./signup.service";
// import { HttpClient } from "@angular/common/http";
// import { Router } from '@angular/router';
// import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import Swal from "sweetalert2";

// @Component({
//   selector: 'app-signup',
//   templateUrl: './signup.component.html',
//   styleUrls: ['./signup.component.scss']
// })
// export class SignupComponent implements OnInit {

//   private userId: any;
//   private successfull:any;
//   private validpass: any;
//   public signupinfo: SignupDto | any;
//      password: string = '';
//   isPasswordVisible: boolean = false;

//    constructor(private http: HttpClient, private signupservice: SignupService, private router: Router){
//     this.signupinfo = new SignupDto();
//    }


//   togglePasswordVisibility() {
//     this.isPasswordVisible = !this.isPasswordVisible;
//   }

//  getPasswordRole(password:string) {
//   const passwordRegex = /^(?=.*[A-Z])(?=.*\d).{8,}$/;

//   if (!this.password) {
//     return '';
//   } else if (!passwordRegex.test(this.password)) {
//     return 'invalid';
//   } else {
//     return 'valid';
//   }
// }

//   SaveLoginInfo() {
//     if (!this.signupinfo) {
//       return;
//     }

//     this.signupservice.CheckUsername(this.signupinfo.username).subscribe(result => {
//       this.userId = result;

//       if (!this.userId)
//       {
//        this.validpass =this.getPasswordRole(this.signupinfo.password);
//         if(this.validpass)
//         {
//           if (this.signupinfo.password==this.signupinfo.confirmpassword)
//           {
//             this.successfull = this.signupservice.SendUser(this.signupinfo)
//             if(this.successfull)
//             {
//               Swal.fire('Successfull!');
//               this.router.navigate(['/login']);
//             }
//             else
//             {
//               Swal.fire('Try again later!');
//             }

//           }
//           else
//           {
//             Swal.fire('Check password again.');
//           }
//         }
//       }
//       else
//       {
//         Swal.fire('Choose another username.');
//       }
//     });
//   }








// }

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SignupService } from './signup.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  signupForm!: FormGroup;

  isPasswordVisible: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private signupService: SignupService
  ) {}

  ngOnInit() {
    this.signupForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required]
    });

    this.signupForm.valueChanges.subscribe(() => {
      this.validatePasswords();
    });
  }

  togglePasswordVisibility() {
    this.isPasswordVisible = !this.isPasswordVisible;
  }

  getPasswordRole(password: string) {
    const passwordRegex = /^(?=.*[A-Z])(?=.*\d).{8,}$/;

    if (!password) {
      return '';
    } else if (!passwordRegex.test(password)) {
      return 'invalid';
    } else {
      return 'valid';
    }
  }
  isFieldInvalid(fieldName: string): boolean {
    const formControl = this.signupForm.get(fieldName)!;
    return formControl?.invalid && formControl?.touched;
  }
  isPasswordMismatch(): boolean {
    const passwordControl = this.signupForm.get('password');
    const confirmPasswordControl = this.signupForm.get('confirmPassword');
    return passwordControl?.value !== confirmPasswordControl?.value;
  }


  onSubmit() {
    if (this.signupForm.valid) {
      const { username, password, confirmPassword } = this.signupForm.value;

      this.signupService.CheckUsername(username).subscribe(result => {
        if (!result) {
          const passwordRole = this.getPasswordRole(password);

          if (passwordRole === 'valid') {
            if (password === confirmPassword) {
              this.signupService.SendUser(this.signupForm.value).subscribe(() => {
                Swal.fire('Success!', 'Registration successful.', 'success');
                // Redirect to login page or perform any other desired action
              }, () => {
                Swal.fire('Error!', 'Failed to register. Please try again later.', 'error');
              });
            } else {
              Swal.fire('Error!', 'Passwords do not match.', 'error');
            }
          } else {
            Swal.fire('Error!', 'Invalid password. Please choose a stronger password.', 'error');
          }
        } else {
          Swal.fire('Error!', 'Username already exists. Please choose a different username.', 'error');
        }
      });
    }
  }

  validatePasswords() {
    const passwordControl = this.signupForm.get('password')!;
    const confirmPasswordControl = this.signupForm.get('confirmPassword')!;

    if (passwordControl.value !== confirmPasswordControl.value) {
      confirmPasswordControl.setErrors({ mismatch: true });
    } else {
      confirmPasswordControl.setErrors(null);
    }
  }
}

