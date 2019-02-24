import { IAuthor } from './author.model';
import { IComment } from './comment.model';

export interface IPost {
	id?: string;
	title: string;
	content: string;
	author?: IAuthor;
	authorId?: string;
	authorName?: string;
	comments?: IComment[];
	createdDateTime?: string;
	updatedDateTime?: string;
}
