import { Component } from '@angular/core';
import { LoginService } from '../shared/services/login.service';
import { Router } from '@angular/router';

@Component({
	selector: 'app-login-view',
	templateUrl: './login-view.component.html',
	styleUrls: ['./login-view.component.css']
})
export class LoginViewComponent {
	textBoxValue = '';
	validation = true;

	constructor(private loginService: LoginService, private router: Router) {}

	onButtonClick() {
		this.validate();
		this.loginService.login();
		this.router.navigateByUrl('/blogs');
	}

	validate() {
		if (!this.textBoxValue.trim()) {
			this.validation = false;
			return;
		}
	}
}
