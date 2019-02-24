import { Component } from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { BlogViewService } from './blog-view-service';
import { IPost } from '../shared/models/post.model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
	selector: 'app-blog-view',
	templateUrl: './blog-view.component.html',
	styleUrls: ['./blog-view.component.css']
})
export class BlogViewComponent {
	dataSource: DataSource = new DataSource({
		store: new CustomStore({
			key: 'id',
			load: (loadOptions: any) => this.loadDataSource(loadOptions),
			loadMode: 'raw'
		}),
		paginate: true,
		pageSize: 5
	});

	userName = 'Admin';

	constructor(
		private blogViewService: BlogViewService,
		private router: Router,
		private route: ActivatedRoute
	) {}

	async loadDataSource({  }: any): Promise<any> {
		return this.blogViewService
			.fetchPosts()
			.toPromise()
			.then((response: IPost[]) => {
				response.forEach(post => {
					post.createdAt = this.parseDateTimeToLocaleString(
						post.createdAt
					);
				});
				return response;
			});
	}

	onPostClick(e: any) {
		this.router.navigate(['blogs/post', e.itemData.id], {
			relativeTo: this.route
		});
	}

	parseDateTimeToLocaleString(dateTimeString: any): string {
		const parseDateTime = new Date(Date.parse(dateTimeString));
		const options = {
			year: 'numeric',
			month: 'long',
			day: 'numeric'
		};
		return new Intl.DateTimeFormat('en-US', options).format(parseDateTime);
	}
}
