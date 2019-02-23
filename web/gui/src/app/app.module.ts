import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginViewComponent } from './login-view/login-view.component';
import { DxTextBoxModule, DxButtonModule } from 'devextreme-angular';
import { AppRoutingModule } from './app-routing.module';
import { BlogViewComponent } from './blog-view/blog-view.component';
import { LoginService } from './shared/services/login.service';

@NgModule({
	declarations: [AppComponent, LoginViewComponent, BlogViewComponent],
	imports: [BrowserModule, AppRoutingModule, DxTextBoxModule, DxButtonModule],
	providers: [LoginService],
	bootstrap: [AppComponent]
})
export class AppModule {}
