import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountComponent } from './account/account.component';
import { RegisterComponent } from './account/register/register.component';


const routes: Routes = [
  {
    path:"", redirectTo: '/account/register', pathMatch:'full'
  },

  {
    path:"account", component: AccountComponent,
    children: [
      { path: "register", component: RegisterComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
