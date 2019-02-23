import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../shared/services/login.service';

@Component({
	selector: 'app-login-view',
	templateUrl: './login-view.component.html',
	styleUrls: ['./login-view.component.css']
})
export class LoginViewComponent {
	constructor(private router: Router, private loginService: LoginService) {}

	onButtonClick() {
		this.loginService.login();
		location.reload();
	}
}
