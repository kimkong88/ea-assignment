import { Component } from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { BlogPostService } from '../../shared/services/blog-post-service';
import { IPost } from '../../shared/models/post.model';
import { Router } from '@angular/router';
import { parseDateTimeToLocaleString } from 'src/app/shared/helpers/parse-date-time.helper';
import * as _ from 'lodash';

@Component({
	selector: 'app-blog-list-view',
	templateUrl: './blog-list-view.component.html',
	styleUrls: ['./blog-list-view.component.css']
})
export class BlogListViewComponent {
	dataSource: DataSource = new DataSource({
		store: new CustomStore({
			key: 'id',
			load: (loadOptions: any) => this.loadDataSource(loadOptions),
			loadMode: 'raw'
		}),
		paginate: true,
		pageSize: 5
	});

	constructor(
		private blogPostService: BlogPostService,
		private router: Router
	) {}

	async loadDataSource({  }: any): Promise<any> {
		return this.blogPostService
			.fetchPosts()
			.toPromise()
			.then((response: IPost[]) => {
				let posts = response;
				posts.forEach(post => {
					post.createdDateTime = parseDateTimeToLocaleString(
						post.createdDateTime
					);
				});
				return posts;
			});
	}

	onPostClick(e: any) {
		this.router.navigateByUrl(`/post/${e.itemData.id}`);
	}

	onFabClick() {
		this.router.navigateByUrl('/compose');
	}
}
