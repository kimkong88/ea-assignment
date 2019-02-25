import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { loginKey } from '../shared/services/login.service';

@Component({
	selector: 'app-blog-view',
	templateUrl: './blog-view.component.html',
	styleUrls: ['./blog-view.component.css']
})
export class BlogViewComponent {
	name: string;
	constructor(private router: Router) {
		this.router.navigateByUrl('/posts');
		this.getName();
	}

	getName() {
		this.name = JSON.parse(sessionStorage.getItem(loginKey)).name;
	}
}
