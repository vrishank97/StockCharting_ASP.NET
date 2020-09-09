import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewitemComponent } from './viewitem/viewitem.component';


const routes: Routes = [
  {path:'item',component:ViewitemComponent},
  {path:'',redirectTo:'/',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
