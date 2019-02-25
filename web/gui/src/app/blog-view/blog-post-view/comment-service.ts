import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { url, apiBaseUrl } from 'src/app/shared/constants/url';
import { IComment } from 'src/app/shared/models/comment.model';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

const serviceUrl = `${apiBaseUrl()}/blog/comments`;

@Injectable()
export class CommentService {
	constructor(private http: HttpClient) {}

	createComment(comment: IComment) {
		return this.http.post(`${serviceUrl}`, comment).pipe(
			catchError((error: HttpErrorResponse) => {
				return throwError(error);
			})
		);
	}
}
