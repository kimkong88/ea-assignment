import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { apiBaseUrl } from '../constants/url';
import { IAuthor } from '../models/author.model';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

const serviceUrl = `${apiBaseUrl()}/blog/authors`;

@Injectable()
export class AuthorService {
	constructor(private http: HttpClient) {}

	getAuthorByName(authorName: string) {
		return this.http.get(`${serviceUrl}/${authorName}`).pipe(
			map((response: IAuthor) => {
				return response;
			}),
			catchError((error: HttpErrorResponse) => {
				return throwError(error);
			})
		);
	}

	createAuthor(author: IAuthor) {
		return this.http.post(`${serviceUrl}`, author).pipe(
			catchError((error: HttpErrorResponse) => {
				return throwError(error);
			})
		);
	}
}
