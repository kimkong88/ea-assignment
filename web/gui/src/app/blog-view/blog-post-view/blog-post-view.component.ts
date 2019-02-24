import { Component, OnInit } from '@angular/core';
import { BlogPostService } from '../../shared/services/blog-post-service';
import { IPost } from 'src/app/shared/models/post.model';
import { ActivatedRoute } from '@angular/router';
import { CommentService } from './comment-service';
import { loginKey } from 'src/app/shared/services/login.service';
import * as _ from 'lodash';
import { parseDateTimeToLocaleString } from 'src/app/shared/helpers/parse-date-time.helper';

@Component({
	selector: 'app-blog-post-view',
	templateUrl: './blog-post-view.component.html',
	styleUrls: ['./blog-post-view.component.css']
})
export class BlogPostViewComponent implements OnInit {
	post: IPost;
	comment: string;

	constructor(
		private blogViewService: BlogPostService,
		private commentService: CommentService,
		private route: ActivatedRoute
	) {}

	ngOnInit() {
		this.fetchPost();
	}

	fetchPost() {
		const id = this.route.snapshot.paramMap.get('id');
		this.blogViewService
			.fetchPostById(id)
			.toPromise()
			.then(response => {
				this.post = response;
				this.post.createdDateTime = parseDateTimeToLocaleString(
					this.post.createdDateTime
				);

				this.post.comments.forEach(comment => {
					comment.createdDateTime = parseDateTimeToLocaleString(
						comment.createdDateTime
					);
				});
			});
	}

	onSubmit() {
		const comment = {
			content: this.comment,
			postId: this.post.id,
			authorId: JSON.parse(sessionStorage.getItem(loginKey)).id
		};
		this.commentService
			.createComment(comment)
			.toPromise()
			.then(() => {
				this.fetchPost();
			});
	}
}
