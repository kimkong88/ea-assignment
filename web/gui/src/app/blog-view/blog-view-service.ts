import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { IPost } from '../shared/models/post.model';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { url } from '../shared/constants/url';

const serviceUrl = `${url.base}/blog/posts`;

@Injectable()
export class BlogViewService {
	constructor(private http: HttpClient) {}

	fetchPosts() {
		return this.http.get(serviceUrl).pipe(
			map((response: IPost[]) => {
				return response;
			}),
			catchError((error: HttpErrorResponse) => {
				return throwError(error);
			})
		);
	}

	fetchPostById(postId: any) {
		return this.http.get(`${serviceUrl}/${postId}`).pipe(
			map((response: IPost) => {
				return response;
			}),
			catchError((error: HttpErrorResponse) => {
				return throwError(error);
			})
		);
	}
}
