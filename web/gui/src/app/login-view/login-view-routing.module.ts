import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginViewComponent } from './login-view.component';

const appRoutes: Routes = [
	{
		path: 'login',
		component: LoginViewComponent
	}
];

@NgModule({
	imports: [RouterModule.forChild(appRoutes)],
	exports: [RouterModule],
	providers: []
})
export class LoginViewRoutingModule {}
