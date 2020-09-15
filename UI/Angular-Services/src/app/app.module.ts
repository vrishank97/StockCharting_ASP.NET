import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from "@angular/common/http";
import { FormsModule } from '@angular/forms'
import {ReactiveFormsModule} from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CalculateService } from './services/calculate.service';
import { ItemService } from './services/item.service';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './user/register/register.component';
import { CompaniesComponent } from './home/companies/companies.component';
import { IposComponent } from './home/ipos/ipos.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UserComponent,
    HomeComponent,
    RegisterComponent,
    CompaniesComponent,
    IposComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [CalculateService,ItemService],
  bootstrap: [UserComponent]
})
export class AppModule { }
