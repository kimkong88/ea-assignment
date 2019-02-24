import { Component } from '@angular/core';
import { LoginService } from '../shared/services/login.service';
import { Router } from '@angular/router';
import { AuthorService } from '../shared/services/author.service';
import notify from 'devextreme/ui/notify';
import { IAuthor } from '../shared/models/author.model';
@Component({
	selector: 'app-login-view',
	templateUrl: './login-view.component.html',
	styleUrls: ['./login-view.component.css']
})
export class LoginViewComponent {
	textBoxValue = '';
	validation = true;

	constructor(
		private loginService: LoginService,
		private authorService: AuthorService,
		private router: Router
	) {}

	onButtonClick() {
		this.validate();
		this.authorService
			.getAuthorByName(this.textBoxValue)
			.toPromise()
			.then(author => {
				if (!author) {
					const newAuthor: IAuthor = {
						name: this.textBoxValue
					};
					this.authorService
						.createAuthor(newAuthor)
						.toPromise()
						.then(() => {
							notify('New user registered!', 'success', 600);
						});
				} else {
					this.loginService.login(author);
					this.router.navigateByUrl('/blogs');
				}
			});
	}

	validate() {
		if (!this.textBoxValue.trim()) {
			this.validation = false;
			return;
		}
	}
}
