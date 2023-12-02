import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { MainlayoutComponent } from './mainlayout/mainlayout.component';
import { AuthGuard } from './_helpers/auth.guard';

const routes: Routes = [
  { path: "", component: LoginComponent, pathMatch: 'full' },
  { path: "login", component: LoginComponent},
  {
    path: '',
    component: MainlayoutComponent,
    children: [
        {
      path: '',
      canActivate: [AuthGuard],
      loadChildren: () => import('src/app/mainlayout/mainlayout.module').then(x=>x.MainlayoutModule)
  }]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
