import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';
import { AuthenticationService } from '../_services/auth/authentication.service';


@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private authentication : AuthenticationService, private translate: TranslateService) { } 
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add auth header with jwt if user is logged in and request is to the api url
        
        const userToken = this.authentication.tokenKey;
        const isLoggedIn = this.authentication.isLoggedIn();
        let lang = this.translate.currentLang == 'en' ? this.translate.currentLang + '-US' : this.translate.currentLang + '-SA';

        if (isLoggedIn) {
            request = request.clone({
                setHeaders: {
                    'Accept-Language': lang,
                    Authorization: `Bearer ${userToken}`
                }
            });
        }else{
            request = request.clone({
                setHeaders: {
                    'Accept-Language': lang
                }
            });
        }

        return next.handle(request);
    }
    
}