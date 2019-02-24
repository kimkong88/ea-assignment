import { Component, OnInit } from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { BlogViewService } from '../blog-view-service';
import { IPost } from 'src/app/shared/models/post.model';
import { ActivatedRoute } from '@angular/router';
import { CommentService } from './comment-service';

@Component({
	selector: 'app-blog-post-view',
	templateUrl: './blog-post-view.component.html',
	styleUrls: ['./blog-post-view.component.css'],
	providers: [CommentService]
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
			});
	}

	onButtonClick() {
		const comment = {
			content: this.comment,
			postId: this.post.id,
			authorId: ''
		};
		this.commentService.createComment(comment);
	}
}
