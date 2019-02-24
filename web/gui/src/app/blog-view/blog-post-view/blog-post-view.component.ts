import { Component } from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { BlogViewService } from '../blog-view-service';
import { IPost } from 'src/app/shared/models/post.model';

@Component({
	selector: 'app-blog-post-view',
	templateUrl: './blog-post-view.component.html',
	styleUrls: ['./blog-post-view.component.css']
})
export class BlogPostViewComponent {
	post: IPost;

	constructor(private blogViewService: BlogViewService) {}

	loadDataSource(options: any): Promise<any> {
		console.log(options);
		return this.blogViewService
			.fetchPosts()
			.toPromise()
			.then(response => {
				return response;
			});
	}
}
