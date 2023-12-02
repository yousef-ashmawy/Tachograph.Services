import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthenticationService } from '../_services/auth/authentication.service';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { HandleError } from '../_helpers/handleError';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-Login',
  templateUrl: './Login.component.html',
  styleUrls: ['./Login.component.css']
})
export class LoginComponent implements OnInit {
  show: boolean = false;
  imageSource: any
  options = {
    collapsed: false,
    boxed: false,
    dark: false
  };
  loginForm: any;
  @Output()
  messageEvent = new EventEmitter();
  constructor(private authenticationService: AuthenticationService,
    private router: Router,
    public translate: TranslateService,
    public handelError: HandleError) {
  }

  ngOnInit() {
    this.createFormControl()
  }
  createFormControl() {

    this.loginForm = new FormGroup({
      email: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required, Validators.maxLength(14), Validators.minLength(8)]),
    });
  }

  public onSubmit(): void {
    debugger
    if (this.loginForm.valid) {
      this.authenticationService.login(this.loginForm.value).subscribe(response => {
        if (response) {
          this.authenticationService.tokenKey = response.token;
          sessionStorage.setItem('token', response.token);
          sessionStorage.setItem("email", response.email);
          this.router.navigate(['/dashboard']);
        }
      }, error => {
        this.handelError.showErrorMessage("Email Or Password InValid");
      });
    } else {
      Object.keys(this.loginForm.controls).forEach(key => {
        this.loginForm.controls[key].markAsDirty();
      });
    }
  }

  ShowPassword() {
    this.show = !this.show;
  }
}
