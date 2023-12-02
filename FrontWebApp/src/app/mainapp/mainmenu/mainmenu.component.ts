import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_services/auth/authentication.service';

@Component({
  selector: 'app-mainmenu',
  templateUrl: './mainmenu.component.html',
  styleUrls: ['./mainmenu.component.css']
})
export class MainmenuComponent {
  Menus: any
  constructor(private authenticationService: AuthenticationService, private router: Router
  ) {
  }
  ngOnInit() {
    this.loadScript();
  }
  logout() {
    this.authenticationService.Logout();
    this.router.navigate(['/login']);
  }
  loadScript() {
    let body = <HTMLDivElement>document.body;
    let script = document.createElement('script');
    script.innerHTML = '';
    script.src = 'assets/Site_Script/main_Function.js';
    script.async = true;
    script.defer = true;
    body.appendChild(script);
  }
}
