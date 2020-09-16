import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';


const routes: Routes = [
  {
    path:"", redirectTo: '/login', pathMatch:'full'
  },

  {
    path:"user", component: UserComponent
  },
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  {
    path:"home", component: HomeComponent
  },
  { path: "admin", component: AdminComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
