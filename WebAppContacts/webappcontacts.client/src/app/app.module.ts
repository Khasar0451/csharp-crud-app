import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactComponent } from './contact/view/contact-view/contact.component';
import { ContactListComponent } from './contact/view/contact-list/contact-list.component';
import { LoginFormComponent } from './component/login-form/login-form.component';
import { RoutesRoutes } from './routes.routing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [	
    AppComponent, ContactComponent, ContactListComponent, LoginFormComponent
  
   ],
  imports: [
    BrowserModule, HttpClientModule, 
    AppRoutingModule, RoutesRoutes, FormsModule, ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
