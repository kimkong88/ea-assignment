import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { url } from './shared/constants/url';
import { BlogViewComponent } from './blog-view/blog-view.component';
import { LoginViewComponent } from './login-view/login-view.component';

export const appRoutes: Routes = [
	{
		path: '**',
		redirectTo: url.default
	},
	{
		path: 'login',
		component: LoginViewComponent
	},
	{
		path: 'blog',
		component: BlogViewComponent
	}
];

@NgModule({
	imports: [RouterModule.forRoot(appRoutes, {})],
	exports: [RouterModule]
})
export class AppRoutingModule {}
