import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from './shared/services/login.service';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
	isLoggedIn = false;

	constructor(private router: Router, private loginService: LoginService) {}

	ngOnInit() {
		this.isLoggedIn = this.loginService.isLoggedIn() === 'loggedIn';
		if (!this.isLoggedIn) {
			this.router.navigate(['/login']);
		} else {
			this.router.navigate(['/']);
		}
	}
}
