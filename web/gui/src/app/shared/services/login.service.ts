import { Injectable } from '@angular/core';

export const loginKey = 'LOGIN_KEY';

@Injectable()
export class LoginService {
	constructor() {}

	login() {
		sessionStorage.setItem(loginKey, 'loggedIn');
	}

	isLoggedIn() {
		return sessionStorage.getItem(loginKey);
	}
}
