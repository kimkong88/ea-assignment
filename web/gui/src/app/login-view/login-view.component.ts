import { Component } from '@angular/core';
import { LoginService } from '../shared/services/login.service';

@Component({
	selector: 'app-login-view',
	templateUrl: './login-view.component.html',
	styleUrls: ['./login-view.component.css']
})
export class LoginViewComponent {
	textBoxValue = '';
	validation = true;

	constructor(private loginService: LoginService) {}

	onButtonClick() {
		this.validate();
		this.loginService.login();
		location.reload();
	}

	validate() {
		if (!this.textBoxValue.trim()) {
			this.validation = false;
			return;
		}
	}
}
