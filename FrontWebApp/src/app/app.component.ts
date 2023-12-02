import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(translate: TranslateService) { 
    translate.addLangs(['en', 'ar']);
    translate.setDefaultLang('en');
    var currentStoreLang = sessionStorage.getItem("lang") ? sessionStorage.getItem("lang") : 'en';
    if (currentStoreLang != undefined) {
      translate.use(currentStoreLang.match(/en|ar/) ? currentStoreLang : 'en');
    } else {
      const browserLang: any = translate.getBrowserLang();
      translate.use(browserLang.match(/en|ar/) ? browserLang : 'en');
    }
  }
  title = 'Tachograph.Services-FrontEnd';
}
