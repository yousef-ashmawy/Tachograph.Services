import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainmenuComponent } from './mainmenu/mainmenu.component';
import { MainheaderComponent } from './mainheader/mainheader.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { JwtInterceptor } from '../_helpers/jwt.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';



@NgModule({
  declarations: [
    MainmenuComponent,
    MainheaderComponent
  ],
  imports: [
    RouterModule,
    CommonModule,
    FormsModule,
    TranslateModule,


  ],
  providers: [
    {
      provide : HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi   : true,
    }
  ],
  exports:[
    MainmenuComponent,
    MainheaderComponent
  ],
})
export class MainappModule { }
