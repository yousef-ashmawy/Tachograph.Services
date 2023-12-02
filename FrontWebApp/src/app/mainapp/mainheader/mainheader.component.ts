import { Component, EventEmitter, Output } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { AuthenticationService } from 'src/app/_services/auth/authentication.service';

@Component({
  selector: 'app-mainheader',
  templateUrl: './mainheader.component.html',
  styleUrls: ['./mainheader.component.css']
})
export class MainheaderComponent {
  Email: string = ""
  options = {
    collapsed: false,
    boxed: false,
    dark: false,
  };
  @Output()
  messageEvent = new EventEmitter();
  constructor(private authenticationService: AuthenticationService,
    public translate: TranslateService
  ) {
  }
  ngOnInit() {
    this.Email = this.authenticationService.getEmail();
  }
}