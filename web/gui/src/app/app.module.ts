import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginAreaComponent } from './login-area/login-area.component';

@NgModule({
	imports: [BrowserModule],
	declarations: [AppComponent, LoginAreaComponent],
	bootstrap: [AppComponent]
})
export class AppModule {}
