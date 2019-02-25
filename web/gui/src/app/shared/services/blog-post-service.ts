import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { IPost } from '../models/post.model';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { apiBaseUrl } from '../constants/url';

const serviceUrl = `${apiBaseUrl()}/blog/posts`;

@Injectable()
export class BlogPostService {
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

	createPost(post: IPost) {
		return this.http.post(`${serviceUrl}`, post).pipe(
			catchError((error: HttpErrorResponse) => {
				return throwError(error);
			})
		);
	}
}
