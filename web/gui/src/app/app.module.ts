import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginViewComponent } from './login-view/login-view.component';
import {
	DxTextBoxModule,
	DxButtonModule,
	DxListModule,
	DxTextAreaModule
} from 'devextreme-angular';
import { AppRoutingModule } from './app-routing.module';
import { BlogViewComponent } from './blog-view/blog-view.component';
import { LoginService } from './shared/services/login.service';
import { BlogViewService } from './blog-view/blog-view-service';
import { HttpClientModule } from '@angular/common/http';
import { BlogPostViewComponent } from './blog-view/blog-post-view/blog-post-view.component';
import { BlogListViewComponent } from './blog-view/blog-list-view/blog-list-view.component';

@NgModule({
	declarations: [
		AppComponent,
		LoginViewComponent,
		BlogViewComponent,
		BlogPostViewComponent,
		BlogListViewComponent
	],
	imports: [
		HttpClientModule,
		BrowserModule,
		AppRoutingModule,
		DxTextBoxModule,
		DxButtonModule,
		DxListModule,
		DxTextAreaModule
	],
	providers: [LoginService, BlogViewService],
	bootstrap: [AppComponent]
})
export class AppModule {}
