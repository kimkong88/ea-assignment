import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BlogViewComponent } from './blog-view.component';

const appRoutes: Routes = [
	{
		path: 'blogs',
		component: BlogViewComponent
	}
];

@NgModule({
	imports: [RouterModule.forChild(appRoutes)],
	exports: [RouterModule],
	providers: []
})
export class BlogViewRoutingModule {}
