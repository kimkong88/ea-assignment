import { Injectable } from '@angular/core';
import { IAuthor } from '../models/author.model';

export const loginKey = 'AUTHOR_SETTINGS';

@Injectable()
export class LoginService {
	constructor() {}

	login(author: IAuthor) {
		sessionStorage.setItem(loginKey, JSON.stringify(author));
	}

	isLoggedIn() {
		return sessionStorage.getItem(loginKey) !== null;
	}
}
