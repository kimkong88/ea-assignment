import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BlogViewComponent } from './blog-view.component';
import { BlogPostViewComponent } from './blog-post-view/blog-post-view.component';
import { BlogListViewComponent } from './blog-list-view/blog-list-view.component';

const appRoutes: Routes = [
	{
		path: '',
		component: BlogViewComponent,
		children: [
			{
				path: 'blogs',
				component: BlogListViewComponent
			},
			{
				path: 'post/:id',
				component: BlogPostViewComponent
			}
		]
	}
];

@NgModule({
	imports: [RouterModule.forChild(appRoutes)],
	exports: [RouterModule],
	providers: []
})
export class BlogViewRoutingModule {}
