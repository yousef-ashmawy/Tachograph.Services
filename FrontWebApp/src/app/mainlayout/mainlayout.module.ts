import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainlayoutRoutingModule } from './mainlayout-routing.module';
import { MainlayoutComponent } from './mainlayout.component';
import { MainappModule } from "../mainapp/mainapp.module";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from '../shared-module/shared-module.module';
import { PagerComponent } from './Shared/pager/pager.component';
import { DialogComponent } from '../_components/dialog/dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { DashboardComponent } from './Screens/dashboard/dashboard.component';
import { DaydrivetimeviolationsComponent } from './Screens/daydrivetimeviolations/daydrivetimeviolations.component';
import { ResttimeviolationsComponent } from './Screens/resttimeviolations/resttimeviolations.component';
import { SingledrivetimeviolationsComponent } from './Screens/singledrivetimeviolations/singledrivetimeviolations.component';
import { WeekdrivetimeviolationsComponent } from './Screens/weekdrivetimeviolations/weekdrivetimeviolations.component';


@NgModule({
    declarations: [
        MainlayoutComponent,
        PagerComponent,
        DialogComponent,
        DaydrivetimeviolationsComponent,
        DashboardComponent,
        ResttimeviolationsComponent,
        SingledrivetimeviolationsComponent,
        WeekdrivetimeviolationsComponent
    ],
    imports: [
        CommonModule,
        MainappModule,
        MainlayoutRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        SharedModule,
        MatDialogModule,
        TranslateModule

    ]
})
export class MainlayoutModule { }
