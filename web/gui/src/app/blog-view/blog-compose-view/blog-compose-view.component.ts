import { Component } from '@angular/core';
import { BlogPostService } from 'src/app/shared/services/blog-post-service';
import { IPost } from 'src/app/shared/models/post.model';
import { loginKey } from 'src/app/shared/services/login.service';
import { Router } from '@angular/router';
import notify from 'devextreme/ui/notify';

@Component({
	selector: 'app-blog-view',
	templateUrl: './blog-compose-view.component.html',
	styleUrls: ['./blog-compose-view.component.css']
})
export class BlogComposeViewComponent {
	title = '';
	content = '';
	constructor(
		private blogPostService: BlogPostService,
		private router: Router
	) {}

	publishBlogPost() {
		if (!this.title.trim() || !this.content.trim()) {
			notify('Title or content cannot be empty.', 'warning', 600);
			return;
		}
		const post: IPost = {
			title: this.title,
			content: this.content,
			authorId: JSON.parse(sessionStorage.getItem(loginKey)).id
		};
		this.blogPostService
			.createPost(post)
			.toPromise()
			.then(() => {
				this.router.navigateByUrl('/posts');
			});
	}
}
