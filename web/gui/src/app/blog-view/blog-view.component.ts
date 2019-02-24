import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
	selector: 'app-blog-view',
	templateUrl: './blog-view.component.html',
	styleUrls: ['./blog-view.component.css']
})
export class BlogViewComponent {
	constructor(private router: Router) {
		this.router.navigateByUrl('/blogs');
	}
}
