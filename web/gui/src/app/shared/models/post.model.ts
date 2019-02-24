import { IAuthor } from './author.model';
import { IComment } from './comment.model';

export interface IPost {
	id: string;
	title: string;
	content: string;
	author: IAuthor;
	authorName: string;
	comments: IComment[];
	createdAt: string;
	updatedAt: string;
}
