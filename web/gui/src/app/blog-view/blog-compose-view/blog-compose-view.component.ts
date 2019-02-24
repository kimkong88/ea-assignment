import { Component } from '@angular/core';
import { BlogPostService } from 'src/app/shared/services/blog-post-service';
import { IPost } from 'src/app/shared/models/post.model';
import { loginKey } from 'src/app/shared/services/login.service';
import { Router } from '@angular/router';

@Component({
	selector: 'app-blog-view',
	templateUrl: './blog-compose-view.component.html',
	styleUrls: ['./blog-compose-view.component.css']
})
export class BlogComposeViewComponent {
	title: string;
	content: string;
	constructor(
		private blogPostService: BlogPostService,
		private router: Router
	) {}

	publishBlogPost() {
		const post: IPost = {
			title: this.title,
			content: this.content,
			authorId: JSON.parse(sessionStorage.getItem(loginKey)).id
		};
		this.blogPostService
			.createPost(post)
			.toPromise()
			.then(() => {
				this.router.navigateByUrl('/blogs');
			});
	}
}
