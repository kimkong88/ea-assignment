import { Component } from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { BlogViewService } from '../blog-view-service';
import { IPost } from '../../shared/models/post.model';
import { Router, ActivatedRoute } from '@angular/router';
import { parseDateTimeToLocaleString } from 'src/app/shared/helpers/parse-date-time.helper';

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
		private blogViewService: BlogViewService,
		private router: Router
	) {}

	async loadDataSource({  }: any): Promise<any> {
		return this.blogViewService
			.fetchPosts()
			.toPromise()
			.then((response: IPost[]) => {
				response.forEach(post => {
					post.createdDateTime = parseDateTimeToLocaleString(
						post.createdDateTime
					);
				});
				return response;
			});
	}

	onPostClick(e: any) {
		this.router.navigateByUrl(`/post/${e.itemData.id}`);
	}
}
