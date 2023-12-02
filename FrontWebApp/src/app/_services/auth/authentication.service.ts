import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserManagementWebApis } from 'src/environments/environment';
import { BaseService } from '../base/base.service';

 
@Injectable({
  providedIn: 'root',
})
export class AuthenticationService extends BaseService{
  tokenKey = sessionStorage.getItem("token");

  constructor(
      private http: HttpClient,
  ) {
    super();
  }

  public login(model:any): Observable<any> {
    return this.http.post(UserManagementWebApis.authApi, model)
  };

  public isLoggedIn(): boolean {
    if (sessionStorage.getItem("token") != undefined) {
      return true;
    } else {
      return false;
    }
  };
  
  public getEmail(): string {
    if (sessionStorage.getItem("email") != undefined || sessionStorage.getItem("email")) {
      return sessionStorage.getItem("email") ?? "";
    }
    else {
      this.Logout();
    }
    return "";
  }

  public Logout() {
    sessionStorage.clear();
  };

}