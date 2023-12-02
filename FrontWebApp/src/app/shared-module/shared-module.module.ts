import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { AlertComponent } from '../_components/alert/alert.component';




@NgModule({
  declarations: [
    AlertComponent
  ], 
  imports:[
    CommonModule,
    TranslateModule,  

   ],
  exports: [
    AlertComponent,

]
})
export class SharedModule { }
