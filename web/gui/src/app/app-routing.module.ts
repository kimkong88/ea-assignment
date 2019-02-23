import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { url } from './shared/constants/url';
import { LoginViewRoutingModule } from './login-view/login-view-routing.module';
import { BlogViewRoutingModule } from './blog-view/blog-view-routing.module';

export const appRoutes: Routes = [
	{
		path: '',
		redirectTo: url.default,
		pathMatch: 'full'
	}
];

@NgModule({
	imports: [RouterModule.forRoot(appRoutes, {})],
	exports: [RouterModule, LoginViewRoutingModule, BlogViewRoutingModule]
})
export class AppRoutingModule {}
