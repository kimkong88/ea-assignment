import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BlogViewComponent } from './blog-view.component';
import { BlogPostViewComponent } from './blog-post-view/blog-post-view.component';

const appRoutes: Routes = [
	{
		path: 'blogs',
		component: BlogViewComponent,
		children: [
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
