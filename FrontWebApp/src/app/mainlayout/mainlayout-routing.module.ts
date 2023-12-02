import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './Screens/dashboard/dashboard.component';
import { DaydrivetimeviolationsComponent } from './Screens/daydrivetimeviolations/daydrivetimeviolations.component';
import { ResttimeviolationsComponent } from './Screens/resttimeviolations/resttimeviolations.component';
import { SingledrivetimeviolationsComponent } from './Screens/singledrivetimeviolations/singledrivetimeviolations.component';
import { WeekdrivetimeviolationsComponent } from './Screens/weekdrivetimeviolations/weekdrivetimeviolations.component';

const routes: Routes = [
{ path: 'dashboard', component: DashboardComponent },
{ path: 'daydrivetime', component: DaydrivetimeviolationsComponent },
{ path: 'resttimeviolations', component: ResttimeviolationsComponent },
{ path: 'singledrivetimeviolations', component: SingledrivetimeviolationsComponent },
{ path: 'weekdrivetimeviolations', component: WeekdrivetimeviolationsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MainlayoutRoutingModule { }
