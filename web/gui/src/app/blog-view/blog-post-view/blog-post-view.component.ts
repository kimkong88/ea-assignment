import { Component, OnInit } from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { BlogViewService } from '../blog-view-service';
import { IPost } from 'src/app/shared/models/post.model';
import { ActivatedRoute } from '@angular/router';
import { CommentService } from './comment-service';
import { loginKey } from 'src/app/shared/services/login.service';
import * as _ from 'lodash';

@Component({
	selector: 'app-blog-post-view',
	templateUrl: './blog-post-view.component.html',
	styleUrls: ['./blog-post-view.component.css']
})
export class BlogPostViewComponent implements OnInit {
	post: IPost;
	comment: string;

	constructor(
		private blogViewService: BlogViewService,
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
				this.post.comments = _.sortBy(this.post.comments, 'createdAt');
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
