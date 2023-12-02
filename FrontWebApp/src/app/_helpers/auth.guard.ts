import { Injectable } from '@angular/core';
import {
  Router,
} from '@angular/router';
import { AuthenticationService } from '../_services/auth/authentication.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard {
  constructor(
    private authService: AuthenticationService,
    private router: Router
  ) {}

  canActivate(): boolean {
    if (this.authService.isLoggedIn() == false) {
      this.router.navigate(['/login']);
    }
    return true;
  }
}